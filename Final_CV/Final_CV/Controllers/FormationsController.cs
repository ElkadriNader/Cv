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
    public class FormationsController : Controller
    {
        private DAL db = new DAL();

        // GET: Formations
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {

                var formations = db.Formations.ToList();
                var listfor = from d in db.Formations
                               select d;
                if (!String.IsNullOrEmpty(searchString))
                {
                    listfor = listfor.Where(s => s.Title.Contains(searchString));
                }
                var listFormations = new PagedList<Formations>(listfor.ToList(), page, pageSize);
                return View(listFormations);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }



        }

        // GET: Formations/Details/5
        public ActionResult Details(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Formations formations = db.Formations.Find(id);
                if (formations == null)
                {
                    return HttpNotFound();
                }
                return View(formations);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Formations/Create
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

        // POST: Formations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormationID,Year,Title,Place,Description,ReferenceName,ReferenceMail,ReferencePhone")] Formations formations)
        {

            if (HttpContext.Session["LogedUserName"] != null)
            {

                if (ModelState.IsValid)
            {
                db.Formations.Add(formations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formations);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }

        }

        // GET: Formations/Edit/5
        public ActionResult Edit(int? id)
        {

            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Formations formations = db.Formations.Find(id);
                if (formations == null)
                {
                    return HttpNotFound();
                }
                return View(formations);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // POST: Formations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormationID,Year,Title,Place,Description,ReferenceName,ReferenceMail,ReferencePhone")] Formations formations)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {

                if (ModelState.IsValid)
                {
                    db.Entry(formations).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(formations);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }

        }

        // GET: Formations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Formations formations = db.Formations.Find(id);
                    if (formations == null)
                    {
                        return HttpNotFound();
                    }
                    return View(formations);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // POST: Formations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                Formations formations = db.Formations.Find(id);
                db.Formations.Remove(formations);
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
