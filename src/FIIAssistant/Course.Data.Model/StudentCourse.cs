using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course.Data.Model
{
    public class StudentCourse
    {
        [Column(Order = 0), Key]
        public Guid StudentId { get; set; }
        [Column(Order = 1), Key, ForeignKey("Course")]
        public Guid CourseId { get; set; }
    }
}