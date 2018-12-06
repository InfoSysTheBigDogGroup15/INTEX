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
    public class Test_TubeController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Test_Tube
        public ActionResult Index()
        {
            var test_Tube = db.Test_Tube.Include(t => t.Test);
            return View(test_Tube.ToList());
        }

        // GET: Test_Tube/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Tube test_Tube = db.Test_Tube.Find(id);
            if (test_Tube == null)
            {
                return HttpNotFound();
            }
            return View(test_Tube);
        }

        // GET: Test_Tube/Create
        public ActionResult Create()
        {
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName");
            return View();
        }

        // POST: Test_Tube/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "testTubeID,concentration,testID")] Test_Tube test_Tube)
        {
            if (ModelState.IsValid)
            {
                db.Test_Tube.Add(test_Tube);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.testID = new SelectList(db.Tests, "testID", "testName", test_Tube.testID);
            return View(test_Tube);
        }

        // GET: Test_Tube/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Tube test_Tube = db.Test_Tube.Find(id);
            if (test_Tube == null)
            {
                return HttpNotFound();
            }
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName", test_Tube.testID);
            return View(test_Tube);
        }

        // POST: Test_Tube/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "testTubeID,concentration,testID")] Test_Tube test_Tube)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test_Tube).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName", test_Tube.testID);
            return View(test_Tube);
        }

        // GET: Test_Tube/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Tube test_Tube = db.Test_Tube.Find(id);
            if (test_Tube == null)
            {
                return HttpNotFound();
            }
            return View(test_Tube);
        }

        // POST: Test_Tube/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test_Tube test_Tube = db.Test_Tube.Find(id);
            db.Test_Tube.Remove(test_Tube);
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
