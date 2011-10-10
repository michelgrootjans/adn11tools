using Castle.DynamicProxy;
using NHibernate;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace MobWars.Core.Infrastructure
{
    public class NHibernateTransactionInterceptor : IInterceptor
    {
        private readonly ISession session;

        public NHibernateTransactionInterceptor(ISession session)
        {
            this.session = session;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var transaction = session.BeginTransaction())
            {
                invocation.Proceed();
                transaction.Commit();
            }
        }
    }
}