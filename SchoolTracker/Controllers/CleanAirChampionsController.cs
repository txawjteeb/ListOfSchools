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
    public class CleanAirChampionsController : Controller
    {
        private SchoolTrackerContext db = new SchoolTrackerContext();

        // GET: CleanAirChampions
        public ActionResult Index()
        {
            return View(db.CleanAirChampions.ToList());
        }

        // GET: CleanAirChampions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CleanAirChampion cleanAirChampion = db.CleanAirChampions.Find(id);
            if (cleanAirChampion == null)
            {
                return HttpNotFound();
            }
            return View(cleanAirChampion);
        }

        // GET: CleanAirChampions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CleanAirChampions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ContactFirstName,ContactLastName,ContactTitle,ContactPhone,ContactEmail,PrimaryOrSecondary,ProjectDescription,AmountFunded,DateFunded,AttachPhotos,FollowUpReport")] CleanAirChampion cleanAirChampion)
        {
            if (ModelState.IsValid)
            {
                db.CleanAirChampions.Add(cleanAirChampion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cleanAirChampion);
        }

        // GET: CleanAirChampions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CleanAirChampion cleanAirChampion = db.CleanAirChampions.Find(id);
            if (cleanAirChampion == null)
            {
                return HttpNotFound();
            }
            return View(cleanAirChampion);
        }

        // POST: CleanAirChampions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ContactFirstName,ContactLastName,ContactTitle,ContactPhone,ContactEmail,PrimaryOrSecondary,ProjectDescription,AmountFunded,DateFunded,AttachPhotos,FollowUpReport")] CleanAirChampion cleanAirChampion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cleanAirChampion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cleanAirChampion);
        }

        // GET: CleanAirChampions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CleanAirChampion cleanAirChampion = db.CleanAirChampions.Find(id);
            if (cleanAirChampion == null)
            {
                return HttpNotFound();
            }
            return View(cleanAirChampion);
        }

        // POST: CleanAirChampions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CleanAirChampion cleanAirChampion = db.CleanAirChampions.Find(id);
            db.CleanAirChampions.Remove(cleanAirChampion);
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
