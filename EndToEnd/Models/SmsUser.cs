using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EndToEnd.Models
{
    public class SmsUser : Person
    {
        public string SmsUserId { get; set; }

        public string DesiredNameForSms { get; set; }

        public bool? IsBusiness { get; set; }
        public string BusinessName { get; set; }
        public bool? IsIndividual { get; set; }
        public string Slogan { get; set; }
        public bool Active { get; set; } = true;

        public bool Activated { get; set; } = false;

        // nav links

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<StaffLogin> StaffLogins { get; set; }

        public  virtual  ICollection<SmsTransaction> SmsTransactions { get; set; }

    }


}