using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class Formations
    {
        [Key]
        public int FormationID { get; set; }
        [Required]
        public DateTime Year { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ReferenceName { get; set; }
        public string ReferenceMail { get; set; }
        public string ReferencePhone { get; set; }
    }
}