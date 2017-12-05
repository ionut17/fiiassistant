using System.Collections.Generic;

namespace Timetable.Data.Model.Common
{
    public class DayTimetable
    {
        public List<EntryTimetable> Entries = new List<EntryTimetable>();
        public string Title { get; set; }

        public string Day { get; set; }
    }
}