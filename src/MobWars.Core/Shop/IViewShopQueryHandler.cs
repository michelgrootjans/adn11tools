using MobWars.Core.Infrastructure;
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
        private readonly IGetShopDbQuery shopQuery;
        private readonly IGenericMapper mapper;

        public ViewShopQueryHandler(IGetCurrentPlayerDbQuery playerQuery, IGetShopDbQuery shopQuery,
                                    IGenericMapper mapper)
        {
            this.playerQuery = playerQuery;
            this.shopQuery = shopQuery;
            this.mapper = mapper;
        }

        public ViewShopDto HandleQuery()
        {
            var items = shopQuery.GetItemsForSale();
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