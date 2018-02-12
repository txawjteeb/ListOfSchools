using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.ViewModel
{
    public class AccountabilityStaffVM
    {
        [Key]
        public int ID { get; set; }
        public int SchoolID { get; set; }
        public string OCStaffAssigned { get; set; }
        public DateTime DateOfContact { get; set; }
        public string StaffLastContacted { get; set; }
        public int NoteID { get; set; }
        public bool ReadActiveOrNot { get; set; }
        public bool IdleSignOrNot { get; set; }
        public string Testing { get; set; }
        public int EmployeeID { get; set; }
        public string Region { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Extension { get; set; }
        public string Title { get; set; }
    }
}