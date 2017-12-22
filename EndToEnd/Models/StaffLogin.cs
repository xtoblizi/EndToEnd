using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class StaffLogin
    {
        public int StaffLoginId { get; set; }
        public string StaffName
        {
            get; set;
        }
        public string Description { get; set; }
        public DateTime DateOfLogin
        {
            get { return DateTime.Now; }
            set { }
        }
        public bool Active
        {
            get { return Active; }

            set { Active = true; }
        }

       public string StaffId { get; set; }

        public virtual Staff Staff { get; set; }
    }
}