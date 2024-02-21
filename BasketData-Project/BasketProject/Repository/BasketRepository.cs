
using BasketProject.Data;
using BasketProject.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static System.TimeZoneInfo;

namespace BasketProject.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketDBContext _context;

        public BasketRepository
            (
                BasketDBContext context
            )
        {
           _context = context;
        }
        public async Task<List<BasketData>> GetAllBaskets()
        {
            try
            {
                return await _context.BasketData.FromSqlRaw<BasketData>("usp_get_basketData").ToListAsync();
            }
            catch(Exception ex)
            {
               throw new Exception(ex.Message);
            }
          
        }

        public async Task<List<BasketData>> GetBasketDataById(int id)
        {
            try
            {
                var param = new SqlParameter("@BasketDataId", id);
                //var basketDetails = await Task.Run(() => _context.BasketData
                //.FromSqlRaw("exec usp_getBasketDataById @BasketDataId", param).ToListAsync()
                //);

                var basketDetails = await _context.BasketData.FromSqlRaw<BasketData>("exec usp_getBasketDataById @BasketDataId", param).ToListAsync();

                if ( basketDetails != null )
                {
                    return basketDetails;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);    
            }
            
        }

        public ResponseModel GetBasketPaginationData(int Page, int Limit, string? SearchTerm, string? SortColumn, string? SortDirection)
        {
         ResponseModel response = new ResponseModel();
            try
            {
                var parameters = new[]
                {
            new SqlParameter("@Page", SqlDbType.Int) { Value = Page },
            new SqlParameter("@Limit", SqlDbType.Int) { Value = Limit },
            new SqlParameter("@SearchTerm", SqlDbType.VarChar, 100) { Value = SearchTerm ?? (object)DBNull.Value },
            new SqlParameter("@SortColumn", SqlDbType.VarChar, 100) { Value = SortColumn ?? (object)DBNull.Value },
            new SqlParameter("@SortDirection", SqlDbType.VarChar, 100) { Value = SortDirection ?? (object)DBNull.Value }
             };


                // 10 records per page
                 var result =  _context.BasketData.FromSqlRaw("EXEC usp_basket_pagination @Page, @Limit, @SearchTerm, @SortColumn, @SortDirection", parameters).ToList();

                // totalrecords
                int totalRecords = _context.BasketData.Count();

                // Calculate total pages
                int totalPages = (int)Math.Ceiling((double)totalRecords / Limit);
              
                List<BasketData> basketResuts = new List<BasketData>();
                if (result != null)
                {
                   foreach(var item in result)
                    {

                        basketResuts.Add(item);  
                    }

                    
                    response.PaginationData = new PaginationData
                    {
                        TotalPages = totalPages,
                        TotalRecords = totalRecords
                    };
                   response.Baskets = basketResuts;
                    response.StatusMessage = "BasketData has been found";
                    response.StatusCode = 200;

                }
                else
                {
                    response.PaginationData = null;
                    response.StatusMessage = "No BasketData found.";
                    response.StatusCode = 100;
                    response.Baskets = null;
                }


                return response;

            }catch ( Exception ex )
            {
                response.StatusCode = 500; 
               response.StatusMessage = ex.Message;
                throw new Exception(response.StatusMessage);
            }
        }

        public async Task<List<BasketData>> GetBasketRecords(int Page, int Limit, string? SearchTerm, string? SortColumn, string? SortDirection)
        {
            try
            {

                var parameters = new[]
                {
            new SqlParameter("@Page", SqlDbType.Int) { Value = Page },
            new SqlParameter("@Limit", SqlDbType.Int) { Value = Limit },
            new SqlParameter("@SearchTerm", SqlDbType.VarChar, 100) { Value = SearchTerm ?? (object)DBNull.Value },
            new SqlParameter("@SortColumn", SqlDbType.VarChar, 100) { Value = SortColumn ?? (object)DBNull.Value },
            new SqlParameter("@SortDirection", SqlDbType.VarChar, 100) { Value = SortDirection ?? (object)DBNull.Value }
             };

             var result =   await _context.BasketData.FromSqlRaw("EXEC usp_basket_pagination @Page, @Limit, @SearchTerm, @SortColumn, @SortDirection", parameters).ToListAsync();
               
           
               
                // totalrecords
                int totalRecords = _context.BasketData.Count();

                // Calculate total pages
                int totalPages = (int)Math.Ceiling((double)totalRecords / Limit);

                // Calculate total pages
               
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            }

        public async Task<BasketData> UpdateBasketData(int id,BasketData basketData)
        {
            try
            {
                var param = new SqlParameter("@BasketDataId", id);
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Retailer", basketData.Retailer));
                parameters.Add(new SqlParameter("@POSId", basketData.POSId));
                parameters.Add(new SqlParameter("@StoreId", basketData.StoreId));
                parameters.Add(new SqlParameter("@OperatorId", basketData.OperatorId));
                parameters.Add(new SqlParameter("@TransactionId", basketData.TransactionId));
                parameters.Add(new SqlParameter("@TransactionDate", basketData.TransactionDate));
                parameters.Add(new SqlParameter("@TransactionTime", basketData.TransactionTime));
                parameters.Add(new SqlParameter("@TransactionTotalAmount", basketData.TransactionTotalAmount));
                parameters.Add(new SqlParameter("@TransactionTaxAmount", basketData.TransactionTaxAmount));
                parameters.Add(new SqlParameter("@TransactionTenderType", basketData.TransactionTenderType));
                parameters.Add(new SqlParameter("@CreatedDate", basketData.CreatedDate));


                // var result = await Task.Run(() => _context.Database
                //.ExecuteSqlRawAsync($"EXEC usp_update_basketData {id},@Retailer,@POSId,@StoreId,@OperatorId,@TransactionId,@TransactionDate,@TransactionTime,@TransactionTotalAmount,@TransactionTaxAmount,@TransactionTenderType,@CreatedDate", parameters.ToArray()));

                // var result = await _context.Database
                // .ExecuteSqlRawAsync($"EXEC usp_update_basketData {id},@Retailer,@POSId,@StoreId,@OperatorId,@TransactionId,@TransactionDate,@TransactionTime,@TransactionTotalAmount,@TransactionTaxAmount,@TransactionTenderType,@CreatedDate", parameters.ToArray());

                var result = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC usp_update_basketData {id},{basketData.Retailer},{basketData.POSId},{basketData.StoreId},{basketData.OperatorId},{basketData.TransactionId},{basketData.TransactionDate},{basketData.TransactionTime},{basketData.TransactionTotalAmount},{basketData.TransactionTaxAmount},{basketData.TransactionTenderType},{basketData.CreatedDate}");
               if (result == 1)
                {
                    return Task.FromResult(basketData).Result;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
