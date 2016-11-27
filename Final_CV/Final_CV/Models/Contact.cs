using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_CV.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        
        public string Label { get; set; }
       
        public string value { get; set; }
       
        public string Logo { get; set; }
    }
}