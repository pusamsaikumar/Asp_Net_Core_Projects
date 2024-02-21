using BasketProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketProject.Data
{
    public class BasketDBContext : DbContext
    {
        public BasketDBContext(DbContextOptions<BasketDBContext> options) : base(options) 
        {
            
        }
        public DbSet<BasketData> BasketData { get; set; }   
    }
}
