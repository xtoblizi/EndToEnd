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
    [Authorize]
    public class SmsAmountsController : BaseController
    {
      //  private FinCoreDB db = new FinCoreDB();

        // GET: SmsAmounts
        public ActionResult Index()
        {
            return View(db.SmsAmount.ToList());
        }

        // GET: SmsAmounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmsAmount smsAmount = db.SmsAmount.Find(id);
            if (smsAmount == null)
            {
                return HttpNotFound();
            }
            return View(smsAmount);
        }

        // GET: SmsAmounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SmsAmounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,SmsUnit,Amount,Date")] SmsAmount smsAmount)
        {
            if (ModelState.IsValid)
            {
                db.SmsAmount.Add(smsAmount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(smsAmount);
        }

        // GET: SmsAmounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmsAmount smsAmount = db.SmsAmount.Find(id);
            if (smsAmount == null)
            {
                return HttpNotFound();
            }
            return View(smsAmount);
        }

        // POST: SmsAmounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,SmsUnit,Amount,Date")] SmsAmount smsAmount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smsAmount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smsAmount);
        }

        // GET: SmsAmounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmsAmount smsAmount = db.SmsAmount.Find(id);
            if (smsAmount == null)
            {
                return HttpNotFound();
            }
            return View(smsAmount);
        }

        // POST: SmsAmounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SmsAmount smsAmount = db.SmsAmount.Find(id);
            db.SmsAmount.Remove(smsAmount);
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
