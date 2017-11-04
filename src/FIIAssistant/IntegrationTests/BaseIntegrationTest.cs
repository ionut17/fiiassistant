using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests {
    public abstract class BaseIntegrationTest<TContext> where TContext : DbContext {
        protected virtual bool UseSqlServer => false;

        [TestInitialize]
        public virtual void TestInitialize() {
            DestroyDatabase();
            CreateDatabase();
        }

        [TestCleanup]
        public virtual void TestCleanup() {
            DestroyDatabase();
        }

        protected abstract void RunOnMemory(Action<TContext> databaseAction);

        protected abstract void RunOnSqlServer(Action<TContext> databaseAction);

        protected void RunOnDatabase(Action<TContext> databaseAction) {
            if (UseSqlServer)
                RunOnSqlServer(databaseAction);
            else
                RunOnMemory(databaseAction);
        }

        private void CreateDatabase() {
            RunOnDatabase(context => context.Database.EnsureCreated());
        }

        private void DestroyDatabase() {
            RunOnDatabase(context => context.Database.EnsureDeleted());
        }
    }
}