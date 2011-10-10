using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MobWars.Core.Authentication;
using MobWars.Core.Infrastructure;

namespace MobWars.Web.App_Start.WindsorInstallers
{
    public class SecurityInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromAssemblyContaining<IMembershipProvider>()
                                   .BasedOn<IMembershipProvider>().WithService.Base()
                                   .Configure(p => p.LifeStyle.Transient
                                                    .Interceptors<NHibernateTransactionInterceptor>())
                );
        }
    }
}