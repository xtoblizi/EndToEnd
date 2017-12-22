using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class UserTokenBalance
    {
        public int UserTokenBalanceId { get; set; }

        public decimal AmountBalance { get; set; } = 0.0m;

        public decimal? TokenBalance { get; set; }

        public DateTime Datecreated { get; set; } = DateTime.Now;

        // navs
            public string SmsUserId { get; set; }
            public virtual SmsUser SmsUser { get; set; }


    }
}