using Final_CV.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_CV.Controllers
{
    public class HomeController : Controller
    {
        private DAL datacv = new DAL();
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Welcome in ASP.NET MVC 5 INSPINIA SeedProject ";
            ViewData["Message"] = "It is an application skeleton for a typical MVC 5 project. You can use it to quickly bootstrap your webapp projects.";

            return View();
        }

       
        public ActionResult ExpProf()
        {
            var exp = datacv.Experiences.ToList();
          
            return View(exp);
        }
        public ActionResult EtudeEtDiplome()
        {
            ViewData["SubTitle"] = "Etude et diplomes";
            ViewData["Message"] = "Etude et diplomes";
            return View();
        }
        public ActionResult Formation()
        {
            ViewData["SubTitle"] = "Formations";
            ViewData["Message"] = "Formations";
            return View(datacv.Formations.ToList());
        }
        public ActionResult DomaineComp(string searchString, int page = 1, int pageSize = 4)
        {
            var skils = datacv.Skills.ToList();
            var listskills = from d in datacv.Skills
                           select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                listskills = listskills.Where(s => s.Title.Contains(searchString));
            }
            var list = new PagedList<Skills>(listskills.ToList(), page, pageSize);
            return View(list);

           // return View(datacv.Skills.ToList());
           
        }
        public ActionResult Langues()
        {
            ViewData["SubTitle"] = "langues";

            return View(datacv.Languages.ToList());

        }
        public ActionResult Divers()
        {
            ViewData["SubTitle"] = "Divers";
            ViewData["Message"] = "Divers";
            return View();
        }
        public ActionResult ContactMe()
        {
            var data = datacv.Contacts.ToList();
            return View(data);
        }
    }
}