using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task_3_DataAnn;
using Task_3_DataAnn.Models;

namespace Task_3_DataAnn.Controllers
{
    public class CustomersController : Controller
    {
        private MVCEntities db = new MVCEntities();

        // GET: Customers
        public ActionResult Index(string searchBy ,string search ) 
        {
            if (searchBy == "Fname")
            {
                return View(db.Customers.Where(x => x.Fname.Contains(search) || search == null).ToList());
            }
            else if (searchBy == "Lname")
            {
                return View(db.Customers.Where(x => x.Lname.Contains(search) || search == null).ToList());
            }
            else
            {
                return View(db.Customers.Where(x => x.Email.Contains(search) || search == null).ToList());
            }
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fname,Lname,Email,Phone,Age,Job_Title,Gender")] Customer customer , HttpPostedFileBase imagefile, HttpPostedFileBase Cvfile)
        {
            if (ModelState.IsValid)
            {
                string path1 = "";
                string path2 = "";
                if (imagefile.FileName.Length > 0)
                {
                    path1 = Path.GetFileName(imagefile.FileName);
                    imagefile.SaveAs(Path.Combine(Server.MapPath("~/pic/"), imagefile.FileName));

                }
                if (Cvfile.FileName.Length > 0)
                {
                    path2 = Path.GetFileName(Cvfile.FileName);

                    Cvfile.SaveAs(Path.Combine(Server.MapPath("~/pdf/"), Cvfile.FileName));
                }

                customer.C_Image = path1;
                customer.CV = path2;
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            Session["photo"] = customer.C_Image;
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fname,Lname,Email,Phone,Age,Job_Title,Gender")] Customer customer , HttpPostedFileBase imagefile, HttpPostedFileBase Cvfile)
        {
            if (ModelState.IsValid)
            {
                string pathpic = "";
                string pathpdf = "";
                customer.C_Image= Session["photo"].ToString();

                if (imagefile != null)
                {
                    pathpic = Path.GetFileName(imagefile.FileName);
                    imagefile.SaveAs(Path.Combine(Server.MapPath("~/pic/"), imagefile.FileName));
                    customer.C_Image = pathpic;
                }

                if (Cvfile != null)
                {
                    pathpdf = Path.GetFileName(Cvfile.FileName);

                    Cvfile.SaveAs(Path.Combine(Server.MapPath("~/pdf/"), Cvfile.FileName));
                    customer.CV = pathpdf;
                }
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
