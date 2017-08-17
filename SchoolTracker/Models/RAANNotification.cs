using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.Models
{
    [Table("RAANNotification")]
    public class RAANNotification
    {
        [Key]
        public int ID { get; set; }
        public bool SchoolOffice { get; set; }
        public bool DistrictOffice { get; set; }
        public bool Teachers { get; set; }
        public bool AthleticDirector { get; set; }
        public bool Widget { get; set; }
        public bool SmartPhoneApp { get; set; }
        public bool READ { get; set; }
        public bool FlagRelying { get; set; }

    }
}