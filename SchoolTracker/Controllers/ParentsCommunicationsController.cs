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
    public class ParentsCommunicationsController : Controller
    {
        private SchoolTrackerContext db = new SchoolTrackerContext();

        // GET: ParentsCommunications
        public ActionResult Index()
        {
            return View(db.ParentsCommunications.ToList());
        }

        // GET: ParentsCommunications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentsCommunication parentsCommunication = db.ParentsCommunications.Find(id);
            if (parentsCommunication == null)
            {
                return HttpNotFound();
            }
            return View(parentsCommunication);
        }

        // GET: ParentsCommunications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParentsCommunications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ClassRoomDojo,PeachJar,EduText,etc")] ParentsCommunication parentsCommunication)
        {
            if (ModelState.IsValid)
            {
                db.ParentsCommunications.Add(parentsCommunication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parentsCommunication);
        }

        // GET: ParentsCommunications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentsCommunication parentsCommunication = db.ParentsCommunications.Find(id);
            if (parentsCommunication == null)
            {
                return HttpNotFound();
            }
            return View(parentsCommunication);
        }

        // POST: ParentsCommunications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClassRoomDojo,PeachJar,EduText,etc")] ParentsCommunication parentsCommunication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parentsCommunication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parentsCommunication);
        }

        // GET: ParentsCommunications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentsCommunication parentsCommunication = db.ParentsCommunications.Find(id);
            if (parentsCommunication == null)
            {
                return HttpNotFound();
            }
            return View(parentsCommunication);
        }

        // POST: ParentsCommunications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParentsCommunication parentsCommunication = db.ParentsCommunications.Find(id);
            db.ParentsCommunications.Remove(parentsCommunication);
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
