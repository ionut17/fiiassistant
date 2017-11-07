using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Timetable.Common;
using Timetable.Data.Model.Common;

namespace UnitTests.Timetable
{
    [TestClass]
    public class GroupTimetableTester : TimetableTester
    {

        [TestMethod]
        public void When_TimetableReceivesBaseAddressAndGroup_Then_AddressShouldBeValid()
        {
            var timetable = new GroupTimetable
            {
                BaseAddress = "https://profs.info.uaic.ro/~orar",
                Group = "MIS1",
                Year = 4
            };
            string address = timetable.GetAddress();
            Assert.AreEqual("https://profs.info.uaic.ro/~orar/participanti/orar_MIS1.html", address);
        }

    }
}
