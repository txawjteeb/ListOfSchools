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
using System.IO;

namespace SchoolTracker.Controllers
{
    public class SchoolsController : Controller
    {
        private SchoolTrackerContext db = new SchoolTrackerContext();

        // GET: Schools
        public ActionResult Index()
        {
            //PopulatePartialView();
            //ViewBag.SelectedCounty = (countyId != null) ? db.Counties.Find(countyId) : db.Counties.Find(1);
            //List<SchoolDistrict> schoolDistricts = new List<SchoolDistrict>();

            //var districtInfo = (from schoolDistrict in db.SchoolDistricts
            //                     where schoolDistrict.CountyID == countyId
            //                       select new { schoolDistrict }).ToList();

            //foreach (var value in districtInfo)
            //{
            //    SchoolDistrict tempDistrict = new SchoolDistrict();
            //    tempDistrict.Address = value.schoolDistrict.Address;
            //    tempDistrict.City = value.schoolDistrict.City;
            //    tempDistrict.CountyID = value.schoolDistrict.CountyID;
            //    tempDistrict.ID = value.schoolDistrict.ID;
            //    tempDistrict.MainPhone = value.schoolDistrict.MainPhone;
            //    tempDistrict.NumberOfStudents = value.schoolDistrict.NumberOfStudents;
            //    tempDistrict.SchoolName = value.schoolDistrict.SchoolName;
            //    tempDistrict.State = value.schoolDistrict.State;
            //    tempDistrict.Website = value.schoolDistrict.Website;
            //    tempDistrict.Zip = value.schoolDistrict.Zip;
            //    schoolDistricts.Add(tempDistrict);
            //}
            //return View(schoolDistricts);
            return View();

        }

        // GET: Schools/Details/5
        public ActionResult Details(int? SchoolId)
        {
            PopulatePartialView();
            if (SchoolId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var AccountabilityDetails = (from accountable in db.Accountabilities
                                         join staff in db.Staffs on accountable.OCStaffAssigned equals staff.UserName into accountvm
                                         from person in accountvm.DefaultIfEmpty()
                                         where accountable.SchoolID == SchoolId
                                         select new { accountable, person }).ToList();

            AccountabilityStaffVM accountStaffVM = new AccountabilityStaffVM();
            foreach (var value in AccountabilityDetails)
            {
                //Accountability Model Information
                if (!(value.accountable == null))
                {
                    accountStaffVM.ID = value.accountable.ID;
                    accountStaffVM.SchoolID = value.accountable.SchoolID;
                }

                //Person Model Information
                if (!(value.person == null))
                {
                    accountStaffVM.EmployeeID = value.person.EmployeeID;
                    accountStaffVM.Region = value.person.Region;
                    accountStaffVM.FirstName = value.person.FirstName;
                    accountStaffVM.LastName = value.person.LastName;
                    accountStaffVM.Extension = value.person.Extension;
                    accountStaffVM.Title = value.person.Title;
                }
            }


            var schoolDetails = (from school in db.Schools
                                 join contacts in db.Contacts on school.ContactID equals contacts.ID into schoolvm
                                 from contact in schoolvm.DefaultIfEmpty()
                                 where school.ID == SchoolId
                                 select new { school, contact }).ToList();


            if (schoolDetails == null)
            {
                return HttpNotFound();
            }

            SchoolVM schoolVM = new SchoolVM();
            foreach (var value in schoolDetails)
            {
                //Schools Model Information
                if (!(value.school == null))
                {
                    schoolVM.ID = value.school.ID;
                    schoolVM.SchoolName = value.school.SchoolName;
                    schoolVM.Address = value.school.Address;
                    schoolVM.City = value.school.City;
                    schoolVM.State = value.school.State;
                    schoolVM.Zip = value.school.Zip;
                    schoolVM.MainPhone = String.IsNullOrEmpty(value.school.MainPhone) ? "" : String.Format("{0:(###) ###-####}", double.Parse(value.school.MainPhone));
                    schoolVM.Website = value.school.Website;
                    schoolVM.NumberOfStudents = value.school.NumberOfStudents;
                    schoolVM.DistrictID = value.school.DistrictID;
                    schoolVM.ImageLink = value.school.ImageLink;
                }

                //Contacts Model Information
                if (!(value.contact == null))
                {
                    schoolVM.ContactFirstName = value.contact.ContactFirstName;
                    schoolVM.ContactLastName = value.contact.ContactLastName;
                    schoolVM.ContactTitle = value.contact.ContactTitle;
                    schoolVM.ContactPhone = String.IsNullOrEmpty(value.school.MainPhone) ? "" : String.Format("{0:(###) ###-####}", double.Parse(value.contact.ContactPhone));
                    schoolVM.ContactEmail = value.contact.ContactEmail;
                    schoolVM.PrimaryOrSecondary = value.contact.PrimaryOrSecondary;
                    schoolVM.Coordinator = value.contact.Coordinator;
                    schoolVM.ContactID = value.contact.ID;
                }
            }

            List<SchoolVM> data = new List<SchoolVM>();
            data.Add(schoolVM);
            return View(data);
        }

        // GET: Schools/Create
        public ActionResult Create(int? districtId)
        {
            PopulatePartialView();
            ViewBag.SelectedDistrict = db.SchoolDistricts.Find(districtId);
            return View();
        }

        // POST: Schools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SchoolName,Address,City,State,Zip,MainPhone,Website,NumberOfStudents,DistrictID,ContactID,ImageLink")] School school)
        {
            PopulatePartialView();
            if (ModelState.IsValid)
            {
                db.Schools.Add(school);
                db.SaveChanges();
                return RedirectToAction("Index", "SchoolDistricts", new { districtId = school.DistrictID });
            }

            return View(school);
        }

        // GET: Schools/Edit/5
        public ActionResult Edit(int? id)
        {
            PopulatePartialView();
            IEnumerable<SelectListItem> ContactItems = db.Contacts
                .Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.ContactFirstName + " " + c.ContactLastName
                });
            ViewBag.ContactList = ContactItems;
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

