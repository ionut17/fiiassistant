﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timetable.Business.Repository;
using Timetable.Data.Model.Common;

namespace UnitTests.Timetable
{
    [TestClass]
    public class TimetableRepositoryTester
    {
        [TestMethod]
        public void When_TimetableRepositoryIsInstanciated_Then_ItReturnsWeekTimetable()
        {
            var repository = new TimetableRepository<GroupRequest>();
            var groupRequest = new GroupRequest
            {
                BaseAddress = "https://profs.info.uaic.ro/~orar",
                Group = "MIS1",
                Year = 4
            };
            Assert.IsInstanceOfType(repository.GetTimetable(groupRequest), typeof(WeekTimetable));
        }

        [TestMethod]
        public void When_TimetableRepositoryGetsGroupRequest_Then_ItReturnsTimetableTitle()
        {
            var repository = new TimetableRepository<GroupRequest>();
            var groupRequest = new GroupRequest
            {
                BaseAddress = "https://profs.info.uaic.ro/~orar",
                Group = "MIS1",
                Year = 4
            };
            Assert.AreEqual(repository.GetTimetable(groupRequest).Title,
                "Orar Master ingineria sistemelor soft, anul 1");
        }

        [TestMethod]
        public void When_TimetableRepositoryGetsMasterGroupRequest_Then_ItReturnsTimetableWithContent()
        {
            var repository = new TimetableRepository<GroupRequest>();
            var groupRequest = new GroupRequest
            {
                BaseAddress = "https://profs.info.uaic.ro/~orar",
                Group = "MIS1",
                Year = 4
            };
            Assert.AreEqual(repository.GetTimetable(groupRequest).Days[0].Entries.Count, 3);
        }

        [TestMethod]
        public void When_TimetableRepositoryGetsBachelorsGroupRequest_Then_ItReturnsTimetableWithContent()
        {
            var repository = new TimetableRepository<GroupRequest>();
            var groupRequest = new GroupRequest
            {
                BaseAddress = "https://profs.info.uaic.ro/~orar",
                Group = "I3A5",
                Year = 3
            };
            Assert.AreEqual(repository.GetTimetable(groupRequest).Days[0].Entries.Count, 4);
        }
    }
}