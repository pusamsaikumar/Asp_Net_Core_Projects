using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Models;

namespace ProductWebAPI.Data
{
    public class ProductDBContext : DbContext
    {
       public ProductDBContext(DbContextOptions options) : base(options) 
        { 
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
