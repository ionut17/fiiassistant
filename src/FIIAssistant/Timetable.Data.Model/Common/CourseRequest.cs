using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Data.Model.Common
{
    class CourseRequest : Request
    {

        public CourseRequest(string course)
        {
            Course = course;
        }

        public string Course { get; set; }

        public override string GetAddress()
        {
            throw new NotImplementedException();
        }
    }
}
