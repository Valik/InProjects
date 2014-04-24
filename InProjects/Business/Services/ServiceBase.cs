using System;
using System.Linq;
using InProjects.Business.Models;

namespace InProjects.Business.Services
{
    public abstract class ServiceBase
    {
        protected static readonly UserContext DbContext = new UserContext();
        
        protected User GetUser()
        {
            #warning Cap method
            return DbContext.Users.FirstOrDefault();
        }
    }
}