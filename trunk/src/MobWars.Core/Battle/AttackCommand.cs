using MobWars.Core.Infrastructure;
using MobWars.Core.Players;
using MobWars.Core.Queries;

namespace MobWars.Core.Battle
{
    public class AttackCommand : ICommand
    {
    }

    public class AttackCommandHandler : ICommandHandler<AttackCommand>
    {
        private readonly IGetCurrentPlayerDbQuery getPlayerQuery;

        public AttackCommandHandler(IGetCurrentPlayerDbQuery getPlayerQuery)
        {
            this.getPlayerQuery = getPlayerQuery;
        }

        public void Handle(AttackCommand command)
        {
            using (var session = NHibernateSessionProvider.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player = getPlayerQuery.GetCurrentPlayer();
                player.AttackAdversary();
                transaction.Commit();
            }
        }
    }
}