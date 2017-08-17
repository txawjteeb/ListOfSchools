using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.Models
{
    [Table("ExtraActivites")]
    public class ExtraActivites
    {
        [Key]
        public int ID { get; set; }
        public bool CalendarProgram { get; set; }
        public bool VideoContest { get; set; }
        public bool SportsOutreach { get; set; }
        public bool Workshops { get; set; }
        public bool ScienceDays { get; set; }
    }
}