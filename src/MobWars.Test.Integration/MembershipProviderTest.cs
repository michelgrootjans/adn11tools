using System;
using MobWars.Core.Authentication;
using MobWars.Core.Entities;
using NUnit.Framework;
using FluentAssertions;

namespace MobWars.Test.Integration
{
    [TestFixture]
    public class MembershipProviderTest : DataAccessTest
    {
        private MembershipProvider provider;

        protected override void PrepareData()
        {
            session.Save(new Player("scott", "tiger", "Scotty"));
            provider = new MembershipProvider(session);
        }

        [Test]
        public void validates_valid_user()
        {
            provider.ValidateUser("scott", "tiger").Should().BeTrue();
        }

        [Test]
        public void doesnt_validate_wrong_username()
        {
            provider.ValidateUser("wrong", "tiger").Should().BeFalse();
        }

        [Test]
        public void doesnt_validate_wrong_password()
        {
            provider.ValidateUser("scott", "wrong").Should().BeFalse();
        }

    }
}