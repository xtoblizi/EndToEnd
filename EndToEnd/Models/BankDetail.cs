using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class BankDetail
    {
        public int Id { get; set; }

        [DisplayName("Account Number")]
        public string AccountNumber { get; set; }

        [DisplayName("Bank Name")]
        public DropDown.BankName BankName { get; set; }

        public string Address { get; set; }
        public string State { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public DropDown.StatusType Status { get; set; }

    }
}