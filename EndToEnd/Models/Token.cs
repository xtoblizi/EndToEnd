using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class Token
    {
        public int TokenId { get; set; }

        public decimal TokenBalance { get; set; }

        public string SmsUserId { get; set; }

        public virtual SmsUser SmsUser { get; set; }

        public DateTime DateCreated { get; set; }

    }
} 