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
        public ActionResult Login(String username, String password)
        {
            return RedirectToAction("Index");
        }

        public ActionResult AllTest()
        {
            return View(db.Samples.ToList());
        }
        public ActionResult CreateUser()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateLabtech(FormCollection Form)
        {
            string role = Form["Role"];
            string fname = Form["FirstName"];
            string lname = Form["LastName"];
            string username = Form["UserName"];
            string password = Form["Password"];
            UserAuth newUser = new UserAuth();
            Employee newEmployee = new Employee();
            newUser.password = password;
            newUser.username = username;
            newUser.role = role;
            newEmployee.employeeFirstName = fname;
            newEmployee.employeeLastName = lname;
            newEmployee.title = role;
            db.UserAuths.Add(newUser);
            db.SaveChanges();
            newEmployee.authorizationID = newUser.authorizationID;
            db.Employees.Add(newEmployee);
            db.SaveChanges();
            return View();
        }
    }
}