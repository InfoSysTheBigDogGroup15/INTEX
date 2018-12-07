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
    public class ClientsController : Controller
    {
        private NorthwestContext db = new NorthwestContext();
        
        // GET: Clients
        public ActionResult Index()
        { 
            var clients = db.Clients.Include(c => c.Authorization);
            return View(clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.authorizationID = new SelectList(db.UserAuths, "authorizationID", "username");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Authentication.username, Authentication.password, clientID,clientFirstName,clientLastName,clientStreetAddress,clientCity,clientState,clientZip,clientPhoneNumber,clientEmail,clientCardNumber,clientCardCvc")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Edit", "UserAuth", client.authorizationID);
            }

            ViewBag.authorizationID = new SelectList(db.UserAuths, "authorizationID", "username", client.authorizationID);
            //return RedirectToAction("Edit", "UserAuth", client.authorizationID);
            return View();
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorizationID = new SelectList(db.UserAuths, "authorizationID", "username", client.authorizationID);
            return RedirectToAction("Edit1", "Assays");
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "clientID,clientFirstName,clientLastName,clientStreetAddress,clientCity,clientState,clientZip,clientPhoneNumber,clientEmail,clientCardNumber,clientCardCvc,authorizationID")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authorizationID = new SelectList(db.UserAuths, "authorizationID", "username", client.authorizationID);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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

        public ActionResult displayCustomerOrders(int? clientIDs)
        {   List<Client> client = db.Clients.ToList();
            int clientidd=0;
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
                if (ass.clientID == clientidd)
                {
                    clientAssayList.Add(ass);
                }
            }
            return View(clientAssayList);
        }
        // GET: Assays/Create
        public ActionResult ClientCreateAssay()
        {
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
            ViewBag.client = found;
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientFirstName");
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName");
            ViewBag.discountID = new SelectList(db.Discounts, "discountID", "description");
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription");
            return View();
        }

        // POST: Assays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientCreateAssay([Bind(Include = "assayID,clientID,LTNumber,testID,discountID,comments,statusID,allowExtraTest")] Assay assay)
        {
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
            assay.clientID = found.clientID;
            assay.statusID = 1;
            if (ModelState.IsValid)
            {
                db.Assays.Add(assay);
                db.SaveChanges();
                return View("ClientSuccesfulOrder");
            }

            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientFirstName", assay.clientID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName", assay.LTNumber);
            ViewBag.discountID = new SelectList(db.Discounts, "discountID", "description", assay.discountID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription", assay.statusID);
            return View("ClientSuccesfulOrder");
        }
        public ActionResult ClientSuccessfulOrder()
        {
            return View();
        }
        public ActionResult ClientCreated()
        {
            return View();
        }
    }
}
