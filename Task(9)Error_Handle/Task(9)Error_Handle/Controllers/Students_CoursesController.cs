using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task_9_Error_Handle.Models;

namespace Task_9_Error_Handle.Controllers
{
    public class Students_CoursesController : Controller
    {
        private MVCEntities db = new MVCEntities();

        // GET: Students_Courses
        public ActionResult Index()
        {
            var students_Courses = db.Students_Courses.Include(s => s.Cours).Include(s => s.student);
            return View(students_Courses.ToList());
        }

        // GET: Students_Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_Courses students_Courses = db.Students_Courses.Find(id);
            if (students_Courses == null)
            {
                return HttpNotFound();
            }
            return View(students_Courses);
        }

        // GET: Students_Courses/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "Name");
            return View();
        }

        // POST: Students_Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentId,CourseId,Notes")] Students_Courses students_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Students_Courses.Add(students_Courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", students_Courses.CourseId);
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "Name", students_Courses.StudentId);
            return View(students_Courses);
        }

        // GET: Students_Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_Courses students_Courses = db.Students_Courses.Find(id);
            if (students_Courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", students_Courses.CourseId);
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "Name", students_Courses.StudentId);
            return View(students_Courses);
        }

        // POST: Students_Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentId,CourseId,Notes")] Students_Courses students_Courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students_Courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", students_Courses.CourseId);
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "Name", students_Courses.StudentId);
            return View(students_Courses);
        }

        // GET: Students_Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students_Courses students_Courses = db.Students_Courses.Find(id);
            if (students_Courses == null)
            {
                return HttpNotFound();
            }
            return View(students_Courses);
        }

        // POST: Students_Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students_Courses students_Courses = db.Students_Courses.Find(id);
            db.Students_Courses.Remove(students_Courses);
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
