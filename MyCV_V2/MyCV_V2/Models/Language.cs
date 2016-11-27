using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV_V2.Models
{
    public class Language
    {
        [Key]
        public int LanguageID { get; set; }
        
        public string Langue { get; set; }
       
        public int Niveau { get; set; }
        public HttpPostedFile Logo { get; set; }
    }
}