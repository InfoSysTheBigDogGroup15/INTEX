using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INTEX.Models;
using INTEX.DAL;
using System.Web.Security;

namespace INTEX.Controllers
{
    public class HomeController : Controller
    {
        //public Client current = new Client();
        private NorthwestContext db = new NorthwestContext();
        public ActionResult Index()
        {
            List<Client> findUser = db.Clients.ToList();
            Client found = new Client();
            foreach (Client c in findUser)
            { 
                if(c.authorizationID == int.Parse(User.Identity.Name))
                {
                    found = c;
                }
            }
            List<UserAuth> findUserA = db.UserAuths.ToList();
            UserAuth foundA = new UserAuth();
            foreach (UserAuth c in findUserA)
            {
                if (c.authorizationID == int.Parse(User.Identity.Name))
                {
                    foundA = c;
                }
            }
            //current = found;
            ViewBag.User = foundA.username;
            ViewBag.UserF = found.clientFirstName;
            ViewBag.UserL= found.clientLastName;
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
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            string username = form["Username"];
            string password = form["Password"];
            //linear search
            //reroute find role send to dashboard
            List<UserAuth> auths = db.UserAuths.ToList();
            bool YN = false;
            foreach (UserAuth auth in auths)
            {
                if (auth.username == username && auth.password == password)
                {   
                    FormsAuthentication.SetAuthCookie(auth.authorizationID.ToString(), rememberMe);
                    return RedirectToAction("Index","Home");
                }

                
            }
            return View();
        }

        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
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
        public ActionResult CreateEmployee(FormCollection Form)
        {
            string role = Form["Role"];
            string fname = Form["FirstName"];
            string lname = Form["LastName"];
            string username = Form["UserName"];
            string password = Form["Password"];
            string title = Form["Title"];
            UserAuth newUser = new UserAuth();
            Employee newEmployee = new Employee();
            
            newUser.password = password;
            newUser.username = username;
            newUser.role = role;
            newEmployee.employeeFirstName = fname;
            newEmployee.employeeLastName = lname;
            newEmployee.title = title;
            db.UserAuths.Add(newUser);
            db.SaveChanges();
            newEmployee.authorizationID = newUser.authorizationID;
            db.Employees.Add(newEmployee);
            db.SaveChanges();
            return RedirectToAction("Index", "Employees");
        }

        [HttpPost]
        public ActionResult CreateClient(FormCollection Form)
        {
            string fname = Form["FirstName"];
            string lname = Form["LastName"];
            string username = Form["UserName"];
            string password = Form["Password"];
            string address = Form["Address"];
            string city = Form["City"];
            string state = Form["State"];
            string zip = Form["Zip"];
            string phone = Form["Phone"];
            string email = Form["Email"];
            string card = Form["Card"];
            string cvc = Form["Cvc"];
            string role = Form["Role"];
            UserAuth newUser = new UserAuth();
            Client nc = new Client();
            newUser.password = password;
            newUser.username = username;
            newUser.role = role;
            nc.clientFirstName = fname;
            nc.clientLastName = lname;
            nc.clientStreetAddress = address;
            nc.clientCity = city;
            nc.clientState = state;
            nc.clientZip = zip;
            nc.clientPhoneNumber = phone;
            nc.clientEmail = email;
            nc.clientCardNumber = card;
            nc.clientCardCvc = cvc;
            db.UserAuths.Add(newUser);
            db.SaveChanges();
            nc.authorizationID = newUser.authorizationID;
            db.Clients.Add(nc);
            db.SaveChanges();
            return RedirectToAction("Index", "Clients");
        }
        //public ActionResult CreateClientUser(FormColle)
       
    }
}