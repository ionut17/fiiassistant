using Microsoft.EntityFrameworkCore;

namespace Server.Logger
{
    public class DatabaseLoggerContext : DbContext
    {
        public DatabaseLoggerContext()
        {
        }

        public DatabaseLoggerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LogMessage> LogMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EntityModel;Trusted_Connection=True;");
        }
    }
}