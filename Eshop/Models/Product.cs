using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int sale { get; set; }
        public float dph { get; set; }
        public int number { get; set; }
        public string firstImage { get; set; }
        public string vendor { get; set; }
    }
}
