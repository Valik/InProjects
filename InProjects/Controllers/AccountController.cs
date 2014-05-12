using System;
using System.Web.Mvc;
using System.Web.Security;
using InProjects.Business.Mappers;
using InProjects.Business.Models;
using InProjects.Business.Models.ViewModels.Account;
using InProjects.Business.Repositories;
using InProjects.Models.Account;
using Ninject;

namespace InProjects.Controllers
{
    public class AccountController : Controller
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            // Lets first check if the Model is valid or not
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = UserRepository.SearchUserBy(model.Nickname, true, model.Email);
            if (user != null)
            {
                ModelState.AddModelError("Nickname", "The user with that name exist.");
                ModelState.AddModelError("Email", "The user with that email exist.");
                return View(model);
            }

            var newUser = Mapper.Map<User>(model);
            if (UserRepository.CreateNewUser(newUser))
            {
                return RedirectToAction("Index", "Default");
            }

            ModelState.AddModelError("", "Something wrong with this user data.");
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = UserRepository.SearchUserBy(model.NickOrEmail, true, model.NickOrEmail);
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
                return RedirectToAction("Index", "Default");
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Default");
        }
    }
}
