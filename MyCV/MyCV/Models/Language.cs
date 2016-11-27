using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class Language
    {
        [Key]
        public int LanguageID { get; set; }
        [Required]
        public string Langue { get; set; }
        [Required]
        public int Niveau { get; set; }
        public HttpPostedFile Logo { get; set; }
    }
}