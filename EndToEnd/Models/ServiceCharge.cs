using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class ServiceCharge
    {
        public int ServiceChargeId { get; set; }
      //  public int ServiceTypeID { get; set; }
        public DropDown.Services Services { get; set; }
        public int UnitOfToken { get; set; }

    }
}