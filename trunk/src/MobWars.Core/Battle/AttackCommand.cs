using System;
using MobWars.Core.Infrastructure;
using MobWars.Core.Players;
using MobWars.Core.Queries;

namespace MobWars.Core.Battle
{
    public class AttackCommand : ICommand
    {
        
    }

    public class AttackCommandHandler : ICommandHandler<AttackCommand>
    {
        public void Handle(AttackCommand command)
        {
            using (var session = NHibernateSessionProvider.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var player = new GetCurrentPlayerDbQuery(session).GetCurrentPlayer();
                player.AttackAdversary();
                transaction.Commit();
            }
        }
    }
}