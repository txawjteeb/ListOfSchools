using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.Models
{
    [Table("Staff")]
    public class Staff
    {
        [Key]
        public int RecordID { get; set; }
        public int EmployeeID { get; set; }
        public string Region { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int Extension { get; set; }  
        public string Title { get; set; }

    }
}