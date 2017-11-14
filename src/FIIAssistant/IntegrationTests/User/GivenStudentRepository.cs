using System;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using User.Business.Repository;
using User.Data.Access;
using User.Data.Model.Entities;

namespace IntegrationTests.User
{
    [TestClass]
    public class GivenStudentRepository : BaseIntegrationTest<UserContext>
    {
        [TestMethod]
        public void When_GettingAllStudents_Then_AllTheStudentsShouldBeLoaded()
        {
            RunOnDatabase(sut =>
            {
                //Arrange
                var repository = new StudentRepository(sut);
                var user1 = new Student
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mos",
                    LastName = "Craciun"
                };
                repository.Add(user1);

                var user2 = new Student
                {
                    Id = Guid.NewGuid(),
                    FirstName = "test",
                    LastName = "student"
                };
                repository.Add(user2);

                //Act
                var result = repository.GetAll();

                //Assert
                result.Count().Should().Be(2);
            });
        }

        [TestMethod]
        public void When_Saving1User_Then_TheUserShouldBeProperlyIntroduced()
        {
            RunOnDatabase(sut =>
            {
                //Arrange
                var repository = new StudentRepository(sut);
                var user = new Student("Mos")
                {
                    Id = Guid.NewGuid(),
                    LastName = "Craciun"
                };

                //Act
                repository.Add(user);
                var result = repository.GetAll();

                //Assert
                result.Count().Should().Be(1);
            });
        }

        [TestMethod]
        public void When_GettingStudentById_Then_TheProperStudentShouldBeLoaded()
        {
            var guid = Guid.NewGuid();

            RunOnDatabase(sut =>
            {
                //Arrange
                var repository = new StudentRepository(sut);

                var user = new Student
                {
                    Id = guid,
                    FirstName = "student",
                    LastName = "test"
                };

                repository.Add(user);

                //Act
                var result = repository.GetById(guid);

                //Assert
                result.Should().BeEquivalentTo(user);
            });
        }

        [TestMethod]
        public void When_UpdatingAStudent_Then_TheStudentShouldBeProperlyUpdated()
        {
            RunOnDatabase(sut =>
            {
                //Arrange
                var repository = new StudentRepository(sut);
                var user = new Student
                {
                    Id = Guid.NewGuid(),
                    FirstName = "student",
                    LastName = "test"
                };

                repository.Add(user);

                //Act
                user.LastName = "update Test";
                repository.Update(user);

                //Assert
                var result = repository.GetById(user.Id);
                result.LastName.Should().Be("update Test");
            });
        }

        [TestMethod]
        public void When_DeletingAStudent_Then_TheStudentShouldBeProperlyDeleted()
        {
            RunOnDatabase(sut =>
            {
                //Arrange
                var repository = new StudentRepository(sut);
                var user = new Student
                {
                    Id = Guid.NewGuid(),
                    FirstName = "student",
                    LastName = "test"
                };

                repository.Add(user);

                //Act
                repository.Delete(user.Id);

                //Assert
                var result = repository.GetAll();
                result.Count().Should().Be(0);
            });
        }

        protected override void RunOnMemory(Action<UserContext> databaseAction)
        {
            var options = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase("UserDB")
                .Options;

            using (var context = new UserContext(options))
            {
                databaseAction(context);
            }
        }

        protected override void RunOnSqlServer(Action<UserContext> databaseAction)
        {
            var connection =
                @"Server = .\SQLEXPRESS; Database = FIIAssistant.Development.Test; Trusted_Connection = True;";
            var options = new DbContextOptionsBuilder<UserContext>()
                .UseSqlServer(connection)
                .Options;

            using (var context = new UserContext(options))
            {
                databaseAction(context);
            }
        }
    }
}