using System.Linq;
using InProjects.Business.Models;

namespace InProjects.Business.Services
{
    public class UserService : ServiceBase
    {

        public User GetUserProfile(int userId)
        {
            var user = DbContext.Users.FirstOrDefault(u => u.UserId == userId);
            return user;
        }

        public bool CreateNewUser(User newUser)
        {
            var users = DbContext.Users.FirstOrDefault(u => string.Compare(u.Nickname, newUser.Nickname, true) == 1);

            if (users != null)
                return false;

            DbContext.Users.Add(newUser);
            DbContext.SaveChanges();
            return true;
        }

        public void AddTag(Tag tag)
        {
            var user = GetUser();
            user.Tags.Add(tag);

            DbContext.Users.Attach(user);
            DbContext.Entry(user).Property(u => u.Tags).IsModified = true;
            DbContext.SaveChanges();
        }


    }
}