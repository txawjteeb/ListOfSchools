using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.Models
{
    [Table("CleanAirChampion")]
    public class CleanAirChampion
    {
        [Key]
        public int ID { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public bool PrimaryOrSecondary { get; set; }
        public string ProjectDescription { get; set; }
        public int AmountFunded { get; set; }
        public DateTime DateFunded { get; set; }
        public string AttachPhotos { get; set; }
        public string FollowUpReport { get; set; }
    }
}