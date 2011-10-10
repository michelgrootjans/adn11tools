using System;
using System.Collections.Generic;
using MobWars.Core.Entities;
using MobWars.Core.Infrastructure;

namespace MobWars.Core.Shop
{
    public class ItemDtoMapper : AutomaticMapper<Item, ItemDto>
    {
    }

    public class ViewShopDto
    {
        public int Gold { get; set; }
        public List<ItemDto> Shop { get; set; }
        public List<ItemDto> Inventory { get; set; }
    }

    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}