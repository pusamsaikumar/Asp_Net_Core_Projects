using BasketDemo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketDemo.Controllers
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
            var result = await _basketRepository.GetAllBaskets();
            return Ok(result);  
        }
    }
}
