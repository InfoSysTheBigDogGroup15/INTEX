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
    public class Test_RecordController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Test_Record
        public ActionResult Index()
        {
            var test_Record = db.Test_Record.Include(t => t.Assay).Include(t => t.Sample).Include(t => t.Test_Tube);
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
            return View(test_Record.ToList());
        }

        // GET: Test_Record/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Record test_Record = db.Test_Record.Find(id);
            if (test_Record == null)
            {
                return HttpNotFound();
            }
            return View(test_Record);
        }

        // GET: Test_Record/Create
        public ActionResult Create()
        {
            ViewBag.assayID = new SelectList(db.Assays, "assayID", "comments");
            ViewBag.sampleID = new SelectList(db.Samples, "sampleID", "sequenceNumber");
            ViewBag.testTubeID = new SelectList(db.Test_Tube, "testTubeID", "concentration");
            return View();
        }

        // POST: Test_Record/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "testRecordID,assayID,sampleID,testTubeID,numericResult,judgementInfo,comments")] Test_Record test_Record)
        {
            if (ModelState.IsValid)
            {
                db.Test_Record.Add(test_Record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.assayID = new SelectList(db.Assays, "assayID", "comments", test_Record.assayID);
            ViewBag.sampleID = new SelectList(db.Samples, "sampleID", "sequenceNumber", test_Record.sampleID);
            ViewBag.testTubeID = new SelectList(db.Test_Tube, "testTubeID", "concentration", test_Record.testTubeID);
            return View(test_Record);
        }

        // GET: Test_Record/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Record test_Record = db.Test_Record.Find(id);
            if (test_Record == null)
            {
                return HttpNotFound();
            }
            ViewBag.assayID = new SelectList(db.Assays, "assayID", "comments", test_Record.assayID);
            ViewBag.sampleID = new SelectList(db.Samples, "sampleID", "sequenceNumber", test_Record.sampleID);
            ViewBag.testTubeID = new SelectList(db.Test_Tube, "testTubeID", "concentration", test_Record.testTubeID);
            return View(test_Record);
        }

        // POST: Test_Record/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "testRecordID,assayID,sampleID,testTubeID,numericResult,judgementInfo,comments")] Test_Record test_Record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test_Record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.assayID = new SelectList(db.Assays, "assayID", "comments", test_Record.assayID);
            ViewBag.sampleID = new SelectList(db.Samples, "sampleID", "sequenceNumber", test_Record.sampleID);
            ViewBag.testTubeID = new SelectList(db.Test_Tube, "testTubeID", "concentration", test_Record.testTubeID);
            return View(test_Record);
        }

        // GET: Test_Record/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test_Record test_Record = db.Test_Record.Find(id);
            if (test_Record == null)
            {
                return HttpNotFound();
            }
            return View(test_Record);
        }

        // POST: Test_Record/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test_Record test_Record = db.Test_Record.Find(id);
            db.Test_Record.Remove(test_Record);
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
