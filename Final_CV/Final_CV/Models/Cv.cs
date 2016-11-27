using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_CV.Models
{
    public class Cv
    {
         [Key]
        public int CvID { get; set; }
       
        public string Title { get; set; }
        
        public string Login { get; set; }
       
        public string Password { get; set; }
    }
}