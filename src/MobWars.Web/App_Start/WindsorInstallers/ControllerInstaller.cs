using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MobWars.Web.App_Start.WindsorInstallers
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                                   .BasedOn<IController>()
                                   .Configure(controller =>
                                                  {
                                                      controller.Named(controller.Implementation.Name);
                                                      controller.LifeStyle.Is(LifestyleType.Transient);
                                                  }));

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }

    internal class WindsorControllerFactory : IControllerFactory
    {
        private readonly IWindsorContainer container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            this.container = container;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            return container.Resolve<IController>(controllerName + "Controller");
        }

        public void ReleaseController(IController controller)
        {
            container.Release(controller);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }
    }

}