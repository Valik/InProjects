using InProjects.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InProjects.Business.Repositories
{
    public interface IUserRepository
    {
        User GetCurrentUser();
        
        User SearchUserByNickOrEmail(string nickOrEmail);

        User GetUserProfile(int userId);

        bool CreateNewUser(User newUser);
    }
}