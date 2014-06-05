using System.Data.Entity;
using System.Globalization;
using System.Linq;
using InProjects.Business.Models;
using Ninject;

namespace InProjects.Business.Repositories
{
    public class UserRepository : IUserRepository
    {
        [Inject]
        public DataBaseContext DataBaseContext { get; set; }

        public IQueryable<User> Users
        {
            get { return DataBaseContext.Users; }
        }

        public User Get(string email)
        {
            var result = DataBaseContext.Users.FirstOrDefault(u => string.Compare(u.Email, email, true, CultureInfo.InvariantCulture) == 0);
            return result;
        }
        
        public User SearchUserBy(string nick, bool or, string email)
        {
            var result = DataBaseContext.Users.FirstOrDefault(
                u => or ? 
                        string.Compare(u.Nickname, nick, true, CultureInfo.InvariantCulture) == 0 ||
                        string.Compare(u.Email, email, true, CultureInfo.InvariantCulture) == 0
                        :
                        string.Compare(u.Nickname, nick, true, CultureInfo.InvariantCulture) == 0 &&
                        string.Compare(u.Email, email, true, CultureInfo.InvariantCulture) == 0
                );
            return result;
        }

        public User SearchUserByNickOrEmail(string nickOrEmail)
        {
            var result = DataBaseContext.Users.FirstOrDefault(
                u =>
                string.Compare(u.Nickname, nickOrEmail, true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(u.Email, nickOrEmail, true, CultureInfo.InvariantCulture) == 0
                );
            return result;
        }

        public User GetUserProfile(int userId)
        {
            var result = DataBaseContext.Users.Find(userId);
            return result;
        }

        public bool CreateNewUser(User newUser)
        {
            DataBaseContext.Users.Add(newUser);
            DataBaseContext.SaveChanges();
            return true;
        }

        public bool EditUser(User editUser)
        {
            DataBaseContext.Entry(editUser).State = EntityState.Modified;
            DataBaseContext.SaveChanges();
            return true;
        }

        public bool DeleteUser(int userId)
        {
            var user = GetUserProfile(userId);
            DataBaseContext.Users.Remove(user);
            DataBaseContext.SaveChanges();
            DataBaseContext.Entry(user).State = EntityState.Modified;
            DataBaseContext.SaveChanges();
            return true;
        }

        public User Login(string email, string password)
        {
            var result = DataBaseContext.Users.FirstOrDefault(u => string.Compare(u.Email, email, true) == 0 && u.Password == password) ;
            return result;
        }
    }
}