using System;
using System.Collections.Generic;
using System.Text;

namespace YES.Mobile.Models
{
    internal class Vaccine
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string bodyPart { get; set; }
        public string companyName { get; set; }
    }
}