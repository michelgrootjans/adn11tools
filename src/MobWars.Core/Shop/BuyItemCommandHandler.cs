using MobWars.Core.Entities;
using MobWars.Core.Infrastructure;
using MobWars.Core.Players;
using MobWars.Core.Queries;

namespace MobWars.Core.Shop
{
    public class BuyItemCommandHandler : ICommandHandler<BuyItemCommand>
    {
        public void Handle(BuyItemCommand command)
        {
            using (var session = NHibernateSessionProvider.SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player = new GetCurrentPlayerDbQuery(session).GetCurrentPlayer();
                var item = session.Get<Item>(command.ItemId);

                player.Buy(item);
                transaction.Commit();
            }
        }
    }
}