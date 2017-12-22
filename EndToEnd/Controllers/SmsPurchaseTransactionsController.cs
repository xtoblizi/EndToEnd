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
    public class SmsPurchaseTransactionsController : BaseController
    {
        //private FinCoreDB db = new FinCoreDB();

        // GET: SmsPurchaseTransactions
        public ActionResult Index()
        {
            return View(db.SmsPurchaseTransaction.ToList());
        }

        // GET: SmsPurchaseTransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmsTransaction smsTransaction = db.SmsPurchaseTransaction.Find(id);
            if (smsTransaction == null)
            {
                return HttpNotFound();
            }
            return View(smsTransaction);
        }

        // GET: SmsPurchaseTransactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SmsPurchaseTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PurchaseTypeID,BankCode,PurchaseType,Description,StatusOfPurchase,SmsUnit,Amount,PurchasedBy,PhoneNumber,Email,TransactionDate,Active")] SmsTransaction smsTransaction)
        {
            if (ModelState.IsValid)
            {
                db.SmsPurchaseTransaction.Add(smsTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(smsTransaction);
        }

        // GET: SmsPurchaseTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmsTransaction smsTransaction = db.SmsPurchaseTransaction.Find(id);
            if (smsTransaction == null)
            {
                return HttpNotFound();
            }
            return View(smsTransaction);
        }

        // POST: SmsPurchaseTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PurchaseTypeID,BankCode,PurchaseType,Description,StatusOfPurchase,SmsUnit,Amount,PurchasedBy,PhoneNumber,Email,TransactionDate,Active")] SmsTransaction smsTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smsTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(smsTransaction);
        }

        // GET: SmsPurchaseTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmsTransaction smsTransaction = db.SmsPurchaseTransaction.Find(id);
            if (smsTransaction == null)
            {
                return HttpNotFound();
            }
            return View(smsTransaction);
        }

        // POST: SmsPurchaseTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SmsTransaction smsTransaction = db.SmsPurchaseTransaction.Find(id);
            db.SmsPurchaseTransaction.Remove(smsTransaction);
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
