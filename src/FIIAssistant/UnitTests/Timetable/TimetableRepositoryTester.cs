using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timetable.Business.Repository;
using Timetable.Data.Model.Common;

namespace UnitTests.Timetable
{
    [TestClass]
    public class TimetableRepositoryTester
    {
        [TestMethod]
        public void When_TimetableRepositoryIsInstanciated_Then_ItReturnsGroupTable()
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
    }
}