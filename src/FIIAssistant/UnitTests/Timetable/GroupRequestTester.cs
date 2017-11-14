using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timetable.Business.Repository;
using UnitTests.Timetable.Common;
using Timetable.Data.Model.Common;

namespace UnitTests.Timetable
{
    [TestClass]
    public class GroupRequestTester
    {

        [TestMethod]
        public void When_TimetableReceivesOnlyBaseAddress_Then_AddressShouldBeValid()
        {
            var timetable = new GroupRequest
            {
                BaseAddress = "https://profs.info.uaic.ro/~orar"
            };
            string address = timetable.GetAddress();
            Assert.AreEqual("https://profs.info.uaic.ro/~orar", address);
        }

        [TestMethod]
        public void When_TimetableReceivesBaseAddressAndGroup_Then_AddressShouldBeValid()
        {
            var timetable = new GroupRequest
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
