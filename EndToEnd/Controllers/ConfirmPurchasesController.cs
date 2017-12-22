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
    public class ConfirmPurchasesController : BaseController
    {
       // private FinCoreDB db = new FinCoreDB();

        // GET: ConfirmPurchases
        public ActionResult Index()
        {
            return View(db.ConfirmPurchase.ToList());
        }

        // GET: ConfirmPurchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmPurchase confirmPurchase = db.ConfirmPurchase.Find(id);
            if (confirmPurchase == null)
            {
                return HttpNotFound();
            }
            return View(confirmPurchase);
        }

        // GET: ConfirmPurchases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConfirmPurchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,StatusOfPurchase,Amount,DateOfPayment,Active")] ConfirmPurchase confirmPurchase)
        {
            if (ModelState.IsValid)
            {
                db.ConfirmPurchase.Add(confirmPurchase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(confirmPurchase);
        }

        // GET: ConfirmPurchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmPurchase confirmPurchase = db.ConfirmPurchase.Find(id);
            if (confirmPurchase == null)
            {
                return HttpNotFound();
            }
            return View(confirmPurchase);
        }

        // POST: ConfirmPurchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,StatusOfPurchase,Amount,DateOfPayment,Active")] ConfirmPurchase confirmPurchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(confirmPurchase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(confirmPurchase);
        }

        // GET: ConfirmPurchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfirmPurchase confirmPurchase = db.ConfirmPurchase.Find(id);
            if (confirmPurchase == null)
            {
                return HttpNotFound();
            }
            return View(confirmPurchase);
        }

        // POST: ConfirmPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConfirmPurchase confirmPurchase = db.ConfirmPurchase.Find(id);
            db.ConfirmPurchase.Remove(confirmPurchase);
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
