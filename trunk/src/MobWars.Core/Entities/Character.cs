using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Iesi.Collections.Generic;

namespace MobWars.Core.Entities
{
    public class Character
    {
        private int maxHitPoints;
        public Guid Id { get; private set; }
        public virtual string Name { get; private set; }
        public virtual int Level { get; protected set; }
        public virtual int HitPoints { get; protected set; }
        protected Iesi.Collections.Generic.ISet<Item> inventory;
        public virtual int Attack { get; protected set; }
        public virtual int Defence { get; protected set; }
        public virtual int Gold { get; protected set; }
        protected readonly Random random = new Random();

        protected Character()
        {
            inventory = new HashedSet<Item>();
        }

        protected Character(string name) : this()
        {
            Name = name;
        }


        public virtual int MaxHitPoints
        {
            get { return maxHitPoints; }
            protected set
            {
                maxHitPoints = value;
                HitPoints = value;
            }
        }


        public virtual IEnumerable<Item> Inventory
        {
            get { return new ReadOnlyCollection<Item>(inventory.ToList()); }
        }

        public int Life
        {
            get
            {
                if (IsDead) return 0;
                return HitPoints*100/MaxHitPoints;
            }
        }

        public virtual bool IsDead
        {
            get { return HitPoints <= 0 || MaxHitPoints == 0; }
        }

        public bool IsAlive
        {
            get { return !IsDead; }
        }

        protected internal virtual void AddDamage(int originalDamage)
        {
            var damage = random.Next(originalDamage - 2, originalDamage + 2);

            if (damage > 0)
                HitPoints -= damage;
            if (HitPoints <= 0)
                HitPoints = 0;
        }
    }
}