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
using System.Security.Cryptography;
using System.Text;

namespace Final_CV.Controllers
{
    public class CvsController : Controller
    {
        private DAL db = new DAL();

        // GET: Cvs
        public ActionResult Index()
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                return View(db.Cvs.ToList());
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Cvs/Details/5
        public ActionResult Details(int? id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {
                   if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Cv cv = db.Cvs.Find(id);
                    if (cv == null)
                    {
                        return HttpNotFound();
                    }
                    return View(cv);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Cvs/Create
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

        // POST: Cvs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CvID,Title,Login,Password")] Cv cv)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {


                if (ModelState.IsValid)
                    {
                       // cv.Password = this.GetMD5HashData(cv.Password);
                        db.Cvs.Add(cv);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                 return View(cv);
             }
            else
            {
            return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Cvs/Edit/5
        public ActionResult Edit(int? id)
        {

            if (HttpContext.Session["LogedUserName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cv cv = db.Cvs.Find(id);
                if (cv == null)
                {
                    return HttpNotFound();
                }
                return View(cv);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // POST: Cvs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CvID,Title,Login,Password")] Cv cv)
        {

            if (HttpContext.Session["LogedUserName"] != null)
            {

                if (ModelState.IsValid)
                {
                    db.Entry(cv).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cv);
            }
            else
            {
                return RedirectToAction("NotFound", "Home");
            }
        }

        // GET: Cvs/Delete/5
        public ActionResult Delete(int? id)
        {

                if (HttpContext.Session["LogedUserName"] != null)
                {

                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Cv cv = db.Cvs.Find(id);
                    if (cv == null)
                    {
                        return HttpNotFound();
                    }
                    return View(cv);
                }
                else
                {
                    return RedirectToAction("NotFound", "Home");
                }
         }

        // POST: Cvs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session["LogedUserName"] != null)
            {

                Cv cv = db.Cvs.Find(id);
                db.Cvs.Remove(cv);
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
    }
}
