using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolTracker.Models;
using System.ComponentModel.DataAnnotations;
using SchoolTracker.ViewModel;

namespace SchoolTracker.Controllers
{
    public class CountiesController : Controller
    {
        private SchoolTrackerContext db = new SchoolTrackerContext();

        // GET: Counties
        public ActionResult Index(int? countyId)
        {
            PopulatePartialView();
            ViewBag.SelectedCounty = (countyId != null) ? db.Counties.Find(countyId) : db.Counties.Find();
            List<SchoolDistrict> schoolDistricts = new List<SchoolDistrict>();

            var districtInfo = (from schoolDistrict in db.SchoolDistricts
                                 where schoolDistrict.CountyID == countyId
                                   select new { schoolDistrict }).ToList();

            foreach (var value in districtInfo)
            {
                SchoolDistrict tempDistrict = new SchoolDistrict();
                tempDistrict.Address = value.schoolDistrict.Address;
                tempDistrict.City = value.schoolDistrict.City;
                tempDistrict.CountyID = value.schoolDistrict.CountyID;
                tempDistrict.ID = value.schoolDistrict.ID;
                tempDistrict.MainPhone = value.schoolDistrict.MainPhone;
                tempDistrict.NumberOfStudents = value.schoolDistrict.NumberOfStudents;
                tempDistrict.SchoolName = value.schoolDistrict.SchoolName;
                tempDistrict.State = value.schoolDistrict.State;
                tempDistrict.Website = value.schoolDistrict.Website;
                tempDistrict.Zip = value.schoolDistrict.Zip;
                schoolDistricts.Add(tempDistrict);
            }

            return View(schoolDistricts);
        }

        // GET: Counties/Details/5
        public ActionResult Details(int? id)
        {
            return RedirectToAction("Index", "SchoolDistricts", new { districtId = id });
            //PopulatePartialView();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var schoolDetails = (from school in db.Schools
            //                     join contacts in db.Contacts on school.ID equals contacts.School_ID into schoolvm
            //                     from contact in schoolvm.DefaultIfEmpty()
            //                     where school.ID == id
            //                     select new { school, contact }).ToList();

            //if (schoolDetails == null)
            //{
            //    return HttpNotFound();
            //}

            //SchoolVM schoolVM = new SchoolVM();
            //foreach (var value in schoolDetails)
            //{
            //    //Schools Model Information
            //    if (!(value.school == null))
            //    {
            //        schoolVM.ID = value.school.ID;
            //        schoolVM.SchoolName = value.school.SchoolName;
            //        schoolVM.Address = value.school.Address;
            //        schoolVM.City = value.school.City;
            //        schoolVM.State = value.school.State;
            //        schoolVM.Zip = value.school.Zip;
            //        schoolVM.MainPhone = String.IsNullOrEmpty(value.school.MainPhone) ? "" : String.Format("{0:(###) ###-####}", double.Parse(value.school.MainPhone));
            //        schoolVM.Website = value.school.Website;
            //        schoolVM.NumberOfStudents = value.school.NumberOfStudents;
            //        schoolVM.CountyID = value.school.DistrictID;
            //    }

            //    //Contacts Model Information
            //    if (!(value.contact == null))
            //    {
            //        schoolVM.ContactFirstName = value.contact.ContactFirstName;
            //        schoolVM.ContactLastName = value.contact.ContactLastName;
            //        schoolVM.ContactTitle = value.contact.ContactTitle;
            //        schoolVM.ContactPhone = String.IsNullOrEmpty(value.school.MainPhone) ? "" : String.Format("{0:(###) ###-####}", double.Parse(value.contact.ContactPhone));
            //        schoolVM.ContactEmail = value.contact.ContactEmail;
            //        schoolVM.PrimaryOrSecondary = value.contact.PrimaryOrSecondary;
            //        schoolVM.Coordinator = value.contact.Coordinator;
            //    }
            //}

            //List<SchoolVM> data = new List<SchoolVM>();
            //data.Add(schoolVM);
            //return View(data);
        }

        // GET: Counties/Create
        public ActionResult Create(int? countyId)
        {
            PopulatePartialView();
            ViewBag.SelectedCounty = db.Counties.Find(countyId);
            return View();
        }

        // POST: Counties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SchoolName,Address,City,State,Zip,MainPhone,Website,NumberOfStudents,SchoolOrDistrict,CountyID")] School school)
        {
            PopulatePartialView();
            if (ModelState.IsValid)
            {
                db.Schools.Add(school);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(school);
        }

        // GET: Counties/Edit/5
        public ActionResult Edit(int? id)
        {
            PopulatePartialView();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            County county = db.Counties.Find(id);
            if (county == null)
            {
                return HttpNotFound();
            }
            return View(county);
        }

        // POST: Counties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SchoolName,Address,City,State,Zip,MainPhone,Website,NumberOfStudents,SchoolOrDistrict,DistrictID")] School school)
        {
            PopulatePartialView();
            if (ModelState.IsValid)
            {
                db.Entry(school).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", school.DistrictID);
            }
            return View(school);
        }

        // GET: Counties/Delete/5
        public ActionResult Delete(int? id)
        {
            PopulatePartialView();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return HttpNotFound();
            }
            return View(school);
        }

        // POST: Counties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PopulatePartialView();
            School school = db.Schools.Find(id);
            db.Schools.Remove(school);
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
