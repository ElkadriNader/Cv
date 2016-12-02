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
    public class ContactsController : Controller
    {
        private DAL db = new DAL();
        //test
        //

        // GET: Contacts
        public ActionResult Index()
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                return View(db.Contacts.ToList());
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Contact contact = db.Contacts.Find(id);
                if (contact == null)
                {
                    return HttpNotFound();
                }
                return View(contact);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
            }

        // GET: Contacts/Create
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

// POST: Contacts/Create
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactID,Label,value,Logo")] Contact contact)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {

                if (ModelState.IsValid)
                    {
                        db.Contacts.Add(contact);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                 return View(contact);
                }
                else
                {
                    return RedirectToAction("NotFound", "Home");
                }
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {

                if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Contact contact = db.Contacts.Find(id);
                    if (contact == null)
                    {
                        return HttpNotFound();
                    }
                    return View(contact);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }


        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactID,Label,value,Logo")] Contact contact)
        {

            if (HttpContext.Session["LogedUserName"] != null)
            {


                if (ModelState.IsValid)
                    {
                        db.Entry(contact).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                 return View(contact);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }

        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {


                if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Contact contact = db.Contacts.Find(id);
                    if (contact == null)
                    {
                        return HttpNotFound();
                    }
                    return View(contact);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {

                Contact contact = db.Contacts.Find(id);
                db.Contacts.Remove(contact);
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
