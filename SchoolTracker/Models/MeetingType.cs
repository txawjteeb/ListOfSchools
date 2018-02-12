using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.Models
{
    [Table("MeetingType")]
    public class MeetingType
    {
        [Key]
        public int ID { get; set; }
        public string Type { get; set; }

    }
}