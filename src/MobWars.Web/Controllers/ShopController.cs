using System.Web.Mvc;
using MobWars.Core.Infrastructure;
using MobWars.Core.Shop;
using MvcContrib.ActionResults;

namespace MobWars.Web.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        readonly IViewShopQueryHandler handler;
        private readonly ICommandDispatcher dispatcher;

        public ShopController(IViewShopQueryHandler handler, ICommandDispatcher dispatcher)
        {
            this.handler = handler;
            this.dispatcher = dispatcher;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var dto = handler.HandleQuery();
            return View(dto);
        }

        [HttpPost]
        public ActionResult Buy(BuyItemCommand command)
        {
            dispatcher.Dispatch(command);
            return new RedirectToRouteResult<ShopController>(c => c.Index());
        }
    }
}