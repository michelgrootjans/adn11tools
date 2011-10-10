using System.Linq;
using MobWars.Core.Entities;
using NHibernate.Criterion;
using NUnit.Framework;
using FluentAssertions;

namespace MobWars.Test.Integration
{
    [TestFixture]
    public class PlayerCrudTest : DataAccessTest
    {
        protected override void PrepareData()
        {
            session.Save(new Player("scott", "tiger", "Scott Adams"));
        }

        [Test]
        public void should_be_able_to_get_Scott()
        {
            var scott = GetPlayer("scott");
            scott.Name.Should().Be("Scott Adams");
            scott.Username.Should().Be("scott");
        }

        [Test]
        public void player_should_not_have_items()
        {
            var scott = GetPlayer("scott");
            scott.Inventory.Count().Should().Be(0);
        }

        [Test]
        public void player_should_be_able_to_buy_an_item()
        {
            var scott = GetPlayer("scott");
            scott.Buy(new Knife("Rusty knife", 3));
            FlushAndClear();

            var scottFromDb = GetPlayer("scott");
            scott.Inventory.Count().Should().Be(1);
            
            var knife = scottFromDb.Inventory.First();
            knife.Should().BeAssignableTo<Knife>();
            knife.Name.Should().Be("Rusty knife");
            knife.Price.Should().Be(3);
        }

        [Test]
        public void player_should_not_be_fighting()
        {
            var scott = GetPlayer("scott");
            scott.IsFighting.Should().BeFalse();
        }

        [Test]
        public void player_should_be_able_to_fight()
        {
            var scott = GetPlayer("scott");
            scott.StartFighting(new Monster(1, "monster"));
            session.Flush();
            session.Clear();

            GetPlayer("scott").IsFighting.Should().BeTrue();
        }

        private Player GetPlayer(string username)
        {
            return session
                .CreateCriteria<Player>()
                .Add(Restrictions.Eq("Username", username))
                .UniqueResult<Player>();
        }
    }
}