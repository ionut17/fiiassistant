using Microsoft.EntityFrameworkCore;
using User.Data.Model.Entities;

namespace User.Data.Access
{
    public class UserContext : DbContext, IUserContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        { }


        public DbSet<Student> Students { get; set; }

        public DbSet<Authentication> Authentications { get; set; }
    }
}