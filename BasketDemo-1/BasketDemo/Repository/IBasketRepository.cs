using BasketDemo.Models;

namespace BasketDemo.Repository
{
    public interface IBasketRepository
    {
         Task<List<BasketDatum>> GetAllBaskets();
} }
