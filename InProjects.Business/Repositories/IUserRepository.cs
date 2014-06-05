using System.Linq;
using InProjects.Business.Models;

namespace InProjects.Business.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        User Login(string email, string password);

        User SearchUserBy(string nick, bool or, string email);

        User GetUserProfile(int userId);

        bool CreateNewUser(User newUser);

        bool EditUser(User editUser);

        bool DeleteUser(int userId);

        User Get(string email);
    }
}