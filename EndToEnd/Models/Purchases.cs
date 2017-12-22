using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class Purchases
    {
        public int ID { get; set; }
        public string BankCode { get; set; }


        public decimal Amount { get; set; }
        public DropDown.PurchaseType PurchaseType { get; set; }
        public DropDown.BankName BankName { get; set; }
        public DateTime DatePurchased { get; set; }


    }
}