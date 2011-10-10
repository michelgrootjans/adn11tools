using System.Collections.Generic;
using MobWars.Core.Entities;
using MobWars.Core.Infrastructure;
using NHibernate;
using NHibernate.Criterion;

namespace MobWars.Core.Queries
{
    public interface IGetShopDbQuery
    {
        IEnumerable<Item> GetItemsForSale();
    }

    public class GetShopDbQuery : IGetShopDbQuery, INhibernateQuery
    {
        private readonly ISession session;

        public GetShopDbQuery(ISession session)
        {
            this.session = session;
        }

        public IEnumerable<Item> GetItemsForSale()
        {
            return session
                .CreateCriteria<Item>()
                .Add(Restrictions.IsNull("Owner"))
                .Future<Item>();
        }
    }
}