        // POST: Schools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SchoolName,Address,City,State,Zip,MainPhone,Website,NumberOfStudents,DistrictID,ContactID")] School school)
        {
            PopulatePartialView();
            if (ModelState.IsValid)
            {
                var schoolModel = db.Schools.Find(school.ID);
                schoolModel.SchoolName = school.SchoolName;
                schoolModel.Address = school.Address;
                schoolModel.City = school.City;
                schoolModel.State = school.State;
                schoolModel.Zip = school.Zip;
                schoolModel.MainPhone = school.MainPhone;
                schoolModel.Website = school.Website;
                schoolModel.NumberOfStudents = school.NumberOfStudents;
                schoolModel.DistrictID = school.DistrictID;
                schoolModel.ContactID = school.ContactID;
                if (TryUpdateModel(schoolModel, "",
                    new string[] { "SchoolName", "Address", "City", "State", "Zip", "MainPhone", "Website", "NumberOfStudents", "DistrictID", "ContactID", }))
                {
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DataException ex)
                    {

                    }
                }
            }
            return RedirectToAction("Details", new { id = school.ID });
        }

        // GET: Schools/Delete/5
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

        // POST: Schools/Delete/5
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

        // GET: Schools/Change/5
        public ActionResult Change(int? id)
        {
            PopulatePartialView();
            IEnumerable<SelectListItem> ContactItems = db.Contacts
                .Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.ContactFirstName + " " + c.ContactLastName
                });
            ViewBag.ContactList = ContactItems;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School schoolContact = db.Schools.Find(id);
            if (schoolContact == null)
            {
                return HttpNotFound();
            }
            return View(schoolContact);
        }

        // POST: Schools/EditContact/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change([Bind(Include = "ID,ContactID")] School school)
        {
            PopulatePartialView();
            if (ModelState.IsValid)
            {
                var schoolContactToUpdate = db.Schools.Find(school.ID);
                if (TryUpdateModel(schoolContactToUpdate, "", 
                    new string[] { "ContactID" }))
                {
                    try
                    {
                        db.SaveChanges();
                        return RedirectToAction("Details", "Schools", new { Id = school.ID });
                    }
                    catch (DataException ex)
                    {
                        
                    }
                }
            }
            return View(school);
        }

        public void PopulatePartialView()
        {
            ViewBag.SchoolList = db.Schools.ToList();
            ViewBag.SchoolDistrictList = db.SchoolDistricts.ToList();
            ViewBag.CountyList = db.Counties.ToList();
        }

        // GET: Schools/ChangePicture/5
        public ActionResult ChangePicture(int? SchoolID)
        {
            PopulatePartialView();
            if (SchoolID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            School schoolContact = db.Schools.Find(SchoolID);
            if (schoolContact == null)
            {
                return HttpNotFound();
            }
            return View(schoolContact);
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file, int SchoolID, string SchoolImageLink)
        {
            try
            {
                string path = "";
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Images/School"), _FileName);
                    file.SaveAs(_path);
                    string oldPath = Request.MapPath("~" + SchoolImageLink);
                    if (_path != oldPath)
                    {
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }

                    path = "/Images/School/" + _FileName;
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                PopulatePartialView();
                var school = db.Schools.Find(SchoolID);
                school.ImageLink = path;
                if (TryUpdateModel(school, "",
                    new string[] { "ImageLink" }))
                {
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DataException ex)
                    {

                    }
                }
                return RedirectToAction("Details", "Schools", new { Id = school.ID });
            }
            catch (Exception ex)
            {
                ViewBag.Message = "File upload failed!! " + ex.Message;
                PopulatePartialView();
                School school = db.Schools.Find(5);
                return RedirectToAction("Details", "Schools", new { Id = school.ID });
            }
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
