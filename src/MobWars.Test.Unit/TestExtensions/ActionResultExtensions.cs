using System.Web.Mvc;
using NUnit.Framework;

namespace MobWars.Test.Unit.TestExtensions
{
    public static class ActionResultExtensions
    {
        public static ViewResult ShouldShowDefaultView(this ActionResult actionResult)
        {
            Assert.That(actionResult, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)actionResult;
            Assert.That(viewResult.ViewName, Is.EqualTo(""));
            return viewResult;
        }

        public static ViewResult ShouldHaveModel<T>(this ViewResult viewResult, T expectedModel)
        {
            Assert.That(viewResult.Model, Is.SameAs(expectedModel));
            return viewResult;
        }
    }
}