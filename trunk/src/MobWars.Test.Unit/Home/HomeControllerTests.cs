using System.Web.Mvc;
using MobWars.Core.Players;
using MobWars.Web.Controllers;
using NUnit.Framework;
using Rhino.Mocks;
using MobWars.Test.Unit.TestExtensions;

namespace MobWars.Test.Unit.Home
{
    [TestFixture]
    public class HomeControllerTest
    {
        private IGetPlayerInfoQueryHandler handler;
        private ActionResult result;
        private ViewPlayerInfoDto dto;

        [SetUp]
        public void SetUp()
        {
            dto = new ViewPlayerInfoDto();
            handler = MockRepository.GenerateMock<IGetPlayerInfoQueryHandler>();
            handler.Stub(h => h.HandleQuery()).Return(dto);

            result = new HomeController(handler).Index();
        }

        [Test]
        public void gets_data_from_handler()
        {
            handler.AssertWasCalled(h => h.HandleQuery());
        }

        [Test]
        public void returns_default_view()
        {
            result.ShouldShowDefaultView()
                .ShouldHaveModel(dto);
        }

    }
}