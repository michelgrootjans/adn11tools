using System.Web.Mvc;
using MobWars.Core.Players;

namespace MobWars.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IGetPlayerInfoQueryHandler getPlayerInfoQueryHandler;

        public HomeController(IGetPlayerInfoQueryHandler getPlayerInfoQueryHandler)
        {
            this.getPlayerInfoQueryHandler = getPlayerInfoQueryHandler;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var dto = getPlayerInfoQueryHandler.HandleQuery();
            return View(dto);
        }
    }
}