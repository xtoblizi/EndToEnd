using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EndToEnd.Models;

namespace EndToEnd.Controllers
{
    public class StaffLoginsController : BaseController
    {
       // private FinCoreDB db = new FinCoreDB();

        // GET: StaffLogins
        public ActionResult Index()
        {
            return View(db.StaffLogins.ToList());
        }

        // GET: StaffLogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffLogin staffLogin = db.StaffLogins.Find(id);
            if (staffLogin == null)
            {
                return HttpNotFound();
            }
            return View(staffLogin);
        }

        // GET: StaffLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ActivityLogType,Description,DateCreated,Active")] StaffLogin staffLogin)
        {
            if (ModelState.IsValid)
            {
                db.StaffLogins.Add(staffLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(staffLogin);
        }

        // GET: StaffLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffLogin staffLogin = db.StaffLogins.Find(id);
            if (staffLogin == null)
            {
                return HttpNotFound();
            }
            return View(staffLogin);
        }

        // POST: StaffLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ActivityLogType,Description,DateCreated,Active")] StaffLogin staffLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staffLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staffLogin);
        }

        // GET: StaffLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffLogin staffLogin = db.StaffLogins.Find(id);
            if (staffLogin == null)
            {
                return HttpNotFound();
            }
            return View(staffLogin);
        }

        // POST: StaffLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaffLogin staffLogin = db.StaffLogins.Find(id);
            db.StaffLogins.Remove(staffLogin);
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
