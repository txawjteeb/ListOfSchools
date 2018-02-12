using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.ViewModel
{
    public class SchoolVM
    {
        [Key]
        public int ID { get; set; }
        public string SchoolName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string MainPhone { get; set; }
        public string Website { get; set; }
        public int NumberOfStudents { get; set; }
        public int DistrictID { get; set; }
        public string ImageLink { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public bool PrimaryOrSecondary { get; set; }
        public bool Coordinator { get; set; }
        public int ContactID { get; set; }
    }
}