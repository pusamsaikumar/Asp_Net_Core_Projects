using BasketProject.Models;
using BasketProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasketProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        [HttpGet]
        [Route("GetAllBaskets")]
        public async Task<IActionResult> GetAllBaskets()
        {
            try
            {
                var result = await _basketRepository.GetAllBaskets();
                if(result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
         
            
        }

        [HttpGet]
        [Route("GetBasketPaginationData")]

              public IActionResult GetBasketPaginationData(string? SearchTerm, string? SortColumn, string? SortDirection, int Page = 1, int Limit = 10)
        {
            try
            {
                //var result = await _basketRepository.GetBasketRecords(Page, Limit, SearchTerm, SortColumn, SortDirection);
                var result = _basketRepository.GetBasketPaginationData(Page, Limit, SearchTerm,SortColumn, SortDirection);
               if(result != null)
                {
                    return Ok(new { data = result.Baskets, TotalRecords = result.PaginationData.TotalRecords, TotalPages = result.PaginationData.TotalPages });
                }
               return NotFound();
            }catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("updateBasketData")]
        public async Task<IActionResult> UpdateBasketData(int id , BasketData basketData)
        {
            try
            {
                var response = new ResponseModel();
                var result = await _basketRepository.UpdateBasketData(id, basketData);
                if(result != null)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "BasketData has been updated successfully .....";
                    response.Basket = result;
                    return Ok(response);
                }
                return BadRequest();


            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message); 
            }
        }

        [HttpGet]
        [Route("getbyBasketId")]
        public async Task<IActionResult> GetBasketDataById(int id)
        {
            try
            {
                var response = new ResponseModel();
                var result = await _basketRepository.GetBasketDataById(id);
                if(result != null)
                {
                    response.StatusCode = 200;
                    response.Basket = result.FirstOrDefault();
                    return Ok(result);
                }
                return BadRequest();
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        [Route("getByName")]

        // url deploy:https://hb0hemu0z5.execute-api.ap-south-1.amazonaws.com/Test/api/Basket/getByName?Name=sai
        public IActionResult GetByName(string Name)
        {
            return Ok(new {Name});    
        }
    }
}
