using MobWars.Core.Extensions;
using NHibernate;
using NHibernate.Cfg;

namespace MobWars.Migrations.FakeRake
{
    internal class SeedDatabaseRakeCommand : IRakeCommand
    {
        protected static ISessionFactory sessionFactory;

        private static ISessionFactory GetSessionFactory()
        {
            if (sessionFactory.IsNull())
            {
                var configuration = new Configuration().Configure();
                sessionFactory = configuration.BuildSessionFactory();
            }
            return sessionFactory;
        }

        public void Execute()
        {
            using (var session = GetSessionFactory().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                new SeedHandler(session).Seed();
                transaction.Commit();
            }
        }
    }
}