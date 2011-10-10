using System.Web.Mvc;
using MobWars.Core.Battle;
using MvcContrib.ActionResults;

namespace MobWars.Web.Controllers
{
    [Authorize]
    public class BattleController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var handler = new PlayerBattleQueryHandler();
            var battle = handler.Handle();
            return battle.IsOngoing
                       ? Fight(battle)
                       : View(battle);
        }

        private ActionResult Fight(BattleDto battle)
        {
            return View("Battle", battle);
        }

        [HttpPost]
        public ActionResult StartEasyFight()
        {
            new StarFightCommandHandler().Handle(new StartEasyFightCommand());
            return new RedirectToRouteResult<BattleController>(c => c.Index());
        }

        [HttpPost]
        public ActionResult StartRiskyFight()
        {
            new StarFightCommandHandler().Handle(new StartRiskyFightCommand());
            return new RedirectToRouteResult<BattleController>(c => c.Index());
        }

        [HttpPost]
        public ActionResult StartDeadlyFight()
        {
            new StarFightCommandHandler().Handle(new StartDeadlyFightCommand());
            return new RedirectToRouteResult<BattleController>(c => c.Index());
        }

        [HttpPost]
        public ActionResult Attack()
        {
            new AttackCommandHandler().Handle(new AttackCommand());
            return new RedirectToRouteResult<BattleController>(c => c.Index());
        }

        [HttpPost]
        public ActionResult Retreat()
        {
            new RetreatCommandHandler().Handle(new RetreatCommand());
            return new RedirectToRouteResult<BattleController>(c => c.Index());
        }
    }
}