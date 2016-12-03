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
    public class LanguagesController : Controller
    {
        private DAL db = new DAL();

        // GET: Languages
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                    var langs = db.Languages.ToList();
                    var listlang= from d in db.Languages
                                  select d;
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        listlang = listlang.Where(s => s.Name.Contains(searchString));
                    }
                    var listDocs = new PagedList<Language>(listlang.ToList(), page, pageSize);
                    return View(listDocs);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }


        }

        // GET: Languages/Details/5
        public ActionResult Details(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Language language = db.Languages.Find(id);
                if (language == null)
                {
                    return HttpNotFound();
                }
                return View(language);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Languages/Create
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

        // POST: Languages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LangaugeID,Name,Niveau,Logo")] Language language,HttpPostedFileBase file)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (ModelState.IsValid)
                {
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Templates/img" + "/"), fileName);
                        language.Logo = "~/Templates/img/" + fileName;
                        file.SaveAs(path);
                        db.Languages.Add(language);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        RedirectToAction("Create", "Languages");
                    }

            }
            else
            {
                RedirectToAction("Create", "Languages");
            }

            return View(language);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Languages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Language language = db.Languages.Find(id);
                    if (language == null)
                    {
                        return HttpNotFound();
                    }
                    return View(language);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // POST: Languages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LangaugeID,Name,Logo")] Language language)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(language).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(language);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Languages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Language language = db.Languages.Find(id);
                if (language == null)
                {
                    return HttpNotFound();
                }
                return View(language);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                Language language = db.Languages.Find(id);
            db.Languages.Remove(language);
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
