using Microsoft.EntityFrameworkCore;
using SearchProduct.Models;

namespace SearchProduct.Data
{
    public class ProductDBContext:DbContext
    {
        public ProductDBContext(DbContextOptions options):base(options) 
        {
            
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    ProductName= "Product1",
                    Size="L",
                    Price=100,
                    MfgDate=DateTime.Parse("2023-11-20").Date,
                    Category="Economy"
                },
                 new Product()
                 {
                     ProductId = 2,
                     ProductName = "Product2",
                     Size = "L",
                     Price = 112,
                     MfgDate = DateTime.Parse("2023-11-20").Date,
                     Category = "Premium"
                 },
                  new Product()
                  {
                      ProductId = 3,
                      ProductName = "Product3",
                      Size = "M",
                      Price = 120,
                      MfgDate = DateTime.Parse("2023-11-20").Date,
                      Category = "Standard"
                  },
                   new Product()
                   {
                       ProductId = 4,
                       ProductName = "Product4",
                       Size = "S",
                       Price = 90,
                       MfgDate = DateTime.Parse("2023-11-20").Date,
                       Category = "Economy"
                   }
                );
        }
    }
}
