using System.Collections.Generic;

namespace Timetable.Data.Model.Common
{
    public class WeekTimetable
    {
        public List<DayTimetable> Days = new List<DayTimetable>();
        public string Title { get; set; }
    }
}