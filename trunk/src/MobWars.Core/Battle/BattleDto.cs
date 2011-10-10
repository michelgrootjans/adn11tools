using System;
using MobWars.Core.Entities;
using MobWars.Core.Infrastructure;

namespace MobWars.Core.Battle
{
    public class BattleDto
    {
        public CharacterDto Player { get; set; }
        public CharacterDto Monster { get; set; }
        public bool IsOngoing { get; set; }

        public BattleDto()
        {
            IsOngoing = false;
            Player = new CharacterDto {Name = "you", HitPoints = 35, MaxHitPoints = 45, Life = 67};
            Monster = new CharacterDto {Name = "ugly guy", HitPoints = 25, MaxHitPoints = 55, Life = 33};
        }
    }

    public class CharacterDtoMapper : AutomaticMapper<Character, CharacterDto>
    {
    }

    public class CharacterDto
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public int Life { get; set; }
    }
}