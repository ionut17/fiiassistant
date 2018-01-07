using Microsoft.EntityFrameworkCore;
using User.Data.Model.Entities;

namespace User.Data.Access
{
    public interface IStudentContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Authentication> Authentications { get; set; }
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}