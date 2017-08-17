using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolTracker.Models;

namespace SchoolTracker.Controllers
{
    public class RAANNotificationsController : Controller
    {
        private SchoolTrackerContext db = new SchoolTrackerContext();

        // GET: RAANNotifications
        public ActionResult Index()
        {
            return View(db.RAANNotifications.ToList());
        }

        // GET: RAANNotifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAANNotification rAANNotification = db.RAANNotifications.Find(id);
            if (rAANNotification == null)
            {
                return HttpNotFound();
            }
            return View(rAANNotification);
        }

        // GET: RAANNotifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RAANNotifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SchoolOffice,DistrictOffice,Teachers,AthleticDirector,Widget,SmartPhoneApp,READ,FlagRelying")] RAANNotification rAANNotification)
        {
            if (ModelState.IsValid)
            {
                db.RAANNotifications.Add(rAANNotification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rAANNotification);
        }

        // GET: RAANNotifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAANNotification rAANNotification = db.RAANNotifications.Find(id);
            if (rAANNotification == null)
            {
                return HttpNotFound();
            }
            return View(rAANNotification);
        }

        // POST: RAANNotifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SchoolOffice,DistrictOffice,Teachers,AthleticDirector,Widget,SmartPhoneApp,READ,FlagRelying")] RAANNotification rAANNotification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rAANNotification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rAANNotification);
        }

        // GET: RAANNotifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RAANNotification rAANNotification = db.RAANNotifications.Find(id);
            if (rAANNotification == null)
            {
                return HttpNotFound();
            }
            return View(rAANNotification);
        }

        // POST: RAANNotifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RAANNotification rAANNotification = db.RAANNotifications.Find(id);
            db.RAANNotifications.Remove(rAANNotification);
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
