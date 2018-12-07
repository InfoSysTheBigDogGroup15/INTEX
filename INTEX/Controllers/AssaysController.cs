using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INTEX.DAL;
using INTEX.Models;

namespace INTEX.Controllers
{
    public class AssaysController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Assays
        public ActionResult Index()
        {
            var assays = db.Assays.ToList();
            List<Client> findUser = db.Clients.ToList();
            Client found = new Client();
            foreach (Client c in findUser)
            {
                if (c.authorizationID == int.Parse(User.Identity.Name))
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
            ViewBag.UserL = found.clientLastName;
            return View(assays.ToList());
        }

        // GET: Assays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assay assay = db.Assays.Find(id);
            if (assay == null)
            {
                return HttpNotFound();
            }
            return View(assay);
        }

        // GET: Assays/Create
        public ActionResult Create()
        {
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientFirstName");
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName");
            ViewBag.discountID = new SelectList(db.Discounts, "discountID", "description");
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription");
            List<Client> findUser = db.Clients.ToList();
            Client found = new Client();
            foreach (Client c in findUser)
            {
                if (c.authorizationID == int.Parse(User.Identity.Name))
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
            ViewBag.UserL = found.clientLastName;
            
            return View();
        }

        // POST: Assays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "assayID,clientID,LTNumber,testID,discountID,comments,statusID,allowExtraTest")] Assay assay)
        {
            assay.statusID = 1;
            if (ModelState.IsValid)
            {
                db.Assays.Add(assay);
                db.SaveChanges();
                return View("somehting");
            }

            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientFirstName", assay.clientID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName", assay.LTNumber);
            ViewBag.discountID = new SelectList(db.Discounts, "discountID", "description", assay.discountID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription", assay.statusID);
            return RedirectToAction("Index","Home");
        }

        // GET: Assays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assay assay = db.Assays.Find(id);
            if (assay == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientFirstName", assay.clientID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName", assay.LTNumber);
            ViewBag.discountID = new SelectList(db.Discounts, "discountID", "description", assay.discountID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription", assay.statusID);
            return View(assay);
        }

        // POST: Assays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "assayID,clientID,LTNumber,testID,discountID,comments,statusID,allowExtraTest")] Assay assay)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(assay).State = EntityState.Modified;
                db.SaveChanges();
                return View("Edited1");
            }
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientFirstName", assay.clientID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName", assay.LTNumber);
            ViewBag.discountID = new SelectList(db.Discounts, "discountID", "description", assay.discountID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription", assay.statusID);
            return View("Edited1");
        }

        // GET: Assays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assay assay = db.Assays.Find(id);
            if (assay == null)
            {
                return HttpNotFound();
            }
            return View(assay);
        }

        // POST: Assays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assay assay = db.Assays.Find(id);
            db.Assays.Remove(assay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult somehting()
        {
            return View();
        }
        public ActionResult QuotesRecieved()
        {
            List<Assay> assayList = new List<Assay>();
            assayList = db.Assays.ToList();
            List<Assay> clientAssayList = new List<Assay>();
            foreach (Assay ass in assayList)
            {
                if (ass.statusID == 1)
                {
                    clientAssayList.Add(ass);
                }
            }

            return View(clientAssayList);
        }
        public ActionResult Client2Finalize(int? ClientIDss)
        {
            List<Client> client = db.Clients.ToList();
            int clientidd = 0;
            foreach (Client c in client)
            {
                if (c.authorizationID == ClientIDss)
                {
                    clientidd = c.clientID;
                }
            }
            List<Assay> assayList = new List<Assay>();
            assayList = db.Assays.ToList();
            List<Assay> clientAssayList = new List<Assay>();
            foreach (Assay ass in assayList)
            {
                if (ass.statusID == 2 && ass.clientID == clientidd)
                {
                    clientAssayList.Add(ass);
                }
            }
            List<Client> findUser = db.Clients.ToList();
            Client found = new Client();
            foreach (Client c in findUser)
            {
                if (c.authorizationID == int.Parse(User.Identity.Name))
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
            ViewBag.UserL = found.clientLastName;
            

            return View(clientAssayList);
        }
        public ActionResult WaitingCompounds(int? AuthIDs)
        {
            List<Assay> assayList = new List<Assay>();
            assayList = db.Assays.ToList();
            List<Assay> clientAssayList = new List<Assay>();
            foreach (Assay ass in assayList)
            {
                if (ass.statusID == 3)
                {
                    clientAssayList.Add(ass);
                }
            }
            List<Client> findUser = db.Clients.ToList();
            Client found = new Client();
            foreach (Client c in findUser)
            {
                if (c.authorizationID == AuthIDs)
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
            ViewBag.UserL = found.clientLastName;
            
            return View(clientAssayList);
        }
        public ActionResult WaitingToBeScheduled(int? AuthIDs)
        {
            List<Assay> assayList = new List<Assay>();
            assayList = db.Assays.ToList();
            List<Assay> clientAssayList = new List<Assay>();
            foreach (Assay ass in assayList)
            {
                if (ass.statusID == 4)
                {
                    clientAssayList.Add(ass);
                }
            }
            List<Client> findUser = db.Clients.ToList();
            Client found = new Client();
            foreach (Client c in findUser)
            {
                if (c.authorizationID == AuthIDs)
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
            ViewBag.UserL = found.clientLastName;
            return View(clientAssayList);

        }

       
        public ActionResult Scheduled()
        {
            List<Assay> assayList = new List<Assay>();
            assayList = db.Assays.ToList();
            List<Assay> clientAssayList = new List<Assay>();
            foreach (Assay ass in assayList)
            {
                if (ass.statusID == 5)
                {
                    clientAssayList.Add(ass);
                }
            }
            return View(clientAssayList);
        }
        public ActionResult FailedTests()
        {
            List<Assay> assayList = new List<Assay>();
            assayList = db.Assays.ToList();
            List<Assay> clientAssayList = new List<Assay>();
            foreach (Assay ass in assayList)
            {
                if (ass.statusID == 6)
                {
                    clientAssayList.Add(ass);
                }
            }
            return View(clientAssayList);
        }
        public ActionResult SuccessfulOrders()
        {
            List<Assay> assayList = new List<Assay>();
            assayList = db.Assays.ToList();
            List<Assay> clientAssayList = new List<Assay>();
            foreach (Assay ass in assayList)
            {
                if (ass.statusID == 7)
                {
                    clientAssayList.Add(ass);
                }
            }
            return View(clientAssayList);
        }

        public ActionResult ClientOrdersWaitingCompound(int? ClientIDss)
        {
            List<Client> client = db.Clients.ToList();
            int clientidd = 0;
            foreach (Client c in client)
            {
                if (c.authorizationID == int.Parse(User.Identity.Name))
                {
                    clientidd = c.clientID;
                }
            }
            List<Assay> assayList = new List<Assay>();
            assayList = db.Assays.ToList();
            List<Assay> clientAssayList = new List<Assay>();
            foreach (Assay ass in assayList)
            {
                if (ass.statusID == 3 && ass.clientID == clientidd)
                {
                    clientAssayList.Add(ass);
                }
            }

            return View(clientAssayList);
        }
        public ActionResult ClientOrdersWaitingSchedule(int? ClientIDss)
        {
            List<Client> client = db.Clients.ToList();
            int clientidd = 0;
            foreach (Client c in client)
            {
                if (c.authorizationID == int.Parse(User.Identity.Name))
                {
                    clientidd = c.clientID;
                }
            }
            List<Assay> assayList = new List<Assay>();
            assayList = db.Assays.ToList();
            List<Assay> clientAssayList = new List<Assay>();
            foreach (Assay ass in assayList)
            {
                if (ass.statusID == 4 && ass.clientID == clientidd)
                {
                    clientAssayList.Add(ass);
                }
            }

            return View(clientAssayList);
        }
        public ActionResult ClientOrdersScheduled(int? ClientIDss)
        {
            List<Client> client = db.Clients.ToList();
            int clientidd = 0;
            foreach (Client c in client)
            {
                if (c.authorizationID == int.Parse(User.Identity.Name))
                {
                    clientidd = c.clientID;
                }
            }
            List<Assay> assayList = new List<Assay>();
            assayList = db.Assays.ToList();
            List<Assay> clientAssayList = new List<Assay>();
            foreach (Assay ass in assayList)
            {
                if (ass.statusID == 5 && ass.clientID == clientidd)
                {
                    clientAssayList.Add(ass);
                }
            }

            return View(clientAssayList);
        }
        public ActionResult ClientFailedTests(int? ClientIDss)
        {
            List<Client> client = db.Clients.ToList();
            int clientidd = 0;
            foreach (Client c in client)
            {
                if (c.authorizationID == int.Parse(User.Identity.Name))
                {
                    clientidd = c.clientID;
                }
            }
            List<Assay> assayList = new List<Assay>();
            assayList = db.Assays.ToList();
            List<Assay> clientAssayList = new List<Assay>();
            foreach (Assay ass in assayList)
            {
                if (ass.statusID == 6 && ass.clientID == clientidd)
                {
                    clientAssayList.Add(ass);
                }
            }

            return View(clientAssayList);
        }
        public ActionResult ClientsCompletedOrders(int? ClientIDss)
        {
            List<Client> client = db.Clients.ToList();
            int clientidd = 0;
            foreach (Client c in client)
            {
                if (c.authorizationID == int.Parse(User.Identity.Name))
                {
                    clientidd = c.clientID;
                }
            }
            List<Assay> assayList = new List<Assay>();
            assayList = db.Assays.ToList();
            List<Assay> clientAssayList = new List<Assay>();
            foreach (Assay ass in assayList)
            {
                if (ass.statusID == 7 && ass.clientID == clientidd)
                {
                    clientAssayList.Add(ass);
                }
            }

            return View(clientAssayList);
        }


        public ActionResult Edited1()
        {
            return View();
        }
    }
}
    

