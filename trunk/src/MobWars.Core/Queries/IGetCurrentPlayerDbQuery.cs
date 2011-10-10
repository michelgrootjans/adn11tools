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

        public GetCurrentPlayerDbQuery(ISession session)
        {
            this.session = session;
        }

        public Player GetCurrentPlayer()
        {
            return session
                .CreateCriteria<Player>()
                .Add(Restrictions.Eq("Username", "scott")) //I know, this isharcoded for the demo
                .UniqueResult<Player>();
        }
    }
}