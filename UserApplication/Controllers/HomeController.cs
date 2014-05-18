using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApplication.Models;
using UserApplication.Models.Repositories;

namespace UserApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            User user = new User();
            user.Name = "The Author";
            user.Email = "info@infinatic.de";

            UserRepository repository = new UserRepository();
            List<IEntity> users = repository.FindBy("name", "paul");

            ViewBag.user = user;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}