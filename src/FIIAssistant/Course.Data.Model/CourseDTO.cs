using System;

namespace Course.Data.Model
{
    public class CourseDTO
    {
        public CourseDTO()
        {

        }

        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Teacher { get; set; }

        public String Url { get; set; }

        public int Semester { get; set; }
    }
}
