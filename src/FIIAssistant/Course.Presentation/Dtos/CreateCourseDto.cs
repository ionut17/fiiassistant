using System.ComponentModel.DataAnnotations;

namespace Course.Presentation.Dtos
{
    public class CreateCourseDto
    {
        public string Name { get; set; }

        public string Teacher { get; set; }

        [Url]
        public string Url { get; set; }

        [Range(1,6)]
        public int Semester { get; set; }
    }
}
