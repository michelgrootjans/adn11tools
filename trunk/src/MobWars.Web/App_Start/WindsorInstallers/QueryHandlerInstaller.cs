using Castle.Core;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MobWars.Core.Infrastructure;

namespace MobWars.Web.App_Start.WindsorInstallers
{
    public class QueryHandlerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IQueryHandlerFactory>()
                                   .AsFactory()
                                   .LifeStyle.Is(LifestyleType.Transient));

            container.Register(AllTypes.FromAssemblyContaining<IQueryHandler>()
                                   .BasedOn<IQueryHandler>().WithService.AllInterfaces()
                                   .Configure((h => h.LifeStyle.Is(LifestyleType.Transient))));
        }
    }
}