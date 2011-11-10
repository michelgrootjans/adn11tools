using System.Collections.Generic;
using MobWars.Core.Entities;
using MobWars.Core.Infrastructure;
using NHibernate;

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
            return session.QueryOver<Item>()
                .Where(i => i.Owner != null)
                .Future();
        }
    }
}