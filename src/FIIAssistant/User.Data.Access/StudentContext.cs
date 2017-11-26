using Microsoft.EntityFrameworkCore;
using User.Data.Model.Entities;

namespace User.Data.Access
{
    public sealed class StudentContext : DbContext, IStudentContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Authentication> Authentications { get; set; }
    }
}