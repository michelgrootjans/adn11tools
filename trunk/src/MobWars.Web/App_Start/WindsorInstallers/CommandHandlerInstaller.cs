using Castle.Core;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MobWars.Core.Infrastructure;

namespace MobWars.Web.App_Start.WindsorInstallers
{
    public class CommandHandlerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ICommandHandlerFactory>()
                                   .AsFactory()
                                   .LifeStyle.Is(LifestyleType.Transient));

            container.Register(Component.For<ICommandDispatcher>()
                                   .ImplementedBy<CommandDispatcher>()
                                   .LifeStyle.Is(LifestyleType.Transient));

            container.Register(AllTypes.FromAssemblyContaining(typeof (ICommandHandler<>))
                                   .BasedOn(typeof (ICommandHandler<>))
                                   .WithService.AllInterfaces()
                                   .Configure(h => h.LifeStyle.Is(LifestyleType.Transient)
                                                       .Interceptors<NHibernateTransactionInterceptor>()));
        }
    }
}