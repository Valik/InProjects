using System;
using System.Web.Mvc;
using System.Web.Security;
using InProjects.Business.Repositories;
using InProjects.Business.Services;
using InProjects.Models.Account;
using Ninject;

namespace InProjects.Controllers
{
    public class AccountController : Controller
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (ModelState.IsValid)
            {
                var user = UserRepository.SearchUserByNickOrEmail(model.NickOrEmail);
                var userValid = user != null &&
                                 string.Compare(user.Password, model.Password, StringComparison.InvariantCulture) == 0;
                // User found in the database
                if (userValid)
                {
                    FormsAuthentication.SetAuthCookie(user.Nickname, false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Default");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Default");
        }
    }
}
