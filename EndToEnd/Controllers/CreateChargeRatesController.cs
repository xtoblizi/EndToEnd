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
    [Authorize(Roles = "Administrator" )]
    public class CreateChargeRatesController : BaseController
    {
        // GET: CreateChargeRates
        public async Task<ActionResult> Index()
        {
            var createChargeRates = db.CreateChargeRates.AsNoTracking().OrderByDescending(c=>c.DateCreated).Include(c => c.SmsUnit);
            ViewBag.SmsUnitId = new SelectList(db.SmsUnits, "SmsUnitId", "SmsUnitName");


            return View(await createChargeRates.ToListAsync());
        }


        [HttpGet]
        public async Task<ActionResult> CurrentRate()
        {
            var currrentRate = db.CreateChargeRates.AsNoTracking().Include(c => c.SmsUnit).Where(c => c.CreateChargeRateId == 1);
            return View(await currrentRate.ToListAsync());
        }

        // GET: CreateChargeRates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateChargeRate createChargeRate = await db.CreateChargeRates.FindAsync(id);
            if (createChargeRate == null)
            {
                return HttpNotFound();
            }
            return View(createChargeRate);
        }

        // GET: CreateChargeRates/Create
        public ActionResult Create()
        {
            var smsUnitList = db.SmsUnits.AsNoTracking().ToList();
            ViewBag.SmsUnitId = new SelectList(smsUnitList, "SmsUnitId", "SmsUnitName");
            return View();
        }

        // POST: CreateChargeRates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateChargeRate createChargeRate)
        {
            if (ModelState.IsValid)
            {
                db.CreateChargeRates.Add(createChargeRate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SmsUnitId = new SelectList(db.SmsUnits.ToList(), "SmsUnitId", "SmsUnitName", createChargeRate.SmsUnitId);
            return View(createChargeRate);
        }

        // GET: CreateChargeRates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateChargeRate createChargeRate = await db.CreateChargeRates.FindAsync(id);
            if (createChargeRate == null)
            {
                return HttpNotFound();
            }
            ViewBag.SmsUnitId = new SelectList(db.SmsUnits, "SmsUnitId", "SmsUnitName", createChargeRate.SmsUnitId);
            return View(createChargeRate);
        }

        // POST: CreateChargeRates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CreateChargeRate createChargeRate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(createChargeRate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SmsUnitId = new SelectList(db.SmsUnits, "SmsUnitId", "SmsUnitName", createChargeRate.SmsUnitId);
            return View(createChargeRate);
        }

        // GET: CreateChargeRates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateChargeRate createChargeRate = await db.CreateChargeRates.FindAsync(id);
            if (createChargeRate == null)
            {
                return HttpNotFound();
            }
            return View(createChargeRate);
        }

        // POST: CreateChargeRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CreateChargeRate createChargeRate = await db.CreateChargeRates.FindAsync(id);
            db.CreateChargeRates.Remove(createChargeRate);
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
