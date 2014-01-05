using InProjects.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InProjects.Controllers
{
    public class DefaultController : Controller
    {
        private UserContext userContext = new UserContext();

        public ActionResult Index()
        {
            return View();
        }

    }
}
