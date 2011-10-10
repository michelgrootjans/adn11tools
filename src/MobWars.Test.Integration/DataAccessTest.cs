using NHibernate;
using NUnit.Framework;

namespace MobWars.Test.Integration
{
    public abstract class DataAccessTest
    {
        private IDatabaseTestContext databaseTestContext;
        protected ISession session;

        [SetUp]
        public void SetUp()
        {
            databaseTestContext = new DefaultConfigurationDatabaseTestContext();
            session = databaseTestContext.GetSession();
            PrepareData();
            FlushAndClear();
        }

        [TearDown]
        public void TearDown()
        {
            databaseTestContext.Rollback();
        }

        protected abstract void PrepareData();

        protected void FlushAndClear()
        {
            databaseTestContext.FlushAndClear();
        }
    }
}