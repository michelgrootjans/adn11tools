using MobWars.Core.Entities;
using MobWars.Core.Infrastructure;
using NHibernate;
using NHibernate.Criterion;

namespace MobWars.Core.Queries
{
    public interface IGetCurrentPlayerDbQuery
    {
        Player GetCurrentPlayer();
    }

    public class GetCurrentPlayerDbQuery : IGetCurrentPlayerDbQuery, INhibernateQuery
    {
        private readonly ISession session;
        private readonly IApplicationContext applicationContext;

        public GetCurrentPlayerDbQuery(ISession session, IApplicationContext applicationContext)
        {
            this.session = session;
            this.applicationContext = applicationContext;
        }

        public Player GetCurrentPlayer()
        {
            return session
                .CreateCriteria<Player>()
                .Add(Restrictions.Eq("Username", applicationContext.CurrentUserName))
                .UniqueResult<Player>();
        }
    }
}