using System;
using System.Linq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using User.Business.Repository;
using User.Data.Access;
using User.Data.Model.Entities;
using User.Data.Model.Interfaces;

namespace IntegrationTests.User {
    [TestClass]
    public class GivenStudentRepository : BaseIntegrationTest<UserContext> {
        private IStudentRepository _studentRepository;

        [TestMethod]
        public void Given_UserRepository_When_Introducing3Users_Then_TheUsersShouldBeProperlyIntroduced() {
            var sut = CreateSystemUnderTest();

            var user = new Student {
                Id = Guid.NewGuid(),
                FirstName = "Mos",
                LastName = "Craciun"
            };

            sut.Add(user);

            var result = sut.GetAll();

            result.Count().Should().Be(1);
        }


        protected override void RunOnMemory(Action<UserContext> databaseAction) {
            var options = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase("UserDB")
                .Options;

            var context = new UserContext(options);
            databaseAction(context);
            _studentRepository = new StudentRepository(context);
        }

        protected override void RunOnSqlServer(Action<UserContext> databaseAction) {
            var connection =
                @"Server = .\SQLEXPRESS; Database = FIIAssistant.Development.Test; Trusted_Connection = True;";
            var options = new DbContextOptionsBuilder<UserContext>()
                .UseSqlServer(connection)
                .Options;

            var context = new UserContext(options);
            databaseAction(context);
            _studentRepository = new StudentRepository(context);
        }

        private IStudentRepository CreateSystemUnderTest() {
            return _studentRepository;
        }
    }
}