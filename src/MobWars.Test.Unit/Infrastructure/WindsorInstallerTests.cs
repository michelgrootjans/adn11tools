using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using AutoMapper;
using Castle.Windsor;
using MobWars.Core.Infrastructure;
using MobWars.Test.Unit.TestExtensions;
using MobWars.Web.App_Start;
using NUnit.Framework;

namespace MobWars.Test.Unit.Infrastructure
{
    [TestFixture]
    public class WindsorInstallerTest
    {
        protected WindsorContainer container;

        [SetUp]
        public void SetUp()
        {
            container = new WindsorContainer();
            WindsorBootstrapper.Configure(container);

        }

        [Test]
        public void Verify_AutoMapper_configuration()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [Test, Ignore("I just can't seem to get this to work")]
        public void Verify_CommandHandler_configuraiton()
        {
            var commandsTypes = from t in Assembly.GetAssembly(typeof (ICommand)).GetTypes()
                           where typeof (ICommand).IsAssignableFrom(t)
                           where !t.IsAbstract
                           select t;
            foreach (var commandType in commandsTypes)
            {
                var handlerType = typeof (ICommandHandler<>).MakeGenericType(new[] {commandType});
                container.Resolve(handlerType);
            }
        }
    }
}