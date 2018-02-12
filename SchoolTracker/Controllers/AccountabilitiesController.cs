using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolTracker.Models
{
    public class AccountabilitiesController : Controller
    {
        private SchoolTrackerContext db = new SchoolTrackerContext();

        // GET: Accountabilities
        public ActionResult Index()
        {
            return View(db.Accountabilities.ToList());
        }

        // GET: Accountabilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accountability accountability = db.Accountabilities.Find(id);
            if (accountability == null)
            {
                return HttpNotFound();
            }
            return View(accountability);
        }

        // GET: Accountabilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accountabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OCStaffAssigned,DateOfContact,StaffLastContacted,NoteID,ReadActiveOrNot,IdleSignOrNot")] Accountability accountability)
        {
            if (ModelState.IsValid)
            {
                db.Accountabilities.Add(accountability);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountability);
        }

        // GET: Accountabilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accountability accountability = db.Accountabilities.Find(id);
            if (accountability == null)
            {
                return HttpNotFound();
            }
            return View(accountability);
        }

        // POST: Accountabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OCStaffAssigned,DateOfContact,StaffLastContacted,NoteID,ReadActiveOrNot,IdleSignOrNot")] Accountability accountability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountability);
        }

        // GET: Accountabilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accountability accountability = db.Accountabilities.Find(id);
            if (accountability == null)
            {
                return HttpNotFound();
            }
            return View(accountability);
        }

        // POST: Accountabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accountability accountability = db.Accountabilities.Find(id);
            db.Accountabilities.Remove(accountability);
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
