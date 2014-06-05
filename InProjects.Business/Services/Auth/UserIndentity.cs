using System.Security.Principal;
using InProjects.Business.Models;
using InProjects.Business.Repositories;

namespace InProjects.Business.Services.Auth
{
    internal class UserIndentity : IIdentity
    {
        public User User { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Email;
                }
                //иначе аноним
                return "anonym";
            }
        }

        public void Init(string email, IUserRepository repository)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = repository.Get(email);
            }
        }
    }
}