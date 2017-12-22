using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class CreateChargeRate
    {
        public int CreateChargeRateId { get; set; }

        public decimal Amount { get; set; }

        public DateTime? DateCreated { get; set; } = DateTime.Now;

        [StringLength(50,ErrorMessage ="Characters should not be beyond 50")]
        public string EffectedBy { get; set; }

        public bool Active { get; set; }

        // nav
        public int SmsUnitId { get; set; }

        public virtual SmsUnit SmsUnit { get; set; }
    }
}