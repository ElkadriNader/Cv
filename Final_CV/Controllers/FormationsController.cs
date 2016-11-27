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

namespace Final_CV.Controllers
{
    public class FormationsController : Controller
    {
        private DAL db = new DAL();

        // GET: Formations
        public ActionResult Index()
        {
            return View(db.Formations.ToList());
        }

        // GET: Formations/Details/5
        public ActionResult Details(int? id)
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

        // GET: Formations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormationID,Year,Title,Place,Description,ReferenceName,ReferenceMail,ReferencePhone")] Formations formations)
        {
            if (ModelState.IsValid)
            {
                db.Formations.Add(formations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formations);
        }

        // GET: Formations/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Formations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormationID,Year,Title,Place,Description,ReferenceName,ReferenceMail,ReferencePhone")] Formations formations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formations);
        }

        // GET: Formations/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Formations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formations formations = db.Formations.Find(id);
            db.Formations.Remove(formations);
            db.SaveChanges();
            return RedirectToAction("Index");
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
