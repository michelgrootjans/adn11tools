namespace MobWars.Core.Entities
{
    public class Monster : Character
    {
        protected Monster()
        {
        }

        public Monster(double levelFactor, string name) : base(name)
        {
            Level = Convert(levelFactor);
            MaxHitPoints = Convert(15*levelFactor);
            HitPoints = MaxHitPoints;
            Gold = Convert(15*levelFactor);
            Attack = Convert(4*levelFactor);
            Defence = Convert(3*levelFactor);
        }

        private int Convert(double levelFactor)
        {
            var correction = random.NextDouble() - 0.5;
            var conversion = levelFactor + (levelFactor*correction);
            return System.Convert.ToInt32(conversion);
        }
    }
}