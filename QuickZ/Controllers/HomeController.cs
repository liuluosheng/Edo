using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuickZ.Data.Entity;

namespace QuickZ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (QuickZDbContext db = new QuickZDbContext())
            {
                db.Users.Add(new Data.Entity.User {Name = "123"});
                db.SaveChanges();
            }
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