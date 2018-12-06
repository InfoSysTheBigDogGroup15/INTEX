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
    public class UserAuthsController : Controller
    {
        private NorthwestContext db = new NorthwestContext();

        // GET: UserAuths
        public ActionResult Index()
        {
            return View(db.UserAuths.ToList());
        }

        // GET: UserAuths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAuth userAuth = db.UserAuths.Find(id);
            if (userAuth == null)
            {
                return HttpNotFound();
            }
            return View(userAuth);
        }

        // GET: UserAuths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAuths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "authorizationID,username,password,role")] UserAuth userAuth)
        {
            if (ModelState.IsValid)
            {
                db.UserAuths.Add(userAuth);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAuth);
        }

        // GET: UserAuths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAuth userAuth = db.UserAuths.Find(id);
            if (userAuth == null)
            {
                return HttpNotFound();
            }
            return View(userAuth);
        }

        // POST: UserAuths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "authorizationID,username,password,role")] UserAuth userAuth)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAuth).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAuth);
        }

        // GET: UserAuths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAuth userAuth = db.UserAuths.Find(id);
            if (userAuth == null)
            {
                return HttpNotFound();
            }
            return View(userAuth);
        }

        // POST: UserAuths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAuth userAuth = db.UserAuths.Find(id);
            db.UserAuths.Remove(userAuth);
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
