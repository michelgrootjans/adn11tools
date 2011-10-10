using MobWars.Core.Entities;
using MobWars.Core.Infrastructure;
using MobWars.Core.Players;
using MobWars.Core.Queries;

namespace MobWars.Core.Battle
{
    public interface IPlayerBattleQueryHandler : IQueryHandler
    {
        BattleDto Handle();
    }

    public class PlayerBattleQueryHandler : IPlayerBattleQueryHandler
    {
        public BattleDto Handle()
        {
            using (var session = NHibernateSessionProvider.OpenSession())
            {
                var player = new GetCurrentPlayerDbQuery(session).GetCurrentPlayer();
                var battle = new BattleDto
                                 {
                                     IsOngoing = player.IsFighting,
                                     Player = Map(player)
                                 };
                if (player.IsFighting)
                    battle.Monster = Map(player.Adversary);

                return battle;
            }
        }

        private CharacterDto Map(Character character)
        {
            return new CharacterDto
                       {
                           HitPoints = character.HitPoints,
                           Life = character.Life,
                           MaxHitPoints = character.MaxHitPoints,
                           Name = character.Name
                       };
        }
    }
}