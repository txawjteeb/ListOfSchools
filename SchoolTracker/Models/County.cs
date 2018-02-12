using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.Models
{
    [Table("County")]
    public class County
    {
        [Key]
        public int ID { get; set; }
        public string CountyName { get; set; }
        public string ImageLink { get; set; }
    }
}