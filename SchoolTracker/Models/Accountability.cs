using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.Models
{
    [Table("Accountability")]
    public class Accountability
    {
        [Key]
        public int ID{ get; set; }
        public string OCStaffAssigned { get; set; }
        public DateTime DateOfContact { get; set; }
        public string StaffLastContacted { get; set; }
        public int NoteID { get; set; }
        public bool ReadActiveOrNot { get; set; }
        public bool IdleSignOrNot { get; set; }

    }
}