using System.Collections.Generic;
using System.Linq;
using MobWars.Core.Entities;
using MobWars.Core.Infrastructure;
using MobWars.Core.Players;
using MobWars.Core.Queries;

namespace MobWars.Core.Shop
{
    public interface IViewShopQueryHandler : IQueryHandler
    {
        ViewShopDto HandleQuery();
    }

    public class ViewShopQueryHandler : IViewShopQueryHandler
    {
        public ViewShopDto HandleQuery()
        {
            using (var session = NHibernateSessionProvider.SessionFactory.OpenSession())
            {
                var items = new GetShopDbQuery(session).GetItemsForSale();
                var player = new GetCurrentPlayerDbQuery(session).GetCurrentPlayer();

                return new ViewShopDto
                           {
                               Gold = player.Gold,
                               Inventory = Map(player.Inventory),
                               Shop = Map(items)
                           };
            }
        }

        private List<ItemDto> Map(IEnumerable<Item> inventory)
        {
            return inventory
                .Select(item => new ItemDto
                                    {
                                        Id = item.Id,
                                        Name = item.Name,
                                        Price = item.Price
                                    })
                .ToList();
        }
    }
}