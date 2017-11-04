using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.Base
{
    public abstract class BaseIntegrationTest
    {
        protected virtual bool UseSqlServer => false;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            DestroyDatabase();
            CreateDatabase();
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {
            DestroyDatabase();
        }

        private void RunOnMemory(Action<DbContext> databaseAction)
        {
            var options = new DbContextOptionsBuilder<DbContext>()
                .UseInMemoryDatabase("FIIAssistant")
                .Options;

            using (var context = new DbContext(options))
            {
                databaseAction(context);
            }
        }

        private void RunOnSqlServer(Action<DbContext> databaseAction)
        {
            var connection = @"Server = .\SQLEXPRESS; Database = FIIAssistant.Development.Test; Trusted_Connection = True;";
            var options = new DbContextOptionsBuilder<DbContext>()
                .UseSqlServer(connection)
                .Options;

            using (var context = new DbContext(options))
            {
                databaseAction(context);
            }
        }

        protected void RunOnDatabase(Action<DbContext> databaseAction)
        {
            if (UseSqlServer)
            {
                RunOnSqlServer(databaseAction);
            }
            else
            {
                RunOnMemory(databaseAction);
            }
        }

        private void CreateDatabase()
        {
            RunOnDatabase(context => context.Database.EnsureCreated());
        }

        private void DestroyDatabase()
        {
            RunOnDatabase(context => context.Database.EnsureDeleted());
        }
    }
}
