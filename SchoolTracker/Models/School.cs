using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.Models
{
    [Table("School")]
    public class School
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
        public int ContactID { get; set; }
        public string ImageLink { get; set; }

    }
}