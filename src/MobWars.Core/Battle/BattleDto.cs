using MobWars.Core.Entities;
using MobWars.Core.Infrastructure;

namespace MobWars.Core.Battle
{
    public class CharacterDtoMapper : AutomaticMapper<Character, CharacterDto>
    {
    }

    public class BattleDto
    {
        public CharacterDto Player { get; set; }
        public CharacterDto Monster { get; set; }
        public bool IsOngoing { get; set; }
    }

    public class CharacterDto
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public int Life { get; set; }
    }
}