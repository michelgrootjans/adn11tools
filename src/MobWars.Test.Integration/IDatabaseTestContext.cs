using NHibernate;

namespace MobWars.Test.Integration
{
    internal interface IDatabaseTestContext
    {
        ISession GetSession();
        void FlushAndClear();
        void Rollback();
    }
}