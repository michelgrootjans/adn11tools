using MobWars.Core.Entities;
using MobWars.Core.Infrastructure;
using MobWars.Core.Queries;

namespace MobWars.Core.Battle
{
    public class StarFightCommandHandler :
        ICommandHandler<StartEasyFightCommand>,
        ICommandHandler<StartRiskyFightCommand>,
        ICommandHandler<StartDeadlyFightCommand>
    {
        private readonly IGetCurrentPlayerDbQuery getPlayerQuery;

        public StarFightCommandHandler(IGetCurrentPlayerDbQuery getPlayerQuery)
        {
            this.getPlayerQuery = getPlayerQuery;
        }

        public void Handle(StartEasyFightCommand command)
        {
            StartFightAtLevel(0.8, "Certified .net developer");
        }

        public void Handle(StartRiskyFightCommand command)
        {
            StartFightAtLevel(1, "Grumpy Database Administrator");
        }

        public void Handle(StartDeadlyFightCommand command)
        {
            StartFightAtLevel(1.2, "Dangerous Non-coding Architect");
        }

        private void StartFightAtLevel(double levelFactor, string name)
        {
            var player = getPlayerQuery.GetCurrentPlayer();
            var monster = new Monster(levelFactor*player.Level, name);
            player.StartFighting(monster);
        }
    }
}