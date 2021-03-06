﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Controllers;
using User.Data.Model.Entities;
using User.Presentation.Controllers;

namespace IntegrationTests.Server
{
    [TestClass]
    public class GivenStudentsApiController
    {
        public static StudentsApiController Sut;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            Sut = new StudentsApiController();
        }

        [TestMethod]
        [Ignore]
        //It is normal to fail, the application is not in debug mode nor hosted
        public void When_PostingAStudent_Then_CountShouldIncrease()
        {
            //arrange
            var expectedCount = StudentsController.Students.Count + 1;
            //act
            var result = Sut.Post(new Student("Stefan"));
            //assert
            StudentsController.Students.Count.Should().Be(expectedCount);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            Sut = null;
        }
    }
}