using Microsoft.EntityFrameworkCore;
using Model.User.Entities;

namespace Repository.User {
    public class UserContext : DbContext {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Authentication> Authentications { get; set; }
    }
}