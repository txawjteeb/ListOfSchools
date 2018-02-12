using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolTracker.Models;
using SchoolTracker.ViewModel;

namespace SchoolTracker.Controllers
{
    public class HomeController : Controller
    {
        private SchoolTrackerContext db = new SchoolTrackerContext();

        public ActionResult Index()
        {
            PopulatePartialView();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            PopulatePartialView();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            PopulatePartialView();
            return View();
        }

        public void PopulatePartialView()
        {
            ViewBag.SchoolList = db.Schools.ToList();
            ViewBag.SchoolDistrictList = db.SchoolDistricts.ToList();
            ViewBag.CountyList = db.Counties.ToList();
        }
    }
}