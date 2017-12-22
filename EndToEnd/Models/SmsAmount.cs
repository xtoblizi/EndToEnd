﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class SmsAmount
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal SmsUnit { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

    }
}