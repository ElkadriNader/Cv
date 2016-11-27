using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_CV.Models
{
    public class Language
    {
        [Key]
        public int LangaugeID { get; set; }
        public string Name { get; set; }
        public int Niveau { get; set; }
        public string Logo { get; set; }
    }
}