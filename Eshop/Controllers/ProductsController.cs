using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eshop.Models;
using Eshop.Models.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Eshop.Controllers
{
    public class ProductsController : Controller
    {
        private ProductRepository repository = new ProductRepository();
        private categoryLinkRepository clRepository = new categoryLinkRepository();

        public IActionResult Index()
        {
            this.ViewBag.Products = this.repository.findAll();

            foreach (Product item in ViewBag.Products)
            {
                if (this.repository.getImages(item.id).Count > 0 && item.firstImage != null)
                {
                    item.firstImage = this.repository.getImages(item.id)[0];
                    this.repository.Update(item);
                }                  
                else
                    item.firstImage = null;
            }

            return View();
        }

        public IActionResult Detail(int id)
        {
            Product product = this.repository.FindById(id);

            this.ViewBag.Pictures = this.repository.getImages(id);
            this.ViewBag.Categories = this.clRepository.getCategoryNames(this.repository.GetCategoryNames(id));

            return View(product);
        }
        public IActionResult Edit(int id)
        {
            Product Product = this.repository.FindById(id);

            return View(Product);
        }
        [HttpPost]
        public IActionResult Edit(Product Product)
        {
            this.repository.Update(Product);
            return RedirectToAction("ArticlesAdmin", new { id = Product.id });
        }
        [HttpPost]
        public IActionResult Insert(Product Product)
        {
            this.repository.Insert(Product);
            return RedirectToAction("ArticlesAdmin", new { id = Product.id });
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult Delete(Product Product)
        {
            this.repository.Delete(Product);
            return RedirectToAction("", new { id = Product.id });
        }


    }
}
