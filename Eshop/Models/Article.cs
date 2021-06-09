using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models
{
    public class Article
    {
        public int id { get; set; }
        public string title { get; set; }
        public string blog { get; set; }
        public string author { get; set; }
        public DateTime sentTime { get; set; }
        public string img { get; set; }

    }
}
