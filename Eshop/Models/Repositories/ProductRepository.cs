using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models.Repositories
{
    public class ProductRepository
    {
        private MyContext context = new MyContext();

        public List<Product> findAll()
        {
            return this.context.Product.ToList();
        }
        public Product FindById(int id)
        {
            return this.context.Product.Find(id);
        }
        public List<categoryLink> GetCategoryNames(int id)
        {
            List<categoryLink> catLinks = new List<categoryLink>();
            catLinks = this.context.categoryLink.Where(x => x.ProductID == id).ToList();

            return catLinks;

        }
        public List<string> getImages(int id)
        {
            List<string> Paths = new List<string>();
            List<Image> Images = new List<Image>();
            Images = this.context.Image.Where(x => x.ProductID == id).ToList();

            for (int i = 0; i < Images.Count; i++)
            {
                if(Images.Count > 0)
                    Paths.Add(Images[i].image);
  
            }
            return Paths;
        }
        public void Insert(Product Product)
        {
            this.context.Add(Product);
            this.context.SaveChanges();
        }
        public void Update(Product Product)
        {
            this.context.Entry(Product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.context.SaveChanges();
        }
        public void Delete(Product Product)
        {
            this.context.Remove(Product);
            this.context.SaveChanges();
        }
    }
}
