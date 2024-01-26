using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data
{
    public class ProductsApiDBContext : DbContext
    {
        public ProductsApiDBContext(DbContextOptions options)  : base(options)
        { 
        
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
