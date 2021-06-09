using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Eshop.Models;
using Eshop.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace Eshop.Controllers
{
    public class AdminController : Controller
    {
        AdminRepository repository = new AdminRepository();
        ArticleRepository aRepository = new ArticleRepository();
        ProductRepository pRepository = new ProductRepository();
        CategoryRepository cRepository = new CategoryRepository();
        categoryLinkRepository clRepository = new categoryLinkRepository();

        public IActionResult Index()
        {
            if (this.HttpContext.Session.GetInt32("id") != null)
            {
                Admin admin = this.repository.getAdmin((int)this.HttpContext.Session.GetInt32("id"));
                ViewBag.Admin = admin;

                return View(admin);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new Admin());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Admin m)
        {
            if (ModelState.IsValid)
            {
                var HashPassword = GetMD5(m.password);
                var data = repository.getCredentials(m.username, HashPassword);
                if (data.Count() > 0)
                {
                    this.HttpContext.Session.SetInt32("id", data.FirstOrDefault().id);
                    this.HttpContext.Session.SetString("login", data.FirstOrDefault().username);

                    return RedirectToAction("Index","Admin");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }

            }
            return View();
        }
        public IActionResult Logout()
        {
            this.HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        [HttpGet]
        public IActionResult ArticlesAdmin()
        {
            ViewBag.Articles = this.aRepository.findAll();
            return View();
        }
        public IActionResult ProductsAdmin()
        {
            ViewBag.Products = this.pRepository.findAll();
            return View();
        }
        public IActionResult CategoriesAdmin()
        {
            ViewBag.Categories = this.cRepository.findAll();
            return View();
        }
        public IActionResult CategoriesDetail(int id)
        {
            var AllCategories = this.cRepository.findAll();

            this.ViewBag.ProductID = id;
            this.ViewBag.Categories = this.clRepository.getCategoryNames(this.pRepository.GetCategoryNames(id));
            this.ViewBag.Category = AllCategories;

            return View();
        }
    }
}
