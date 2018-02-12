using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.Models
{
    [Table("Note")]
    public class Note
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
    }
}