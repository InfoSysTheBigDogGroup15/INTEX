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
            var assays = db.Assays.Include(a => a.Client).Include(a => a.Compound).Include(a => a.Discount).Include(a => a.Status);
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
                return RedirectToAction("ClientSuccessfulOrder", "Clients");
            }

            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientFirstName", assay.clientID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName", assay.LTNumber);
            ViewBag.discountID = new SelectList(db.Discounts, "discountID", "description", assay.discountID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription", assay.statusID);
            return RedirectToAction("ClientSuccessfulOrder", "Clients");
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
                return RedirectToAction("Index");
            }
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientFirstName", assay.clientID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName", assay.LTNumber);
            ViewBag.discountID = new SelectList(db.Discounts, "discountID", "description", assay.discountID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription", assay.statusID);
            return View(assay);
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

      
    }
}
