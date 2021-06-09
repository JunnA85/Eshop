using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models.Repositories
{
    public class CategoryRepository
    {
        private MyContext context = new MyContext();

        public List<Category> findAll()
        {
            return this.context.Category.ToList();
        }
        public Category FindById(int id)
        {
            return this.context.Category.Find(id);
        }
        public void Insert(Category Category)
        {
            this.context.Add(Category);
            this.context.SaveChanges();
        }
        public void Update(Category Category)
        {
            this.context.Entry(Category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.context.SaveChanges();
        }
        public void Delete(Category Category)
        {
            this.context.Remove(Category);
            this.context.SaveChanges();
        }
        public List<SelectListItem> GetAllCats()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<Category> Categories = new List<Category>();

            Categories = findAll();

            foreach (Category item in Categories)
            {
                items.Add( new SelectListItem { Text = item.name, Value = item.name });
            }

            return items;
        }
    }
}
