using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
