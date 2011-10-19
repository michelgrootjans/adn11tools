using System.Web.Mvc;
using MobWars.Core.Infrastructure;
using MobWars.Core.Shop;
using MobWars.Test.Unit.TestExtensions;
using MobWars.Web.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace MobWars.Test.Unit.Shop
{
    [TestFixture]
    public abstract class ShopControllerTest
    {
        protected IViewShopQueryHandler handler;
        protected ICommandDispatcher dispatcher;
        protected ActionResult result;

        [SetUp]
        public void SetUp()
        {
            handler = MockRepository.GenerateMock<IViewShopQueryHandler>();
            dispatcher = MockRepository.GenerateMock<ICommandDispatcher>();
            Arrange();
            result = Act(new ShopController(handler, dispatcher));
        }

        protected virtual void Arrange()
        {
        }

        protected abstract ActionResult Act(ShopController controller);
    }

    public class ShopController_Index_Test : ShopControllerTest
    {
        private ViewShopDto dto;

        protected override void Arrange()
        {
            dto = new ViewShopDto();
            handler.Stub(h => h.HandleQuery()).Return(dto);
        }

        protected override ActionResult Act(ShopController controller)
        {
            return controller.Index();
        }

        [Test]
        public void should_get_data_from_the_handler()
        {
            handler.AssertWasCalled(h => h.HandleQuery());
        }

        [Test]
        public void should_show_view_with_data()
        {
            result.ShouldShowDefaultView()
                .ShouldHaveModel(dto);
        }
    }

    public class ShopController_Buy : ShopControllerTest
    {
        private BuyItemCommand command;

        protected override void Arrange()
        {
            command = new BuyItemCommand();
        }

        protected override ActionResult Act(ShopController controller)
        {
            return controller.Buy(command);
        }

        [Test]
        public void should_dispatch_the_command()
        {
            dispatcher.AssertWasCalled(d => d.Dispatch(command));
        }

        [Test, Ignore]
        public void should_redirect_to_shop()
        {
            //should redirect
        }
    }
}