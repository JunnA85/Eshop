using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Article> Article { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<categoryLink> categoryLink { get; set; }
        public DbSet<Message> Message { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=mysqlstudenti.litv.sssvt.cz;database=4b1_junamatej_db2;user=junamatej;pwd=123456;");
        }
    }
}
