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
    public class SamplesController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Samples
        public ActionResult Index()
        {
            var samples = db.Samples.Include(s => s.Assay).Include(s => s.Compound).Include(s => s.Status).Include(s => s.Test);
            return View(samples.ToList());
        }

        // GET: Samples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            return View(sample);
        }

        // GET: Samples/Create
        public ActionResult Create()
        {
            ViewBag.assayID = new SelectList(db.Assays, "assayID", "comments");
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName");
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription");
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName");
            return View();
        }

        // POST: Samples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sampleID,LTNumber,sequenceNumber,testID,statusID,testStatusDate,assayID")] Sample sample)
        {
            if (ModelState.IsValid)
            {
                db.Samples.Add(sample);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.assayID = new SelectList(db.Assays, "assayID", "comments", sample.assayID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName", sample.LTNumber);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription", sample.statusID);
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName", sample.testID);
            return View(sample);
        }

        // GET: Samples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            ViewBag.assayID = new SelectList(db.Assays, "assayID", "comments", sample.assayID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName", sample.LTNumber);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription", sample.statusID);
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName", sample.testID);
            return View(sample);
        }

        // POST: Samples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sampleID,LTNumber,sequenceNumber,testID,statusID,testStatusDate,assayID")] Sample sample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.assayID = new SelectList(db.Assays, "assayID", "comments", sample.assayID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName", sample.LTNumber);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription", sample.statusID);
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName", sample.testID);
            return View(sample);
        }

        // GET: Samples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sample sample = db.Samples.Find(id);
            if (sample == null)
            {
                return HttpNotFound();
            }
            return View(sample);
        }

        // POST: Samples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sample sample = db.Samples.Find(id);
            db.Samples.Remove(sample);
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
