using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using QuickZ.Data.Entity;
using QuickZ.Service;

namespace QuickZ.Controllers
{
    public class HomeController : Controller
    {

        public  UserService UserService;

        public HomeController(UserService userService)
        {
            UserService = userService;
        }

        public ActionResult Index()
        {

            UserService.Repository.Insert(new Data.Entity.User { Name = "刘罗生" });
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