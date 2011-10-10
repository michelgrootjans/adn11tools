using MobWars.Core.Entities;
using MobWars.Core.Infrastructure;
using MobWars.Core.Queries;
using NHibernate;

namespace MobWars.Core.Shop
{
    public class BuyItemCommandHandler : ICommandHandler<BuyItemCommand>
    {
        private readonly IGetCurrentPlayerDbQuery playerQuery;
        private readonly ISession session;

        public BuyItemCommandHandler(IGetCurrentPlayerDbQuery playerQuery, ISession session)
        {
            this.playerQuery = playerQuery;
            this.session = session;
        }

        public void Handle(BuyItemCommand command)
        {
            var player = playerQuery.GetCurrentPlayer();
            var item = session.Get<Item>(command.ItemId);

            player.Buy(item);
        }
    }
}