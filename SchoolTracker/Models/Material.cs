using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolTracker.Models
{
    [Table("Material")]
    public class Material
    {
        [Key]
        public int ID { get; set; }
        public int IdlingSign { get; set; }
        public int Brochure { get; set; }
        public int Poster { get; set; }
        public int PromoItem { get; set; }
        public int Curricula { get; set; }
    }
}