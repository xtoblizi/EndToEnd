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

namespace EndToEnd.Controllers
{
    [Authorize]
    public class UserTokenBalancesController : BaseController
    {
       // private FinCoreDB db = new FinCoreDB();

        // GET: UserTokenBalances
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            var userTokenBalances = db.UserTokenBalances.Include(u => u.SmsUser);

            //string id = LoggedUser;
            //var currentBalanace = GetSmsBalance(id);
            //ViewBag.CurrentBalance = currentBalanace;

            return View(await userTokenBalances.ToListAsync());
        }

        public async Task<ActionResult> UserIndex()
        {
            var userTokenBalances = db.UserTokenBalances.Include(u => u.SmsUser);

            string id = LoggedUser;
            var currentBalanace = GetSmsBalance(id);

            ViewBag.CurrentBalance = currentBalanace;
            return View(await userTokenBalances.ToListAsync());
        }


        // GET: UserTokenBalances/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTokenBalance userTokenBalance = await db.UserTokenBalances.FindAsync(id);
            if (userTokenBalance == null)
            {
                return HttpNotFound();
            }
            return View(userTokenBalance);
        }

        // GET: UserTokenBalances/Create
        public ActionResult Create()
        {
            ViewBag.SmsUserId = new SelectList(db.SmsUsers, "SmsUserId", "DesiredNameForSms");
            return View();
        }

        // POST: UserTokenBalances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( UserTokenBalance userTokenBalance)
        {
            if (ModelState.IsValid)
            {
                db.UserTokenBalances.Add(userTokenBalance);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SmsUserId = new SelectList(db.SmsUsers, "SmsUserId", "DesiredNameForSms", userTokenBalance.SmsUserId);
            return View(userTokenBalance);
        }

        // GET: UserTokenBalances/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTokenBalance userTokenBalance = await db.UserTokenBalances.FindAsync(id);
            if (userTokenBalance == null)
            {
                return HttpNotFound();
            }
            ViewBag.SmsUserId = new SelectList(db.SmsUsers, "SmsUserId", "DesiredNameForSms", userTokenBalance.SmsUserId);
            return View(userTokenBalance);
        }

        // POST: UserTokenBalances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserTokenBalanceId,AmountBalance,TokenBalance,Datecreated,SmsUserId")] UserTokenBalance userTokenBalance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTokenBalance).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SmsUserId = new SelectList(db.SmsUsers, "SmsUserId", "DesiredNameForSms", userTokenBalance.SmsUserId);
            return View(userTokenBalance);
        }

        // GET: UserTokenBalances/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTokenBalance userTokenBalance = await db.UserTokenBalances.FindAsync(id);
            if (userTokenBalance == null)
            {
                return HttpNotFound();
            }
            return View(userTokenBalance);
        }

        // POST: UserTokenBalances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserTokenBalance userTokenBalance = await db.UserTokenBalances.FindAsync(id);
            db.UserTokenBalances.Remove(userTokenBalance);
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
