using MobWars.Core.Entities;
using MobWars.Core.Extensions;
using NHibernate;
using NHibernate.Criterion;

namespace MobWars.Core.Authentication
{
    public interface IMembershipProvider
    {
        bool ValidateUser(string username, string password);
    }

    public class MembershipProvider : IMembershipProvider
    {
        private readonly ISession session;

        public MembershipProvider(ISession session)
        {
            this.session = session;
        }

        public bool ValidateUser(string username, string password)
        {
            var player = session
                .CreateCriteria<Player>()
                .Add(Restrictions.Eq("Username", username))
                .Add(Restrictions.Eq("Password", password))
                .UniqueResult<Player>();

            return player.Exists();
        }
    }
}