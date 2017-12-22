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
    [Authorize(Roles = "Administrator")]
    public class SmsUnitsController : BaseController
    {
       // private FinCoreDB db = new FinCoreDB();

        // GET: SmsUnits
        public async Task<ActionResult> Index()
        {
            var smsUnits = db.SmsUnits.Include(s => s.EnteredBy);
            return View(await smsUnits.ToListAsync());
        }

        // GET: SmsUnits/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmsUnit smsUnit = await db.SmsUnits.FindAsync(id);
            if (smsUnit == null)
            {
                return HttpNotFound();
            }
            return View(smsUnit);
        }

        // GET: SmsUnits/Create
        public ActionResult Create()
        {
            //var user = db.Users.Where(u => u.Id.Equals(LoggedUser));
            ViewBag.ApplicationUserId = new SelectList(db.Users.Where(u=>u.Id==LoggedUser), "Id", "FirstName");
            return View();
        }

        // POST: SmsUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SmsUnit smsUnit)
        {
            if (ModelState.IsValid)
            {
                db.SmsUnits.Add(smsUnit);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
              ViewBag.ApplicationUserId = new SelectList(db.Users.Where(u=>u.Id.Equals(LoggedUser)), "Id", "FirstName", smsUnit.ApplicationUserId);

            //var user = db.Users.Where(u => u.Id.Equals(LoggedUser));
            //ViewBag.ApplicationUserId = new SelectList(user, "Id", "FirstName");

            return View(smsUnit);
        }

        // GET: SmsUnits/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmsUnit smsUnit = await db.SmsUnits.FindAsync(id);
            if (smsUnit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", smsUnit.ApplicationUserId);
            return View(smsUnit);
        }

        // POST: SmsUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SmsUnitId,Unit,Cost,DateCreated,ApplicationUserId")] SmsUnit smsUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smsUnit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", smsUnit.ApplicationUserId);
            return View(smsUnit);
        }

        // GET: SmsUnits/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmsUnit smsUnit = await db.SmsUnits.FindAsync(id);
            if (smsUnit == null)
            {
                return HttpNotFound();
            }
            return View(smsUnit);
        }

        // POST: SmsUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SmsUnit smsUnit = await db.SmsUnits.FindAsync(id);
            db.SmsUnits.Remove(smsUnit);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

       
    }
}
