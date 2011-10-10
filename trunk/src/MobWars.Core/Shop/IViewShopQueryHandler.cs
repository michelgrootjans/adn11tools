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
        private readonly IGetCurrentPlayerDbQuery playerQuery;
        private readonly IGenericMapper mapper;

        public ViewShopQueryHandler(IGetCurrentPlayerDbQuery playerQuery, IGenericMapper mapper)
        {
            this.playerQuery = playerQuery;
            this.mapper = mapper;
        }

        public ViewShopDto HandleQuery()
        {
            using (var session = NHibernateSessionProvider.SessionFactory.OpenSession())
            {
                var items = new GetShopDbQuery(session).GetItemsForSale();
                var player = playerQuery.GetCurrentPlayer();

                return new ViewShopDto
                           {
                               Gold = player.Gold,
                               Inventory = mapper.Map(player.Inventory).ToAListOf<ItemDto>(),
                               Shop = mapper.Map(items).ToAListOf<ItemDto>()
                           };
            }
        }
    }
}