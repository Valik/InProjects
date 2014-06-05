using System.Security.Principal;
using System.Web;
using InProjects.Business.Models;

namespace InProjects.Business.Services.Auth
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Конекст (тут мы получаем доступ к запросу и кукисам)
        /// </summary>
        HttpContext HttpContext { get; set; }

        User Login(string login, string password, bool isPersistent);

        User Login(string login);

        void LogOut();

        IPrincipal CurrentUser { get; }
    }
}