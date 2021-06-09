using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Models;
using Eshop.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
    public class MessageController : Controller
    {
        MessageRepository repository = new MessageRepository();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Message message)
        {
            this.repository.Insert(message);
            return RedirectToAction("Index","Home");
        }
    }
}
