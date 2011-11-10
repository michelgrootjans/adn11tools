using MobWars.Core.Infrastructure;
using MobWars.Migrations.FakeRake;
using NHibernate;

namespace MobWars.Test.Integration
{
    public class DefaultConfigurationDatabaseTestContext : IDatabaseTestContext
    {
        private readonly ISession session;

        static DefaultConfigurationDatabaseTestContext()
        {
            new Rake().Execute("db:migrate", "test");
        }

        public DefaultConfigurationDatabaseTestContext()
        {
            session = NHibernateSessionProvider.SessionFactory.OpenSession();
            session.BeginTransaction();
        }

        public ISession GetSession()
        {
            return session;
        }

        public void FlushAndClear()
        {
            session.Flush();
            session.Clear();
        }

        public void Rollback()
        {
            session.Transaction.Rollback();
        }
    }
}