using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_CV;
using Final_CV.Models;
using System.IO;
using PagedList;

namespace Final_CV.Controllers
{
    public class SkillsController : Controller
    {
        private DAL db = new DAL();

        // GET: Skills
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                var skils = db.Skills.ToList();
                var listskills = from d in db.Skills
                                 select d;
                if (!String.IsNullOrEmpty(searchString))
                {
                    listskills = listskills.Where(s => s.Title.Contains(searchString));
                }
                var list = new PagedList<Skills>(listskills.ToList(), page, pageSize);
                return View(list);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Skills skills = db.Skills.Find(id);
                if (skills == null)
                {
                    return HttpNotFound();
                }
                return View(skills);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Skills/Create
        public ActionResult Create()
        {

            if (HttpContext.Session["LogedUserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // POST: Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SkillID,Title,Niveau,Logo")] Skills skills, HttpPostedFileBase file)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (ModelState.IsValid)
                    {
                        if (file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Templates/img" + "/"), fileName);
                            skills.Logo = "~/Templates/img/" + fileName;
                            file.SaveAs(path);
                            db.Skills.Add(skills);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        RedirectToAction("Create", "skills");
                    }


                    return View(skills);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {

                if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Skills skills = db.Skills.Find(id);
                    if (skills == null)
                    {
                        return HttpNotFound();
                    }
                    return View(skills);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SkillID,Title,Niveau,Logo")] Skills skills)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(skills).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(skills);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Skills skills = db.Skills.Find(id);
                if (skills == null)
                {
                    return HttpNotFound();
                }
                return View(skills);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {

                Skills skills = db.Skills.Find(id);
                db.Skills.Remove(skills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
