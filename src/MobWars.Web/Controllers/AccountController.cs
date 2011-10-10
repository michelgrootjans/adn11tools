using System.Web.Mvc;
using System.Web.Security;
using MobWars.Web.Models;
using MvcContrib;
using MembershipProvider = MobWars.Core.Authentication.MembershipProvider;

namespace MobWars.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly MembershipProvider membershipProvider;

        public AccountController(MembershipProvider membershipProvider)
        {
            this.membershipProvider = membershipProvider;
        }

        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (membershipProvider.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    return this.RedirectToAction<HomeController>(c => c.Index());
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToAction<HomeController>(c => c.Index());
        }
    }
}