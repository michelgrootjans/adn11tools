using System.Web.Mvc;
using MobWars.Core.Players;

namespace MobWars.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var dto = new GetPlayerInfoQueryHandler().HandleQuery();
            return View(dto);
        }
    }
}