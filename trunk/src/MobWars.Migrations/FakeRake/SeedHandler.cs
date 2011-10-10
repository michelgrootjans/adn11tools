using MobWars.Core.Entities;
using NHibernate;

namespace MobWars.Migrations.FakeRake
{
    internal class SeedHandler
    {
        private readonly ISession session;

        public SeedHandler(ISession session)
        {
            this.session = session;
        }

        internal void Seed()
        {
            session.Delete("from Player");
            session.Delete("from Item");
            session.Flush();
            session.Clear();

            var scott = new Player("scott", "tiger", "Scott Adams");
            scott.Buy(new Knife("Rusty knife", 2));
            scott.Buy(new Sword("Broken shortsword", 8));
            session.Save(scott);
            
            session.Save(new Sword("Rusty shortsword", 14));
            session.Save(new Sword("Shiny shortsword", 42));
        }
    }
}