
//using BasketDemo.Data;
using BasketDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketDemo.Repository
{
    public class BasketRepository : IBasketRepository
    {
        
        private readonly RSA_GroceryDEVContext _context;

        public BasketRepository(RSA_GroceryDEVContext context)
        {
           _context = context;
        }
        public async Task<List<BasketDatum>> GetAllBaskets()
        { 
        
           return  await _context.BasketData.FromSqlRaw<BasketDatum>("usp_get_basketData").ToListAsync();

        }
    }
}
