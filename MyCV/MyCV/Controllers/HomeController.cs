using MyCV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCV.Controllers
{
    public class HomeController : Controller
    {
        private EFCv db = new EFCv();
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Welcome in ASP.NET MVC 5 INSPINIA SeedProject ";
            ViewData["Message"] = "It is an application skeleton for a typical MVC 5 project. You can use it to quickly bootstrap your webapp projects.";

            return View();
        }

        public ActionResult Minor()
        {
            ViewData["SubTitle"] = "Simple example of second view";
            ViewData["Message"] = "Data are passing to view by ViewData from controller";

            return View();
        }
        public ActionResult ExpProf()
        {
            ViewData["SubTitle"] = "Expérience Professionelle";
            ViewData["Message"] = "Expérience Professionelle";
            return View();
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
            return View();
        }
        public ActionResult DomaineComp()
        {
            ViewData["SubTitle"] = "Domaines des compétences";
            try
            {
               // var dc = db.Skills.ToList();
                return View();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ActionResult Langues()
        {
            ViewData["SubTitle"] = "langues";
            var Lang = db.Languages.ToList();
            
              return View(Lang);
          
        }
        public ActionResult Divers()
        {
            ViewData["SubTitle"] = "Divers";
            ViewData["Message"] = "Divers";
            return View();
        }
        public ActionResult ContactMe()
        {
            ViewData["SubTitle"] = "Contacter moi";
            ViewData["Message"] = "Contacter moi";
            return View();
        }
    }
}