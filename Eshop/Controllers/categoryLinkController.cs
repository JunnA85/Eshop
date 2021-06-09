using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Models;
using Eshop.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
    public class categoryLinkController : Controller
    {
        categoryLinkRepository repository = new categoryLinkRepository();
        public IActionResult Index()
        {
            ViewBag.Link = this.repository.findAll();
            return View();
        }
        public IActionResult Edit(int id)
        {
            categoryLink CategoryL = this.repository.FindById(id);

            return View(CategoryL);
        }
        [HttpPost]
        public IActionResult Insert(categoryLink categoryLink)
        {
            this.repository.Insert(categoryLink);
            return RedirectToAction("ProductsAdmin", "Admin");
        }
        public IActionResult Delete(Category categoryLink)
        {
            this.repository.Delete(categoryLink);
            return RedirectToAction("ProductsAdmin", "Admin");
        }

    }
}
