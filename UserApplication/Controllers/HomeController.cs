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
            UserRepository userRepo = new UserRepository();
            IList<User> users = userRepo.FindBy("name", "paul");

            ViewBag.users = users;
            return View();
        }
    }
}