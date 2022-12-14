using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Csharp;

namespace Csharp.Controllers
{
    public class StudentMarksheetsController : Controller
    {
        private csharpEntities db = new csharpEntities();

        // GET: StudentMarksheets
        public ActionResult Index()
        {
            return View(db.StudentMarksheets.ToList());
        }

        // GET: StudentMarksheets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMarksheet studentMarksheet = db.StudentMarksheets.Find(id);
            if (studentMarksheet == null)
            {
                return HttpNotFound();
            }
            return View(studentMarksheet);
        }

        // GET: StudentMarksheets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentMarksheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,StudentName,TamilMark,EnglishMark,MathsMark,ScienceMark,SocialMark,TotalMark")] StudentMarksheet studentMarksheet)
        {
            if (ModelState.IsValid)
            {
                db.StudentMarksheets.Add(studentMarksheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentMarksheet);
        }

        // GET: StudentMarksheets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMarksheet studentMarksheet = db.StudentMarksheets.Find(id);
            if (studentMarksheet == null)
            {
                return HttpNotFound();
            }
            return View(studentMarksheet);
        }

        // POST: StudentMarksheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StudentName,TamilMark,EnglishMark,MathsMark,ScienceMark,SocialMark,TotalMark")] StudentMarksheet studentMarksheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentMarksheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentMarksheet);
        }

        // GET: StudentMarksheets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentMarksheet studentMarksheet = db.StudentMarksheets.Find(id);
            if (studentMarksheet == null)
            {
                return HttpNotFound();
            }
            return View(studentMarksheet);
        }

        // POST: StudentMarksheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentMarksheet studentMarksheet = db.StudentMarksheets.Find(id);
            db.StudentMarksheets.Remove(studentMarksheet);
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
