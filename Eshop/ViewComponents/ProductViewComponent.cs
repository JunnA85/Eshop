using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
        
    }
}
