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
    public class CompoundsController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Compounds
        public ActionResult Index()
        {
            var compounds = db.Compounds.Include(c => c.Employee);
            return View(compounds.ToList());
        }

        // GET: Compounds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound compound = db.Compounds.Find(id);
            if (compound == null)
            {
                return HttpNotFound();
            }
            return View(compound);
        }

        // GET: Compounds/Create
        public ActionResult Create()
        {
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeFirstName");
            return View();
        }

        // POST: Compounds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LTNumber,compoundName,compoundQuantity,dateArrived,employeeID,dateDue,appearance,weight,actualWeight,maximumToleratedDose,confirmationSentOutDate")] Compound compound)
        {
            if (ModelState.IsValid)
            {
                db.Compounds.Add(compound);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeFirstName", compound.employeeID);
            return View(compound);
        }

        // GET: Compounds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound compound = db.Compounds.Find(id);
            if (compound == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeFirstName", compound.employeeID);
            return View(compound);
        }

        // POST: Compounds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LTNumber,compoundName,compoundQuantity,dateArrived,employeeID,dateDue,appearance,weight,actualWeight,maximumToleratedDose,confirmationSentOutDate")] Compound compound)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compound).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeFirstName", compound.employeeID);
            return View(compound);
        }

        // GET: Compounds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound compound = db.Compounds.Find(id);
            if (compound == null)
            {
                return HttpNotFound();
            }
            return View(compound);
        }

        // POST: Compounds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compound compound = db.Compounds.Find(id);
            db.Compounds.Remove(compound);
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
