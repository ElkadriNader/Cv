using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public string value { get; set; }
       
        public HttpPostedFile Logo { get; set; }
    }
}