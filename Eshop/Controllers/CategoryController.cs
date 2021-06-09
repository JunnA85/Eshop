using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Models.Repositories;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryRepository repository = new CategoryRepository();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category Category = this.repository.FindById(id);

            return View(Category);
        }

        [HttpPost]
        public IActionResult Edit(Category Category)
        {
            this.repository.Update(Category);
            return RedirectToAction("CategoriesAdmin", "Admin");
        }
        [HttpPost]
        public IActionResult Insert(Category Category)
        {
            this.repository.Insert(Category);
            return RedirectToAction("CategoriesAdmin", "Admin");
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult Delete(Category Category)
        {
            this.repository.Delete(Category);
            return RedirectToAction("CategoriesAdmin", "Admin");
        }
    }
}
