using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: db tabloları ile proje claslarını bağlamak.
    //Böylece sınıfımıza sen bir db contexin demiş olduk.
    public class NorthwindContext : DbContext //EntityFrameworkden gelen bir class.
    {
        //Projemiz hangi veritabanı ile ilişkili olduğunu belirttiğimiz yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; } //Veritabanında hangi tablo hangi nesneye denk geliyo böyle belirliyoruz.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
