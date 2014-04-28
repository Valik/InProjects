using InProjects.Business.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InProjects.Business.Repositories
{
    public class UserRepository : IUserRepository
    {
        [Inject]
        public UserContext UserContext { get; set; } 

        public User GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public User SearchUserByNickOrEmail(string nickOrEmail)
        {
            throw new NotImplementedException();
        }

        public User GetUserProfile(int userId)
        {
            throw new NotImplementedException();
        }

        public bool CreateNewUser(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}