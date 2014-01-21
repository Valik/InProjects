using InProjects.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InProjects.Business
{
    public class UserService
    {
        private UserContext dbContext = new UserContext();

        public bool CreateNewUser(User newUser)
        {
            var users = dbContext.Users.FirstOrDefault(u => string.Compare(u.Nickname, newUser.Nickname, true) == 1);

            if (users != null)
                return false;

            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<User> SearchUsersByNick(string nickName)
        {
            var result = from user in dbContext.Users
                         where string.Compare(user.Nickname, nickName, true) == 1
                         select user;
            return result;
        }
    }
}