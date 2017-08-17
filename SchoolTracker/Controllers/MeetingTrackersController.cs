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
    public class MeetingTrackersController : Controller
    {
        private SchoolTrackerContext db = new SchoolTrackerContext();

        // GET: MeetingTrackers
        public ActionResult Index()
        {
            return View(db.MeetingTrackers.ToList());
        }

        // GET: MeetingTrackers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingTracker meetingTracker = db.MeetingTrackers.Find(id);
            if (meetingTracker == null)
            {
                return HttpNotFound();
            }
            return View(meetingTracker);
        }

        // GET: MeetingTrackers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeetingTrackers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MeetingDate,ContactID,NoteID")] MeetingTracker meetingTracker)
        {
            if (ModelState.IsValid)
            {
                db.MeetingTrackers.Add(meetingTracker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meetingTracker);
        }

        // GET: MeetingTrackers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingTracker meetingTracker = db.MeetingTrackers.Find(id);
            if (meetingTracker == null)
            {
                return HttpNotFound();
            }
            return View(meetingTracker);
        }

        // POST: MeetingTrackers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MeetingDate,ContactID,NoteID")] MeetingTracker meetingTracker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingTracker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meetingTracker);
        }

        // GET: MeetingTrackers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingTracker meetingTracker = db.MeetingTrackers.Find(id);
            if (meetingTracker == null)
            {
                return HttpNotFound();
            }
            return View(meetingTracker);
        }

        // POST: MeetingTrackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeetingTracker meetingTracker = db.MeetingTrackers.Find(id);
            db.MeetingTrackers.Remove(meetingTracker);
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
