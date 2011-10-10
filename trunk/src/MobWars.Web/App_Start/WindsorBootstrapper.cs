using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MobWars.Web.App_Start;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof (WindsorBootstrapper), "PreStart")]
namespace MobWars.Web.App_Start
{
    public static class WindsorBootstrapper
    {
        public static void PreStart()
        {
            //var container = new WindsorContainer();

            //container.AddFacility<TypedFactoryFacility>();
            //container.Install(FromAssembly.This());
        }
    }
}