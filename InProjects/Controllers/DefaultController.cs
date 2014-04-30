using InProjects.Business;
using System.Web.Mvc;

namespace InProjects.Controllers
{
    public class DefaultController : Controller
    {
        private DataBaseContext _dataBaseContext = new DataBaseContext();

        public ActionResult Index()
        {
            return View();
        }

    }
}
