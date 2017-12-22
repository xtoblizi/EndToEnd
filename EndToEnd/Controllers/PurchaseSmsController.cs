using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EndToEnd.Models;
using Microsoft.AspNet.Identity;

namespace EndToEnd.Controllers
{   [Authorize]
    public class PurchaseSmsController : BaseController
    {
      //  private FinCoreDB db = new FinCoreDB();

        // GET: PurchaseSms

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            var purchaseSms = db.PurchaseSms.AsNoTracking().Include(p => p.SmsUnit).Include(p => p.SmsUser);
            return View(await purchaseSms.ToListAsync());
        }


        public async Task<ActionResult> UserIndex(string message)
        {
            var purchaseSms = db.PurchaseSms.Include(p => p.SmsUnit).Include(p => p.SmsUser);

            ViewBag.Message = message;
            return View(await purchaseSms.ToListAsync());
        }

        // GET: PurchaseSms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseSms purchaseSms = await db.PurchaseSms.FindAsync(id);
            if (purchaseSms == null)
            {
                return HttpNotFound();
            }
            return View(purchaseSms);
        }

        // GET: PurchaseSms/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();

            ViewBag.SmsUnitId = new SelectList(db.SmsUnits.AsNoTracking(), "SmsUnitId", "SmsUnitName");
            ViewBag.SmsUserId = new SelectList(db.SmsUsers.AsNoTracking().Where(u => u.SmsUserId==userId), "SmsUserId", "DesiredNameForSms");
            return View();
        }

        // POST: PurchaseSms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PurchaseSms purchaseSms)
        {
            decimal? tokenCalculated = 0.00m;
            var smsUnitId = purchaseSms.SmsUnitId;
          //  methods from the base controller calculating the token purchased based on the amount specified
            if (InitCharge() != null)
            {
                tokenCalculated = purchaseSms.Amount / InitCharge();
            }

            if (TargetCharge(smsUnitId).Any())
            {
                var lastestChargeRate = TargetCharge(smsUnitId).OrderBy(c => c.CreateChargeRateId);
                var targetAmount = lastestChargeRate.First().Amount;
                tokenCalculated = purchaseSms.Amount / targetAmount;
            }
            // pass the calc value to the object instance property of token


            //try
            //{
                if (ModelState.IsValid)
                {
                    purchaseSms.Token = tokenCalculated;
                    purchaseSms.PurchaseSucceded = true;

                     db.PurchaseSms.Add(purchaseSms);

                    var userId = User.Identity.GetUserId();

                   AddSmsBalance(userId,purchaseSms.Amount,purchaseSms.Token);

                   await db.SaveChangesAsync();


                    ViewBag.Message = "Successful purchased";

                //+ "" + purchaseSms.Amount + "" + "worth of " + "" +
                //                      purchaseSms.SmsUnit.SmsUnitName;


                    return RedirectToAction("UserIndex" , new { message = ViewBag.Message});
                }
                else
                {
                    ViewBag.SmsUnitId = new SelectList(db.SmsUnits.AsNoTracking(), "SmsUnitId", "SmsUnitName", purchaseSms.SmsUnitId);
                    ViewBag.SmsUserId = new SelectList(db.SmsUsers.AsNoTracking(), "SmsUserId", "DesiredNameForSms", purchaseSms.SmsUserId);

                    ViewBag.Message = "Model state not valid";
                    return View(purchaseSms);
                }
           // }
            //catch (Exception e)
            //{
            //    ViewBag.SmsUnitId = new SelectList(db.SmsUnits.AsNoTracking(), "SmsUnitId", "SmsUnitName", purchaseSms.SmsUnitId);
            //    ViewBag.SmsUserId = new SelectList(db.SmsUsers.AsNoTracking(), "SmsUserId", "DesiredNameForSms", purchaseSms.SmsUserId);

            //    ViewBag.Message = e.ToString();
            //    return View(purchaseSms);
            //}

            //ViewBag.SmsUnitId = new SelectList(db.SmsUnits.AsNoTracking(), "SmsUnitId", "SmsUnitName", purchaseSms.SmsUnitId);
            //ViewBag.SmsUserId = new SelectList(db.SmsUsers.AsNoTracking(), "SmsUserId", "DesiredNameForSms", purchaseSms.SmsUserId);

            //ViewBag.Message = "Purchase was not successful, field items not properly filled";
            //return View(purchaseSms);
        }

        // GET: PurchaseSms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseSms purchaseSms = await db.PurchaseSms.FindAsync(id);
            if (purchaseSms == null)
            {
                return HttpNotFound();
            }
            ViewBag.SmsUnitId = new SelectList(db.SmsUnits.AsNoTracking(), "SmsUnitId", "SmsUnitName", purchaseSms.SmsUnitId);
            ViewBag.SmsUserId = new SelectList(db.SmsUsers.AsNoTracking(), "SmsUserId", "DesiredNameForSms", purchaseSms.SmsUserId);
            return View(purchaseSms);
        }

        // POST: PurchaseSms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PurchaseSmsId,Amount,DateOfPurchase,SmsUnitId,SmsUserId")] PurchaseSms purchaseSms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseSms).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SmsUnitId = new SelectList(db.SmsUnits.AsNoTracking(), "SmsUnitId", "SmsUnitName", purchaseSms.SmsUnitId);
            ViewBag.SmsUserId = new SelectList(db.SmsUsers.AsNoTracking(), "SmsUserId", "DesiredNameForSms", purchaseSms.SmsUserId);
            return View(purchaseSms);
        }

        // GET: PurchaseSms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseSms purchaseSms = await db.PurchaseSms.FindAsync(id);
            if (purchaseSms == null)
            {
                return HttpNotFound();
            }
            return View(purchaseSms);
        }

        // POST: PurchaseSms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PurchaseSms purchaseSms = await db.PurchaseSms.FindAsync(id);
            db.PurchaseSms.Remove(purchaseSms);
            await db.SaveChangesAsync();
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
