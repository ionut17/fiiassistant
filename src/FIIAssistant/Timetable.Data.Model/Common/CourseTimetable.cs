using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Data.Model.Common
{
    class CourseTimetable : Timetable
    {

        public CourseTimetable(string course)
        {
            Course = course;
        }

        public string Course { get; set; }

    }
}
