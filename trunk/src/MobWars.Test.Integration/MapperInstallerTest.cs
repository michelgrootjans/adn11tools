using AutoMapper;
using Castle.Windsor;
using MobWars.Core.Infrastructure;
using MobWars.Web.App_Start.WindsorInstallers;
using NUnit.Framework;

namespace MobWars.Test.Integration
{
    [TestFixture]
    public class MapperInstallerTest
    {
        private IWindsorContainer container;

        [SetUp]
        public void SetUp()
        {
            container = new WindsorContainer()
                .Install(new MapperInstaller());
        }

        [Test]
        public void all_mappers_should_be_valid()
        {
            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void container_should_contain_a_few_mappers()
        {
            var mappers = container.ResolveAll<IMapperConfigurator>();
            Assert.That(mappers.Length, Is.GreaterThan(2));
        }

        [Test]
        public void container_should_contain_the_generic_mapper()
        {
            var mapper = container.Resolve<IGenericMapper>();
            Assert.That(mapper, Is.Not.Null);
        }

    }
}