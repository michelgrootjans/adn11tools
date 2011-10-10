using NHibernate;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;

namespace MobWars.Test.Integration
{
    public class InMemoryDatabaseTestContext<T> : IDatabaseTestContext
    {
        private static Configuration configuration;
        private static ISessionFactory sessionFactory;
        protected ISession session;

        internal InMemoryDatabaseTestContext()
        {
            if (sessionFactory != null) return;

            /// Initialize NHibernate and builds a session factory
            /// Note: this is a costly call so it will be executed only once.            
            configuration = new Configuration()
                .SetProperty(Environment.ReleaseConnections, "on_close")
                .SetProperty(Environment.Dialect, typeof(SQLiteDialect).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionDriver, typeof(SQLite20Driver).AssemblyQualifiedName)
                .SetProperty(Environment.ConnectionString, "data source=:memory:")
                .SetProperty(Environment.ProxyFactoryFactoryClass,
                             typeof(ProxyFactoryFactory).AssemblyQualifiedName)
                .AddAssembly(typeof(T).Assembly);

            sessionFactory = configuration.BuildSessionFactory();
        }

        public ISession GetSession()
        {
            // create a new NH session
            session = sessionFactory.OpenSession();

            // create a clean in mem database schema
            new SchemaExport(configuration).Execute(false, true, false, session.Connection, new NullOutputter());

            return session;
        }

        public void FlushAndClear()
        {
            session.Flush();
            session.Clear();
        }

        public void Rollback()
        {
            //not necessary, always starting with a clean database
            session.Transaction.Rollback();
        }
    }
}