using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EndToEnd.Models;
using Microsoft.AspNet.Identity;
using PagedList;

namespace EndToEnd.Controllers
{
    [Authorize]
    public class SmsUsersController : BaseController
    {
        //  private FinCoreDB db = new FinCoreDB();

        // GET: SmsUsers
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            return View(await db.SmsUsers.ToListAsync());
        }

        // GET: SmsUsers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmsUser smsUser = await db.SmsUsers.FindAsync(id);
            if (smsUser == null)
            {
                return HttpNotFound();
            }
            return View(smsUser);
        }

        // GET: SmsUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SmsUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SmsUser smsUser)        {
            if (ModelState.IsValid)
            {
                smsUser.State = smsUser.StateList.ToString();
                smsUser.Gender = smsUser.GenderList.ToString();

                db.SmsUsers.Add(smsUser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(smsUser);
        }

        // GET: SmsUsers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmsUser smsUser = await db.SmsUsers.FindAsync(id);
            if (smsUser == null)
            {
                return HttpNotFound();
            }
            return View(smsUser);
        }

        // POST: SmsUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( SmsUser smsUser)
        {
            if (ModelState.IsValid)
            {
                smsUser.State = smsUser.StateList.ToString();
                smsUser.Gender = smsUser.GenderList.ToString();

                db.Entry(smsUser).State = EntityState.Modified;
                await db.SaveChangesAsync();

                ViewBag.Message = "Profile data successfully edited and saved";
                return View();
            }
            return View(smsUser);
        }

        // GET: SmsUsers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmsUser smsUser = await db.SmsUsers.FindAsync(id);
            if (smsUser == null)
            {
                return HttpNotFound();
            }
            return View(smsUser);
        }

        // POST: SmsUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            SmsUser smsUser = await db.SmsUsers.FindAsync(id);
            db.SmsUsers.Remove(smsUser);
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

        public ActionResult DeativateList()
        {
             return View(db.SmsUsers.Where(s => s.Active == false).ToList());

        }

        public ActionResult Deativate(string id)
        {
            if (id == null)
            {
                id = User.Identity.GetUserId();
            }
            SmsUser smsUser = db.SmsUsers.Find(id);
            if (smsUser == null)
            {
                return HttpNotFound();
            }
            return View(smsUser);
        }
        [HttpPost]
        public async Task<ActionResult> Deativate(SmsUser smsUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smsUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(smsUser);
        }

        [HttpGet]
        public async Task<ActionResult> ActivateList(string message)
        {
            ViewBag.Message = message;
            return View(await db.SmsUsers.Where(s => s.Activated == false).ToListAsync());

        }

       
        public async void ActivateAction()
        {
              var  id = User.Identity.GetUserId();

            SmsUser smsUser = db.SmsUsers.Find(id);
            if (smsUser == null)
            {
                RedirectToAction ("ActivateList", new {message = "Activation not successful, try again"});
            }
            smsUser.Activated = true;

            db.Entry(smsUser).State = EntityState.Modified;
            await db.SaveChangesAsync();
            RedirectToAction ("ActivateList", new {message = "Activation was successful"});

        }

        //[HttpPost]
        //public async Task<ActionResult> Activate(SmsUser smsUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(smsUser).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(smsUser);
        //}

    }
}
