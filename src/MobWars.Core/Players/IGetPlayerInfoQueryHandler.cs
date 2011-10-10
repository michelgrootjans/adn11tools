using System.Collections.Generic;
using System.Linq;
using MobWars.Core.Entities;
using MobWars.Core.Infrastructure;
using MobWars.Core.Queries;

namespace MobWars.Core.Players
{
    public interface IGetPlayerInfoQueryHandler : IQueryHandler
    {
        ViewPlayerInfoDto HandleQuery();
    }

    public class GetPlayerInfoQueryHandler : IGetPlayerInfoQueryHandler
    {
        public ViewPlayerInfoDto HandleQuery()
        {
            using (var session = NHibernateSessionProvider.OpenSession())
            {
                var player = new GetCurrentPlayerDbQuery(session)
                    .GetCurrentPlayer();
                return Map(player);
            }
        }

        private ViewPlayerInfoDto Map(Player player)
        {
            return new ViewPlayerInfoDto
                       {
                           Gold = player.Gold,
                           HitPoints = player.HitPoints,
                           Inventory = Map(player.Inventory),
                           Level = player.Level,
                           Life = player.Life,
                           MaxHitPoints = player.MaxHitPoints,
                           Name = player.Name,
                           Username = player.Username
                       };
        }

        private List<ViewItemDto> Map(IEnumerable<Item> items)
        {
            return items
                .Select(item => new ViewItemDto {Name = item.Name})
                .ToList();
        }
    }
}