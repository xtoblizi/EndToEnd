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
    public class SendSmsController : BaseController
    {
      //  private FinCoreDB db = new FinCoreDB();

        // GET: SendSms
        public async Task<ActionResult> Index()
        {
            return View(await db.SendSms.ToListAsync());
        }

        // GET: SendSms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SendSms sendSms = await db.SendSms.FindAsync(id);
            if (sendSms == null)
            {
                return HttpNotFound();
            }
            return View(sendSms);
        }

        // GET: SendSms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SendSms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SendSmsId,SendTo,Message,SendFrom,MsgHeader,AunthenticationId")] SendSms sendSms)
        {
            if (ModelState.IsValid)
            {
                db.SendSms.Add(sendSms);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sendSms);
        }

        // GET: SendSms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SendSms sendSms = await db.SendSms.FindAsync(id);
            if (sendSms == null)
            {
                return HttpNotFound();
            }
            return View(sendSms);
        }

        // POST: SendSms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SendSmsId,SendTo,Message,SendFrom,MsgHeader,AunthenticationId")] SendSms sendSms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sendSms).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sendSms);
        }

        // GET: SendSms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SendSms sendSms = await db.SendSms.FindAsync(id);
            if (sendSms == null)
            {
                return HttpNotFound();
            }
            return View(sendSms);
        }

        // POST: SendSms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SendSms sendSms = await db.SendSms.FindAsync(id);
            db.SendSms.Remove(sendSms);
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
