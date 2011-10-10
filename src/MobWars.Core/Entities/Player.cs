using MobWars.Core.Extensions;

namespace MobWars.Core.Entities
{
    public class Player : Character
    {
        protected virtual int Experience { get; private set; }
        public virtual string Username { get; private set; }
        public virtual string Password { get; private set; }
        public virtual Character Adversary { get; private set; }

        protected Player()
        {
        }

        public Player(string username, string password, string name) : base(name)
        {
            Password = password;
            Username = username;
            Experience = 0;
            Level = 1;
            Attack = random.Next(4, 6);
            Defence = random.Next(4, 6);
            MaxHitPoints = random.Next(25, 30);
            Gold = 30;
        }

        public virtual void Buy(Item item)
        {
            if (item.Price > Gold) return;
            Gold -= item.Price;
            inventory.Add(item);
            item.Owner = this;
        }

        public virtual bool IsFighting
        {
            get { return Adversary.Exists() && Adversary.IsAlive; }
        }

        public virtual void StartFighting(Character monster)
        {
            Adversary = monster;
        }

        public virtual void AttackAdversary()
        {
            if (!IsFighting) return;
            Adversary.AddDamage(Attack - Adversary.Defence);
            if (Adversary.IsAlive)
                AddDamage(Adversary.Attack - Defence);
            else
                GetReward();
        }

        private void GetReward()
        {
            Gold += Adversary.Gold;
            Experience += Adversary.Level;
            if (MustLevel()) RaiseLevel();
            Adversary = null;
        }

        private bool MustLevel()
        {
            return Experience > Level*10;
        }

        private void RaiseLevel()
        {
            Level += 1;
            Attack += random.Next(4, 6);
            Defence += random.Next(4, 6);
            MaxHitPoints += random.Next(25, 30);
        }

        public virtual void Retreat()
        {
            if (!IsFighting) return;
            if (Adversary.IsAlive)
                AddDamage(Adversary.Attack - Defence);
            Adversary = null;
        }
    }
}