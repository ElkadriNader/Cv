using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceID { get; set; }
        [Required]
        public DateTime Year { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CampanyName { get; set; }
        [Required]
        public string CampanySite { get; set; }
        [Required]
        public string ReferenceName { get; set; }
        public string ReferenceContact { get; set; }
    }
}