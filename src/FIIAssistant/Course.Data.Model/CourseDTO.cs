using System;

namespace Course.Data.Model
{
    public class CourseDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Teacher { get; set; }

        public string Url { get; set; }

        public int Semester { get; set; }
    }
}