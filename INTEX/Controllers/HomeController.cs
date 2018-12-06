using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INTEX.Models;
using INTEX.DAL;

namespace INTEX.Controllers
{
    public class HomeController : Controller
    {
        private NorthwestContext db = new NorthwestContext();
        public ActionResult Index()
        {
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

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string username = form["Username"];
            string password = form["Password"];
            //linear search
            //reroute find role send to dashboard
            return View();
        }
    }
}