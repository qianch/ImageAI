using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageSearch.Models
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string District { get; set; }
        public int Population { get; set; }
    }
}
