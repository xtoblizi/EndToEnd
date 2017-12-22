using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class ConfirmPurchase
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public DropDown.StatusOfPurchase StatusOfPurchase { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfPayment { get; set; }
        public bool Active { get; set; }
    }
}