﻿using System;
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
    public class Assays2Controller : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: Assays2
        public ActionResult Index()
        {
            var assays = db.Assays.Include(a => a.Client).Include(a => a.Compound).Include(a => a.Discount).Include(a => a.Status).Include(a => a.Test);
            return View(assays.ToList());
        }

        // GET: Assays2/Details/5
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

        // GET: Assays2/Create
        public ActionResult Create()
        {
            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientFirstName");
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName");
            ViewBag.discountID = new SelectList(db.Discounts, "discountID", "description");
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription");
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName");
            return View();
        }

        // POST: Assays2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "assayID,clientID,LTNumber,testID,discountID,comments,statusID,allowExtraTest")] Assay assay)
        {
            if (ModelState.IsValid)
            {
                db.Assays.Add(assay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clientID = new SelectList(db.Clients, "clientID", "clientFirstName", assay.clientID);
            ViewBag.LTNumber = new SelectList(db.Compounds, "LTNumber", "compoundName", assay.LTNumber);
            ViewBag.discountID = new SelectList(db.Discounts, "discountID", "description", assay.discountID);
            ViewBag.statusID = new SelectList(db.Status, "statusID", "statusDescription", assay.statusID);
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName", assay.testID);
            return View(assay);
        }

        // GET: Assays2/Edit/5
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
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName", assay.testID);
            return View(assay);
        }

        // POST: Assays2/Edit/5
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
            ViewBag.testID = new SelectList(db.Tests, "testID", "testName", assay.testID);
            return View(assay);
        }

        // GET: Assays2/Delete/5
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

        // POST: Assays2/Delete/5
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
