using Final_CV.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Final_CV.Controllers
{
    public class HomeController : Controller
    {
        private DAL datacv = new DAL();

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
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
        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(Cv user)
        {
            //this.GetMD5HashData(model.Password);
          
            var v = datacv.Cvs.Where(model => model.Login.Equals(user.Login) &&  model.Password.Equals(user.Password)).FirstOrDefault();
            if (v != null)
            {
                Session["LogedUserName"] = user.Login;
                Session["LogedUserRole"] = user.Title;
                ViewBag.UserName = Session["LogedUserName"];
                return RedirectToAction("Index", "Languages");
            }
            else
            {
                return View("Index");
            }
        }

        private string GetMD5HashData(string data)
        {
            //create new instance of md5
            MD5 md5 = MD5.Create();

            //convert the input text to array of bytes
            byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();

        }

        public ActionResult NotFound()
        {
            return View();
        }




    }


}
