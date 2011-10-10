using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MobWars.Core.Infrastructure;

namespace MobWars.Web.App_Start.WindsorInstallers
{
    public class MapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                                   .For<IGenericMapper>()
                                   .ImplementedBy<GenericMapper>()
                                   .LifeStyle.Is(LifestyleType.Transient));

            container.Register(AllTypes.FromAssemblyContaining<IMapperConfigurator>()
                                   .BasedOn(typeof (IMapperConfigurator))
                                   .WithService.AllInterfaces()
                                   .Configure(m => m.LifeStyle.Is(LifestyleType.Singleton)));

            var allMappers = container.ResolveAll<IMapperConfigurator>();
            foreach (var configurator in allMappers)
            {
                configurator.Configure();
            }
        }
    }
}