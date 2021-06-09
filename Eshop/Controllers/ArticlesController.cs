using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Models;
using Eshop.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
    public class ArticlesController : Controller
    {
        private ArticleRepository repository = new ArticleRepository();
        public IActionResult Index()
        {
            this.ViewBag.Articles = this.repository.findAll();

            return View();
        }
        public IActionResult Detail(int id)
        {
            Article article = this.repository.FindById(id);

            return View(article);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Article article = this.repository.FindById(id);

            return View(article);
        }

        [HttpPost]
        public IActionResult Edit(Article article)
        {
            this.repository.Update(article);
            return RedirectToAction("ArticlesAdmin", "Admin");
        }
        [HttpPost]
        public IActionResult Insert(Article article)
        {
            this.repository.Insert(article);
            return RedirectToAction("ArticlesAdmin","Admin");
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult Delete(Article article)
        {
            this.repository.Delete(article);
            return RedirectToAction("ArticlesAdmin", "Admin");
        }


    }
}
