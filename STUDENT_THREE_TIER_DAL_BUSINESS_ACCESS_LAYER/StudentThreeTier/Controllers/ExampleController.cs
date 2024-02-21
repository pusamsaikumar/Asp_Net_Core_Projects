using CommonLayer.Models;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace StudentThreeTier.Controllers
{
    // [Authorize]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
     
        private readonly IOptions<Database> _options;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;

        public ExampleController(
            IOptions<Database> options,
            IMemoryCache memoryCache,
            IDistributedCache distributedCache
            
            )
        {
            _options = options;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        [Route("settings")]
        public IActionResult Settings()
        {
            string conn = _options.Value.ConnectionStrings.ToString();
            Console.Write(conn);
            return Ok(ModelState);
        }
        [HttpGet]
        [Route("GetSession")]
        public IActionResult GetSession()
        {



            var data = _memoryCache.Get("Student");
            if(data == null )
            {
                return NotFound("No data found.");
            }
           return Ok(data); 
            
            
        }
        [HttpGet]
        [Route("GetSessionEmployees")]
        public IActionResult GetSessionEmployees()
        {



            var data = _memoryCache.Get("Employee");
            if (data == null)
            {
                return NotFound("No data found.");
            }
            return Ok(data);


        }
        [HttpGet]
        [Route("GetSessionJsonFile")]
        public IActionResult GetSessionJsonFile()
        {



            var data = _memoryCache.Get("JsonFile");
            if (data == null || data == "No data found")
            {
                return NotFound("No data found.");
            }
            return Ok(data);


        }

        [HttpGet]
        [Route("GetJsonFileData")]
        public IActionResult GetJsonFileData()
        {



            var data = _distributedCache.GetString("JsonFile");
            if (data == null)
            {
                return NotFound("No data found.");
            }
            return Ok(data);


        }
    }
}
