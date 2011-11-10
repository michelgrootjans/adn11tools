using MobWars.Core.Infrastructure;
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
            var player = getPlayerQuery.GetCurrentPlayer();
            player.AttackAdversary();
        }
    }
}