using EndToEnd.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace EndToEnd.Controllers
{
    public class BaseController : Controller
    {
        public FinCoreDB db;

        public BaseController()
        {
            db = new FinCoreDB();

        }

        public decimal SmsBalance { get; set; }

        private string _UserRole
        {
            get { return GetUserRole(); }

            set { }
        }

        public string LoggedUser
        {
            get { return GetLoggedInUser(); }

            set { }
        }

        //retreive charge rate of an initiating smsunit be 1unit
        public decimal? InitCharge()
        {
            var initCharge = db.CreateChargeRates.AsNoTracking().Where(c => c.SmsUnit.Unit.Equals(1m));
            if (initCharge.Any())
            { return initCharge.First().Amount; }


            return 0m;

        }
        public List<CreateChargeRate>  TargetCharge(int id)
        {
            var targetCharge = db.CreateChargeRates.AsNoTracking().Where(c => c.SmsUnitId == id);
            return  targetCharge.ToList();
        }
        // working to get the amount for purchase initiated



        // GET: Base
        public string GetLoggedInUser()
        {
            var userLoggedIn = "None";
            userLoggedIn = User.Identity.GetUserId();

            return userLoggedIn;
        }
        public string GetUserRole()
        {
            var userRole = "None";
            //userLoggedIn = User.Identity.GetUserId();
            if (User.IsInRole("Administrator"))
            {
               userRole = "Administrator";
                return userRole;
            }
            else if (User.IsInRole("Subscriber"))
            {
                userRole = "Subscriber";
                return userRole;
            }
            else if (User.IsInRole("Staff"))
            {
                userRole = "Staff";
                return userRole;
            }
            else if (User.IsInRole("Company"))
            {
                userRole = "Company";
                return userRole;
            }


            return userRole;
        }


        public int? StaffCompany (string userRole)
        {
            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            var staffCompanyId = db.Staffs.SingleOrDefault(b => b.StaffId == LoggedUser).CompanyId;

            return staffCompanyId;
        }

        //public void SetBalance(string id)
        //{
        //    if (id != null)
        //    {
        //        var userBalance = new UserTokenBalance()
        //        {



        //        };

        //    }
        //}

        public decimal GetSmsBalance(string id)
        {
            decimal userBalance = 0;

            if (id == null)
            {
                id = User.Identity.GetUserId();
            }
            if (LoggedUser != null)
            {

                var count = db.UserTokenBalances.AsNoTracking().Where(b => b.SmsUserId == id);
                if (count.Any())
                {
                    decimal retreived= count.OrderByDescending(b=>b.Datecreated).First().AmountBalance;

                    userBalance = retreived;
                    return userBalance;
                }

            }
            return userBalance;
        }

         public async void AddSmsBalance(string id, decimal amountAcquired, decimal? tokenToAdd)
        {
            if (id == null)
            {
                id = this.LoggedUser;
            }
            var selectCurentChargeRecord = db.CreateChargeRates.AsNoTracking().
                                            Where(c => c.SmsUnit.Unit == 1).
                                            OrderByDescending(c=>c.DateCreated);

            var getCurrentChargeAmount = selectCurentChargeRecord.First().Amount;

            var amountToAdd = amountAcquired / getCurrentChargeAmount;


           var checkBalanceRecord = db.UserTokenBalances.AsNoTracking().Where(c => c.SmsUserId == id).OrderByDescending(c=>c.Datecreated);
             //var getAmount = newBalance.First().AmountBalance + amountToAdd;
            if (checkBalanceRecord.Any())
            {
                amountToAdd += checkBalanceRecord.First().AmountBalance ;
                tokenToAdd += checkBalanceRecord.First().TokenBalance;
            }
                var addUserTokenBalance = new UserTokenBalance()
                {
                    SmsUserId = LoggedUser,
                    TokenBalance = tokenToAdd,
                    AmountBalance =+ amountToAdd,

                };
                db.UserTokenBalances.Add(addUserTokenBalance);

            //}

            //db.UserTokenBalances.First(c => c.SmsUserId == id).AmountBalance = newBalance;

           // db.SaveChangesAsync();

          //  this.SmsBalance = newBalance;

        }

        public void DeductBalance(string id, decimal amount)
        {
            var getCurrentChargeAmount = db.CreateChargeRates.First(c => c.SmsUnit.Unit == 1).Amount;

            var amountToDeduct = amount / getCurrentChargeAmount;
            var newBalance = db.UserTokenBalances.First(c => c.SmsUserId == id).AmountBalance - amountToDeduct;

            db.UserTokenBalances.First(c => c.SmsUserId == id).AmountBalance = newBalance;
            db.UserTokenBalances.AddOrUpdate();
            db.SaveChangesAsync();

            this.SmsBalance = newBalance;

        }


        // Garbabe disposal
        //private bool _disposed = false;
        //protected new virtual void Dispose(bool disposing)
        //{
        //    if (!this._disposed)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //    }
        //    this._disposed = true;
        //}

        //public new void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

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