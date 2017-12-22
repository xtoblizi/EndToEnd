using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using EndToEnd.Models;
using EndToEnd.Models.Repository;
using Microsoft.Ajax.Utilities;

namespace EndToEnd.Models
{
    // Note this table respresents the Tokens that sms users can use to send sms and perform  availed transactions
    [TableName("TokenUnit")]
    public class SmsUnit
    {
        [Key]
        public int SmsUnitId { get; set; }

        public string SmsUnitName { get; set; }

        public decimal Unit { get; set; }

        public decimal Cost { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [DisplayName("Entered By")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser EnteredBy{ get; set; }

    }// end of SmsUnit


    public class SendSms
    {
        // uses SendSms ViewModel for sms sending
        public int SendSmsId { get; set; }

        public string SendTo { get; set; }

        public string Message { get; set; }

        public string SendFrom { get; set; }

        public string MsgHeader { get; set; }

        public DateTime? DateTimeDelivered { get; set; }

        public bool? HasDelivered { get; set; }

        //nav props

        //public TYPE SmsUnit { get; set; }

        public int AunthenticationId { get; set; }

        public virtual Authentication Authentication { get; set; }

    }


    public class PurchaseSms
    {
        private readonly FinCoreDB db = new FinCoreDB();
        public int PurchaseSmsId { get; set; }

        public decimal Amount { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DateOfPurchase { get; set; }=DateTime.Now;

        public bool PurchaseSucceded { get; set; } = false;

        // nav props

        public decimal? Token { get; set; }
        public int SmsUnitId { get; set; }
        public virtual SmsUnit SmsUnit { get; set; }

        public string SmsUserId { get; set; }
        public virtual SmsUser SmsUser { get; set; }
        //public decimal? InitCharge()
        //{
        //    var initCharge = db.CreateChargeRates.AsNoTracking().FirstOrDefault(c => c.SmsUnit.Unit.Equals(1));
        //    return initCharge?.Amount;
        //}

        //public List<CreateChargeRate> TargetCharge()
        //{
        //    var targetCharge = db.CreateChargeRates.AsNoTracking().Where(c => c.SmsUnitId == this.SmsUnit.SmsUnitId);
        //    return targetCharge.ToList();
        //}


        //  
        //  public decimal? Token 
        //     {
        //    get
        //    {
        //        //var initCharge = db.CreateChargeRates.AsNoTracking().FirstOrDefault(c => c.SmsUnit.Unit.Equals(1)).Amount;

        //        if (InitCharge() != null)
        //        {
        //            var token = this.Amount / InitCharge();
        //        }

        //        else if (TargetCharge().Any())
        //        {
        //            var lastestChargeRate = TargetCharge().OrderBy(c => c.CreateChargeRateId);
        //            var token = lastestChargeRate.First().Amount;
        //            return this.Amount / token;
        //        }
        //        return 0;
        //    }
        //    set { }
        //}


    }

}