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
    public class CommunicationToolsController : Controller
    {
        private SchoolTrackerContext db = new SchoolTrackerContext();

        // GET: CommunicationTools
        public ActionResult Index()
        {
            return View(db.CommunicationTools.ToList());
        }

        // GET: CommunicationTools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommunicationTool communicationTool = db.CommunicationTools.Find(id);
            if (communicationTool == null)
            {
                return HttpNotFound();
            }
            return View(communicationTool);
        }

        // GET: CommunicationTools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommunicationTools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type")] CommunicationTool communicationTool)
        {
            if (ModelState.IsValid)
            {
                db.CommunicationTools.Add(communicationTool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(communicationTool);
        }

        // GET: CommunicationTools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommunicationTool communicationTool = db.CommunicationTools.Find(id);
            if (communicationTool == null)
            {
                return HttpNotFound();
            }
            return View(communicationTool);
        }

        // POST: CommunicationTools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type")] CommunicationTool communicationTool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(communicationTool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(communicationTool);
        }

        // GET: CommunicationTools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommunicationTool communicationTool = db.CommunicationTools.Find(id);
            if (communicationTool == null)
            {
                return HttpNotFound();
            }
            return View(communicationTool);
        }

        // POST: CommunicationTools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommunicationTool communicationTool = db.CommunicationTools.Find(id);
            db.CommunicationTools.Remove(communicationTool);
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
