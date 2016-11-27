using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_CV.Models
{
    public class Skills
    {
       [Key]
        public int SkillID { get; set; }
       
        
        public string Title { get; set; }
       
        public int Niveau { get; set; }
        public string Logo { get; set; }

    }
}