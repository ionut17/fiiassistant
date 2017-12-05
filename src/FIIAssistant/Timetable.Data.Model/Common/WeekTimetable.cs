using System.Collections.Generic;

namespace Timetable.Data.Model.Common
{
    public class WeekTimetable
    {
        public string Title { get; set; }

        public List<DayTimetable> Days = new List<DayTimetable>();
    }
}