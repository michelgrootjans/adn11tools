using MobWars.Core.Infrastructure;
using MobWars.Core.Queries;

namespace MobWars.Core.Battle
{
    public interface IPlayerBattleQueryHandler : IQueryHandler
    {
        BattleDto Handle();
    }

    public class PlayerBattleQueryHandler : IPlayerBattleQueryHandler
    {
        private readonly IGetCurrentPlayerDbQuery getCurrentPlayerQuery;
        private readonly IGenericMapper mapper;

        public PlayerBattleQueryHandler(IGetCurrentPlayerDbQuery getCurrentPlayerQuery, IGenericMapper mapper)
        {
            this.getCurrentPlayerQuery = getCurrentPlayerQuery;
            this.mapper = mapper;
        }

        public BattleDto Handle()
        {
            var player = getCurrentPlayerQuery.GetCurrentPlayer();
            var battle = new BattleDto
                             {
                                 IsOngoing = player.IsFighting,
                                 Player = mapper.Map(player).ToA<CharacterDto>()
                             };
            if (player.IsFighting)
                battle.Monster = mapper.Map(player.Adversary).ToA<CharacterDto>();

            return battle;
        }
    }
}