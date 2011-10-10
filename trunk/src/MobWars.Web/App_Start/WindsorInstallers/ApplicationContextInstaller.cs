using System.Web;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MobWars.Core.Infrastructure;

namespace MobWars.Web.App_Start.WindsorInstallers
{
    public class ApplicationContextInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<IApplicationContext>()
                .ImplementedBy<WebApplicationContext>()
                .LifeStyle.Is(LifestyleType.Transient));
        }
    }

    public class WebApplicationContext : IApplicationContext
    {
        public string CurrentUserName
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }
    }
}