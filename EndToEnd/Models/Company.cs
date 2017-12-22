using System;

namespace EndToEnd.Models
{
    public class Company
    {
        public int CompanyId { get; set; }


        public string Name { get; set; }

        public string Slogan { get; set; }

        public DateTime DateCreated { get; set; }
    }
}