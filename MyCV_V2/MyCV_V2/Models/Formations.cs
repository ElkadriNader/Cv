using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV_V2.Models
{
    public class Formations
    {
        [Key]
        public int FormationID { get; set; }
        
        public DateTime Year { get; set; }
       
        public string Title { get; set; }
       
        public string Place { get; set; }
        
        public string Description { get; set; }
        
        public string ReferenceName { get; set; }
        public string ReferenceMail { get; set; }
        public string ReferencePhone { get; set; }
    }
}