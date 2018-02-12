using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.Models
{
    [Table("ParentsCommunication")]
    public class ParentsCommunication
    {
        [Key]
        public int ID { get; set; }
        [NotMapped]
        public List <CommunicationTool> CommunicationTool;
        public bool ClassRoomDojo { get; set; }
        public bool PeachJar { get; set; }
        public bool EduText { get; set; }
        public bool etc { get; set; }
    }
}