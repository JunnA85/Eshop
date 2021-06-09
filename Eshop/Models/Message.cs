using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models
{
    public class Message
    {
        public int id { get; set; }
        public string sender { get; set; }
        public string name { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
        public DateTime sentTime { get; set; }
    }
}
