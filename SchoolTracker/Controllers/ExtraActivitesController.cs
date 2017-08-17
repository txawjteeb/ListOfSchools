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
    public class ExtraActivitesController : Controller
    {
        private SchoolTrackerContext db = new SchoolTrackerContext();

        // GET: ExtraActivites
        public ActionResult Index()
        {
            return View(db.ExtraActivites.ToList());
        }

        // GET: ExtraActivites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraActivites extraActivites = db.ExtraActivites.Find(id);
            if (extraActivites == null)
            {
                return HttpNotFound();
            }
            return View(extraActivites);
        }

        // GET: ExtraActivites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExtraActivites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CalendarProgram,VideoContest,SportsOutreach,Workshops,ScienceDays")] ExtraActivites extraActivites)
        {
            if (ModelState.IsValid)
            {
                db.ExtraActivites.Add(extraActivites);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(extraActivites);
        }

        // GET: ExtraActivites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraActivites extraActivites = db.ExtraActivites.Find(id);
            if (extraActivites == null)
            {
                return HttpNotFound();
            }
            return View(extraActivites);
        }

        // POST: ExtraActivites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CalendarProgram,VideoContest,SportsOutreach,Workshops,ScienceDays")] ExtraActivites extraActivites)
        {
            if (ModelState.IsValid)
            {
                db.Entry(extraActivites).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(extraActivites);
        }

        // GET: ExtraActivites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraActivites extraActivites = db.ExtraActivites.Find(id);
            if (extraActivites == null)
            {
                return HttpNotFound();
            }
            return View(extraActivites);
        }

        // POST: ExtraActivites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExtraActivites extraActivites = db.ExtraActivites.Find(id);
            db.ExtraActivites.Remove(extraActivites);
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
