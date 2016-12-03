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
using PagedList;

namespace Final_CV.Controllers
{
    public class ExperiencesController : Controller
    {
        private DAL db = new DAL();

        // GET: Experiences
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {

                    var exps = db.Experiences.ToList();
                    var listexps = from d in db.Experiences
                                     select d;
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        listexps = listexps.Where(s => s.Title.Contains(searchString));
                    }
                    var list = new PagedList<Experience>(listexps.ToList(), page, pageSize);
                    return View(list);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }

        }

        // GET: Experiences/Details/5
        public ActionResult Details(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                     if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Experience experience = db.Experiences.Find(id);
                    if (experience == null)
                    {
                        return HttpNotFound();
                    }
                    return View(experience);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Experiences/Create
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

        // POST: Experiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExperienceID,Year,Title,Description,CampanyName,CampanySite,ReferenceName,ReferenceContact")] Experience experience)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Experiences.Add(experience);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(experience);
                }
                else
                {
                    return RedirectToAction("NotFound", "Home");
                }
        }

        // GET: Experiences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {

                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            return View(experience);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }

        }

        // POST: Experiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExperienceID,Year,Title,Description,CampanyName,CampanySite,ReferenceName,ReferenceContact")] Experience experience)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(experience).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                 return View(experience);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Experiences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experience experience = db.Experiences.Find(id);
            if (experience == null)
            {
                return HttpNotFound();
            }
            return View(experience);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                Experience experience = db.Experiences.Find(id);
            db.Experiences.Remove(experience);
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
