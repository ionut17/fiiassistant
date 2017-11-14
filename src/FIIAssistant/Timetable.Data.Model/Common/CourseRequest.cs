using System;

namespace Timetable.Data.Model.Common
{
    internal class CourseRequest : Request
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