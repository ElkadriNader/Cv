using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyCV.Models
{
    public class Skills
    {
        [Key]
        public int SkillID { get; set; }
       
        [Required]
        public string Title { get; set; }
        [Required]
        public int Niveau { get; set; }
        public HttpPostedFile Logo { get; set; }

    }
}