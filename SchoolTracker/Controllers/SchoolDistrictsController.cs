using SchoolTracker.ViewModel;
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
    public class SchoolDistrictsController : Controller
    {
        private SchoolTrackerContext db = new SchoolTrackerContext();

        // GET: SchoolDistricts
        public ActionResult Index(int? districtId)
        {
            PopulatePartialView();
            ViewBag.SelectedDistrict = (districtId != null) ? db.SchoolDistricts.Find(districtId) : db.SchoolDistricts.Find(1);
            List<School> schoolList = new List<School>();

            var districtSchools = (from school in db.Schools
                                where school.DistrictID == districtId
                                select new { school }).ToList();

            foreach (var value in districtSchools)
            {
                School tempDistrict = new School();
                tempDistrict.Address = value.school.Address;
                tempDistrict.City = value.school.City;
                tempDistrict.DistrictID = value.school.DistrictID;
                tempDistrict.ID = value.school.ID;
                tempDistrict.MainPhone = value.school.MainPhone;
                tempDistrict.NumberOfStudents = value.school.NumberOfStudents;
                tempDistrict.SchoolName = value.school.SchoolName;
                tempDistrict.State = value.school.State;
                tempDistrict.Website = value.school.Website;
                tempDistrict.Zip = value.school.Zip;
                schoolList.Add(tempDistrict);
            }

            return View(schoolList);
        }

        // GET: SchoolDistricts/Details/5
        public ActionResult Details(int? id)
        {
            return RedirectToAction("Details", "Schools", new { id = id });
            //PopulatePartialView();
            //return View();
        }

        // GET: SchoolDistricts/Create
        public ActionResult Create(int? countyId)
        {
            PopulatePartialView();
            ViewBag.SelectedCounty = db.Counties.Find(countyId);
            return View();
        }

        // POST: SchoolDistricts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SchoolName,Address,City,State,Zip,MainPhone,Website,NumberOfStudents,CountyID")] SchoolDistrict schoolDistrict)
        {
            PopulatePartialView();
            if (ModelState.IsValid)
            {
                db.SchoolDistricts.Add(schoolDistrict);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schoolDistrict);
        }

        // GET: SchoolDistricts/Edit/5
        public ActionResult Edit(int? id)
        {
            PopulatePartialView();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolDistrict schoolDistrict = db.SchoolDistricts.Find(id);
            if (schoolDistrict == null)
            {
                return HttpNotFound();
            }
            return View(schoolDistrict);
        }

        // POST: SchoolDistricts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SchoolName,Address,City,State,Zip,MainPhone,Website,NumberOfStudents,CountyID")] SchoolDistrict schoolDistrict)
        {
            PopulatePartialView();
            if (ModelState.IsValid)
            {
                db.Entry(schoolDistrict).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schoolDistrict);
        }

        // GET: SchoolDistricts/Delete/5
        public ActionResult Delete(int? id)
        {
            PopulatePartialView();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolDistrict schoolDistrict = db.SchoolDistricts.Find(id);
            if (schoolDistrict == null)
            {
                return HttpNotFound();
            }
            return View(schoolDistrict);
        }

        // POST: SchoolDistricts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopulatePartialView();
            SchoolDistrict schoolDistrict = db.SchoolDistricts.Find(id);
            db.SchoolDistricts.Remove(schoolDistrict);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void PopulatePartialView()
        {
            ViewBag.SchoolList = db.Schools.ToList();
            ViewBag.SchoolDistrictList = db.SchoolDistricts.ToList();
            ViewBag.CountyList = db.Counties.ToList();
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
