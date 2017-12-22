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
    public class BankDetailsController : BaseController
    {
        // private FinCoreDB db = new FinCoreDB();

        // GET: BankDetails
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.BankDetails.ToList());
        }

        // GET: BankDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankDetail bankDetails = db.BankDetails.Find(id);
            if (bankDetails == null)
            {
                return HttpNotFound();
            }
            return View(bankDetails);
        }

        // GET: BankDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BankDetail bankDetails)
        {
            if (ModelState.IsValid)
            {
                db.BankDetails.Add(bankDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bankDetails);
        }

        // GET: BankDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankDetail bankDetails = db.BankDetails.Find(id);
            if (bankDetails == null)
            {
                return HttpNotFound();
            }
            return View(bankDetails);
        }

        // POST: BankDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BanCode,BankName,Address,State,PhoneNumber,Email,LunchDate,CreatedBy,DateCreated,Status")] BankDetail bankDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bankDetails);
        }

        // GET: BankDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankDetail bankDetails = db.BankDetails.Find(id);
            if (bankDetails == null)
            {
                return HttpNotFound();
            }
            return View(bankDetails);
        }

        // POST: BankDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankDetail bankDetails = db.BankDetails.Find(id);
            db.BankDetails.Remove(bankDetails);
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
