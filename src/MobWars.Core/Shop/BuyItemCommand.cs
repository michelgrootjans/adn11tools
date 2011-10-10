using System;
using MobWars.Core.Infrastructure;

namespace MobWars.Core.Shop
{
    public class BuyItemCommand : ICommand
    {
        public Guid ItemId { get; set; }
    }
}