using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models.Repositories
{
    public class categoryLinkRepository
    {
        private MyContext context = new MyContext();

        public List<categoryLink> findAll()
        {
            return this.context.categoryLink.ToList();
        }
        public List<Category> getCategoryNames(List<categoryLink> l)
        {
 
            List<Category> Cat = new List<Category>();
            foreach (categoryLink item in l)
            {
                var tmp = this.context.Category.Where(x => x.id == item.CatID).ToList();
                Cat.Add(tmp[0]);
            }
            return Cat;
        }
        public categoryLink FindById(int id)
        {
            return this.context.categoryLink.Find(id);
        }
        public void Insert(categoryLink categoryLink)
        {
           
            var l = this.context.categoryLink.Where(x => x.CatID == categoryLink.CatID && x.ProductID == categoryLink.ProductID).ToList();
            if (l.Count() == 0)
            {
                this.context.Add(categoryLink);
                this.context.SaveChanges();               
            }

        }
        public void Delete(Category cat)
        {
            List<categoryLink> catID = this.context.categoryLink.Where(x => x.CatID == cat.id).ToList();
            categoryLink cl = FindById(catID[0].id);

            this.context.Remove(cl);
            this.context.SaveChanges();
        }
    }
}
