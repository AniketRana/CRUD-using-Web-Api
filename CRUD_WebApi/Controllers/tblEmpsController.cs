using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_WebApi.Models;

namespace CRUD_WebApi.Controllers
{
    public class tblEmpsController : Controller
    {
        private TestDBEntities db = new TestDBEntities();

        // GET: api/Customers  
        public IQueryable<tblEmp> GetEmp() 
        {
            return db.tblEmps;
        }

        // GET: tblEmps
        // get all employee
        public ActionResult Index()
        {
            return View(db.tblEmps.ToList());
        }

        // GET: tblEmps/Details/5
        // get single record for details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmp tblEmp = db.tblEmps.Find(id);
            if (tblEmp == null)
            {
                return HttpNotFound();
            }
            return View(tblEmp);
        }

        // GET: tblEmps/Create 
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblEmps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpID,Name,City,MobileNo,birthdate,Email")] tblEmp tblEmp)
        {
            if (ModelState.IsValid)
            {
                db.tblEmps.Add(tblEmp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEmp);
        }

        // GET: tblEmps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmp tblEmp = db.tblEmps.Find(id);
            if (tblEmp == null)
            {
                return HttpNotFound();
            }
            return View(tblEmp);
        }

        // POST: tblEmps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpID,Name,City,MobileNo,birthdate,Email")] tblEmp tblEmp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEmp);
        }

        // GET: tblEmps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmp tblEmp = db.tblEmps.Find(id);
            if (tblEmp == null)
            {
                return HttpNotFound();
            }
            return View(tblEmp);
        }

        // POST: tblEmps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmp tblEmp = db.tblEmps.Find(id);
            db.tblEmps.Remove(tblEmp);
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
