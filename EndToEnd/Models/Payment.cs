using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public decimal Amount { get; set; }

        [NotMapped]
        [DisplayName("Payment Type")]
        public DropDown.PurchaseType PaymentTypeList { get; set; }
        public string PaymentType { get; set; }


        [NotMapped]
        [DisplayName("Bank Name")]
        public DropDown.BankName BankNameList { get; set; }
        public string BankName { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Date Of Payment")]
        public DateTime DateOfPayment { get; set; }

        public string TellerId { get; set; }

        [DisplayName("Payment By")]
        public string SmsUserId { get; set; }

        public virtual SmsUser SmsUser { get; set; }
    }
}