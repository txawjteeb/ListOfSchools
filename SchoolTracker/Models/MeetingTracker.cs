using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.Models
{
    [Table("MeetingTracker")]
    public class MeetingTracker
    {
        [Key]
        public int ID { get; set; }
        [NotMapped]
        public List<MeetingType> MeetingType;
        public DateTime MeetingDate { get; set; }
        public int ContactID { get; set; }
        public int NoteID { get; set; }
    }
}