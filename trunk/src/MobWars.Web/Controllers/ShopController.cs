using System.Web.Mvc;
using MobWars.Core.Shop;
using MvcContrib.ActionResults;

namespace MobWars.Web.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var handler = new ViewShopQueryHandler();
            var dto = handler.HandleQuery();
            return View(dto);
        }

        [HttpPost]
        public ActionResult Buy(BuyItemCommand command)
        {
            new BuyItemCommandHandler().Handle(command);
            return new RedirectToRouteResult<ShopController>(c => c.Index());
        }
    }
}