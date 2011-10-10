using MobWars.Core.Entities;
using MobWars.Core.Extensions;
using MobWars.Core.Players;
using NHibernate.Criterion;

namespace MobWars.Core.Authentication
{
    public interface IMembershipProvider
    {
        bool ValidateUser(string username, string password);
    }

    public class MembershipProvider : IMembershipProvider
    {
        public bool ValidateUser(string username, string password)
        {
            using (var session = NHibernateSessionProvider.OpenSession())
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
}