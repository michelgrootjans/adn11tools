using NHibernate;
using NHibernate.Cfg;

namespace MobWars.Core.Infrastructure
{
    public static class NHibernateSessionProvider
    {
        public static ISessionFactory SessionFactory { get; private set; }

        static NHibernateSessionProvider()
        {
            var configuration = new Configuration().Configure();
            SessionFactory = configuration.BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}