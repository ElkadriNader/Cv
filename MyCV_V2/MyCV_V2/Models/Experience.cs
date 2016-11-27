using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV_V2.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceID { get; set; }
        
        public DateTime Year { get; set; }
       
        public string Title { get; set; }
        
        public string Description { get; set; }
       
        public string CampanyName { get; set; }
        
        public string CampanySite { get; set; }
        
        public string ReferenceName { get; set; }
        public string ReferenceContact { get; set; }
    }
}