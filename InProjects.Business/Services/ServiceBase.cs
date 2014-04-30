using System.Linq;
using InProjects.Business.Models;

namespace InProjects.Business.Services
{
    public abstract class ServiceBase
    {
        protected static readonly DataBaseContext DbContext = new DataBaseContext();
        
        protected User GetUser()
        {
            #warning Cap method
            return DbContext.Users.FirstOrDefault();
        }
    }
}