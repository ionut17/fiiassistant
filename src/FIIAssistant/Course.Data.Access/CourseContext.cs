using Course.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Course.Data.Access
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CourseDTO> Courses { get; set; }

        public DbSet<StudentCourseDTO> StudentCourses { get; set; }
    }
}