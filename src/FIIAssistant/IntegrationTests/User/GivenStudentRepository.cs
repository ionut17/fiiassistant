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
        public void When_Introducing1User_Then_TheUserShouldBeProperlyIntroduced()
        {
            RunOnDatabase(sut =>
            {
                //Arrange
                var repository = new StudentRepository(sut);
                var user = new Student
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mos",
                    LastName = "Craciun"
                };

                //Act
                repository.Add(user);
                var result = repository.GetAll();

                //Assert
                result.Count().Should().Be(1);
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