using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models.Repositories
{
    public class ArticleRepository
    {
        private MyContext context = new MyContext();

        public List<Article> findAll()
        {
            return this.context.Article.ToList();
        }
        public Article FindById(int id)
        {
            return this.context.Article.Find(id);
        }
        public void Insert(Article article)
        {
            this.context.Add(article);
            this.context.SaveChanges();
        }
        public void Update(Article article)
        {
            this.context.Entry(article).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.context.SaveChanges();
        }
        public void Delete(Article article)
        {
            this.context.Remove(article);
            this.context.SaveChanges();
        }
    }
}
