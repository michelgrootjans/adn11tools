using System.Collections.Generic;
using MobWars.Core.Entities;
using MobWars.Core.Infrastructure;

namespace MobWars.Core.Players
{
    public class ViewPlayerInfoDtoMapper : AutomaticMapper<Player, ViewPlayerInfoDto>
    {
    }

    public class ViewItemDtoMapper : AutomaticMapper<Item, ViewItemDto>
    {
    }

    public class ViewPlayerInfoDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int HitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public int Life { get; set; }
        public int Gold { get; set; }
        public List<ViewItemDto> Inventory { get; set; }
    }

    public class ViewItemDto
    {
        public string Name { get; set; }
    }
}