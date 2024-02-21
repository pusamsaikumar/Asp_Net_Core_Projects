using BasketProject.Models;

namespace BasketProject.Repository
{
    public interface IBasketRepository
    {
        Task<List<BasketData>> GetAllBaskets();
      
       Task<List<BasketData>> GetBasketRecords(int Page, int Limit, string? SearchTerm, string? SortColumn, string? SortDirection);

         ResponseModel GetBasketPaginationData(int Page, int Limit, string? SearchTerm, string? SortColumn, string? SortDirection);
        Task<BasketData> UpdateBasketData(int id,BasketData basketData);
        Task<List<BasketData>> GetBasketDataById(int id);



    }
}
