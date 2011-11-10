using System.Linq;
using MobWars.Core.Entities;
using MobWars.Core.Extensions;
using NHibernate;

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
            var player = session.QueryOver<Player>()
                .Where(p => p.Username == username)
                .Where(p => p.Password == password)
                .List()
                .FirstOrDefault();

            return player.Exists();
        }
    }
}