using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MobWars.Core.Infrastructure;
using MobWars.Core.Players;
using NHibernate;

namespace MobWars.Web.App_Start.WindsorInstallers
{
    public class NHibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ISessionFactory>()
                                   .UsingFactoryMethod(() => NHibernateSessionProvider.SessionFactory)
                                   .LifeStyle.Is(LifestyleType.Singleton));

            container.Register(Component.For<ISession>()
                                   .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
                                   .LifeStyle.Is(LifestyleType.PerWebRequest));

            container.Register(Component.For<NHibernateTransactionInterceptor>()
                                   .LifeStyle.Is(LifestyleType.Transient));

            container.Register(AllTypes.FromAssemblyContaining<INhibernateQuery>()
                                   .BasedOn<INhibernateQuery>()
                                   .WithService.AllInterfaces()
                                   .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)));

        }
    }
}