using System;
using Timetable.Data.Model.Common;

namespace Timetable.Data.Model.Common
{
    public class GroupTimetable : Timetable
    {

        public GroupTimetable() { }

        public GroupTimetable(string baseAddress) : base(baseAddress) { }

        public GroupTimetable(string baseAddress, string group, int year) : base(baseAddress)
        {
            Group = group;
            Year = year;
        }

        public string Group { get; set; }

        public int Year { get; set; }

        public new string GetAddress()
        {
            return String.IsNullOrEmpty(Group) ? BaseAddress : BaseAddress + "/participanti/orar_" + Group + ".html";
        }

    }
}