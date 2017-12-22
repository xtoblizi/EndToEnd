using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class SmsTransaction
    {
        public int ID { get; set; }
        public int PurchaseTypeID { get; set; }
        public string BankCode { get; set; }
        public DropDown.PurchaseType PurchaseType { get; set; }
        public string Description { get; set; }
        public DropDown.StatusOfPurchase StatusOfPurchase { get; set; }
        public decimal SmsUnit { get; set; }
        public decimal Amount { get; set; }
        public string PurchasedBy { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool Active { get; set; }

    }
}