using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace EndToEnd.Models
{
    public class Staff : Person
    {
        public string StaffId { get; set; }
        public string BankCode { get; set; }
        public string StaffCode { get; set; }
        public string Level { get; set; }
        public DropDown.UserGroupList UserGroupList  { get; set; }

       // public UserGroup UserGroup { get; set; }

        public int AuthId { get; set; }
        public virtual Authentication Authentication { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }


        public int UserTypeId { get; set; }
        public int SmsPurchaseTransactionId { get; set; }
        public int StatusId { get; set; }
        public bool Active { get; set; }
    }
}