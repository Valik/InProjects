using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using InProjects.Business.Models;
using InProjects.Business.Repositories;
using Ninject;

namespace InProjects.Business.Services.Auth
{
    public class AuthenticationService : IAuthenticationService
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private const string CookieName = "__AUTH_COOKIE";

        public HttpContext HttpContext { get; set; }

        [Inject]
        public IUserRepository UserRepository { get; set; }

        #region IAuthentication Members

        public User Login(string userName, string password, bool isPersistent)
        {
            User retUser = UserRepository.Login(userName, password);
            if (retUser != null)
            {
                CreateCookie(userName, isPersistent);
            }
            return retUser;
        }

        public User Login(string userName)
        {
            User retUser = UserRepository.Users.FirstOrDefault(p => string.Compare(p.Email, userName, true) == 0);
            if (retUser != null)
            {
                CreateCookie(userName);
            }
            return retUser;
        }

        private void CreateCookie(string userName, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                  1,
                  userName,
                  DateTime.Now,
                  DateTime.Now.Add(FormsAuthentication.Timeout),
                  isPersistent,
                  string.Empty,
                  FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            var authCookie = new HttpCookie(CookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            HttpContext.Response.Cookies.Set(authCookie);
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[CookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }

        private IPrincipal currentUser;

        public IPrincipal CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    try
                    {
                        var authCookie = HttpContext.Request.Cookies.Get(CookieName);
                        if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            currentUser = new UserProvider(ticket.Name, UserRepository);
                        }
                        else
                        {
                            currentUser = new UserProvider(null, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("Failed authentication: " + ex.Message);
                        currentUser = new UserProvider(null, null);
                    }
                }
                return currentUser;
            }
        }
        #endregion
    }
}