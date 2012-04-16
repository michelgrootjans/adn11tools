using System;
using System.Web.Mvc;
using MobWars.Core.Battle;
using MobWars.Core.Infrastructure;
using MobWars.Test.Unit.TestExtensions;
using MobWars.Web.Controllers;
using NUnit.Framework;
using Rhino.Mocks;

namespace MobWars.Test.Unit.Battle
{
    [TestFixture]
    public abstract class BattleControllerTest
    {
        protected ICommandDispatcher dispatcher;
        protected IPlayerBattleQueryHandler handler;
        protected ActionResult result;

        [SetUp]
        public void SetUp()
        {
            dispatcher = MockRepository.GenerateMock<ICommandDispatcher>();
            handler = MockRepository.GenerateMock<IPlayerBattleQueryHandler>();
            Arrange();

            result = Act(new BattleController(dispatcher, handler));
        }

        protected virtual void Arrange()
        {
        }

        protected abstract ActionResult Act(BattleController controller);
    }

    public class BattleController_Index_Tests : BattleControllerTest
    {
        private BattleDto dto;

        protected override void Arrange()
        {
            dto = new BattleDto();
            handler.Stub(h => h.GetCurrentBattle()).Return(dto);
        }

        protected override ActionResult Act(BattleController controller)
        {
            return controller.Index();
        }

        [Test]
        public void should_get_data_from_handler()
        {
            handler.AssertWasCalled(h => h.GetCurrentBattle());
        }

        [Test]
        public void should_show_default_view()
        {
            result.ShouldShowDefaultView()
                .ShouldHaveModel(dto);
        }
    }

    public abstract class BattleController_Command_Test<TCommand> : BattleControllerTest where TCommand : ICommand
    {
        [Test]
        public void should_dispatch_command()
        {
            dispatcher.AssertWasCalled(d => d.Dispatch(Arg<TCommand>.Is.Anything));
        }

        [Test, Ignore]
        public void should_redirect_to_index()
        {
            //result.ShouldRedirectTo<BattleController>(c => c.Index());
        }
    }

    public class BattleController_StartEasyFight_Test : BattleController_Command_Test<StartEasyFightCommand>
    {
        protected override ActionResult Act(BattleController controller)
        {
            return controller.StartEasyFight();
        }
    }

    public class BattleController_StartNormalFight_Test : BattleController_Command_Test<StartRiskyFightCommand>
    {
        protected override ActionResult Act(BattleController controller)
        {
            return controller.StartRiskyFight();
        }
    }

    public class BattleController_StartDeadlyFight_Test : BattleController_Command_Test<StartDeadlyFightCommand>
    {
        protected override ActionResult Act(BattleController controller)
        {
            return controller.StartDeadlyFight();
        }
    }

    public class BattleController_Attack_Test : BattleController_Command_Test<AttackCommand>
    {
        protected override ActionResult Act(BattleController controller)
        {
            return controller.Attack();
        }
    }
}