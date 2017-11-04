using Microsoft.EntityFrameworkCore;
using User.Data.Model.Entities;

namespace User.Data.Access {
    public interface IUserContext {
        DbSet<Student> Students { get; set; }
        DbSet<Authentication> Authentications { get; set; }
        int SaveChanges();
    }
}