using MobWars.Core.Infrastructure;
using MobWars.Core.Players;
using MobWars.Core.Queries;

namespace MobWars.Core.Battle
{
    public class RetreatCommand : ICommand
    {
    }

    public class RetreatCommandHandler : ICommandHandler<RetreatCommand>
    {
        private readonly IGetCurrentPlayerDbQuery playerQuery;

        public RetreatCommandHandler(IGetCurrentPlayerDbQuery playerQuery)
        {
            this.playerQuery = playerQuery;
        }

        public void Handle(RetreatCommand command)
        {
            using (var session = NHibernateSessionProvider.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player = playerQuery.GetCurrentPlayer();
                player.Retreat();
                transaction.Commit();
            }
        }
    }
}