using Course.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Course.Data.Access
{
    public sealed class CourseContext : DbContext, ICourseContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentCourse>().HasKey(t => new {t.StudentId, t.CourseId});
        }

        public DbSet<Model.Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}