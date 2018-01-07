using Course.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Course.Data.Access
{
    public interface ICourseContext
    {
        DbSet<Model.Course> Courses { get; set; }
        DbSet<StudentCourse> StudentCourses { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}