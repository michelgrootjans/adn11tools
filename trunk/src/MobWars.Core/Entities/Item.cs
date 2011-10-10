using System;

namespace MobWars.Core.Entities
{
    public abstract class Item
    {
        public virtual Guid Id { get; internal set; }
        public virtual Player Owner { get; internal set; }
        public virtual string Name { get; internal set; }
        public virtual int Price { get; internal set; }

        protected Item()
        {
        }

        protected Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Knife : Item
    {
        protected Knife(){}

        public Knife(string name, int price) : base(name, price)
        {
        }
    }

    public class Sword : Item
    {
        protected Sword(){}

        public Sword(string name, int price) : base(name, price)
        {
        }
    }

    public class Gun : Item
    {
        protected Gun(){}
        public Gun(string name, int price) : base(name, price)
        {
        }
    }
}