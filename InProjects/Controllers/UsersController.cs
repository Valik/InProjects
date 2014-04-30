using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InProjects.Business.Models;
using InProjects.Business.Repositories;
using Ninject;

namespace InProjects.Controllers
{
    public class UsersController : Controller
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        public ActionResult Index()
        {
            var users = UserRepository.Users;
            return View(users.ToList());
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id = 0)
        {
            var user = UserRepository.GetUserProfile(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                if (UserRepository.CreateNewUser(user))
                {
                    return RedirectToAction("Index");
                }
                throw new HttpException((int)HttpStatusCode.BadRequest, "Can't create this user");
            }

            return View(user);
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var user = UserRepository.GetUserProfile(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                if (UserRepository.EditUser(user))
                {
                    return RedirectToAction("Index");
                }
                throw new HttpException((int)HttpStatusCode.BadRequest, "Can't edit this user");
            }
            return View(user);
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var user = UserRepository.GetUserProfile(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (UserRepository.DeleteUser(id))
            {
                return RedirectToAction("Index");
            }
            throw new HttpException((int)HttpStatusCode.BadRequest, "Can't delete this user");
        }
    }
}