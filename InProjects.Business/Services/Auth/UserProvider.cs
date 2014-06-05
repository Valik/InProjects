using System;
using System.Security.Principal;
using InProjects.Business.Models;
using InProjects.Business.Repositories;

namespace InProjects.Business.Services.Auth
{
    internal class UserProvider : IPrincipal 
    {
        private UserIndentity userIdentity { get; set; }

        #region IPrincipal Members

        public IIdentity Identity
        {
            get
            {
                return userIdentity;
            }
        }

        public bool IsInRole(string role)
        {
            if (userIdentity.User == null)
            {
                return false;
            }
            RolesType roleType;
            if (!Enum.TryParse(role, true, out roleType))
            {
                return false;
            }
            var userRoles = userIdentity.User.Roles.RolesType;
            return userRoles.HasFlag(roleType);
        }

        #endregion


        public UserProvider(string name, IUserRepository repository)
        {
            userIdentity = new UserIndentity();
            userIdentity.Init(name, repository);
        }


        public override string ToString()
        {
            return userIdentity.Name;
        }
    }
}