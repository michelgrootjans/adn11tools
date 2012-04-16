using System.Web.Mvc;
using MobWars.Core.Battle;
using MobWars.Core.Infrastructure;
using MvcContrib.ActionResults;

namespace MobWars.Web.Controllers
{
    [Authorize]
    public class BattleController : Controller
    {
        private readonly ICommandDispatcher dispatcher;
        private readonly IPlayerBattleQueryHandler battleQuery;

        public BattleController(ICommandDispatcher dispatcher, IPlayerBattleQueryHandler battleQuery)
        {
            this.dispatcher = dispatcher;
            this.battleQuery = battleQuery;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var battle = battleQuery.GetCurrentBattle();
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
            dispatcher.Dispatch(new StartEasyFightCommand());
            return new RedirectToRouteResult<BattleController>(c => c.Index());
        }

        [HttpPost]
        public ActionResult StartRiskyFight()
        {
            dispatcher.Dispatch(new StartRiskyFightCommand());
            return new RedirectToRouteResult<BattleController>(c => c.Index());
        }

        [HttpPost]
        public ActionResult StartDeadlyFight()
        {
            dispatcher.Dispatch(new StartDeadlyFightCommand());
            return new RedirectToRouteResult<BattleController>(c => c.Index());
        }

        [HttpPost]
        public ActionResult Attack()
        {
            dispatcher.Dispatch(new AttackCommand());
            return new RedirectToRouteResult<BattleController>(c => c.Index());
        }

        [HttpPost]
        public ActionResult Retreat()
        {
            dispatcher.Dispatch(new RetreatCommand());
            return new RedirectToRouteResult<BattleController>(c => c.Index());
        }
    }
}