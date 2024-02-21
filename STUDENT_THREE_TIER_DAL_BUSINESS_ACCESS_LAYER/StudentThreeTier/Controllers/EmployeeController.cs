using Amazon.S3.Model.Internal.MarshallTransformations;
using BusinessLogicLayer;
//using CommonLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

using TestService;
using Twilio.Rest.Chat.V1.Service;



namespace StudentThreeTier.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;
        private readonly IEmployeeService _service;
        private readonly IMemoryCache _cache;

        public EmployeeController(
            IEmployeeRepository repo,
            IEmployeeService service,
            IMemoryCache cache
            ) {
           _repo = repo;
            _service = service;
            _cache = cache;
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<Employee> CreateEmployee(Employee employee)
        {
          // var result = _repo.AddEmployee(employee);
          var result = await _service.AddEmployee(employee);
       
        
            return result;
        }

        [HttpPost]
        [Route("AddWcfData")]

        public IActionResult AddWcfData([FromBody] Employee employeee)
        {



            var jsonString = JsonConvert.SerializeObject(employeee);

            ServiceClient client = new ServiceClient();

            var catchData = client.GetWCFData();
            // client.AddWCFData(jsonString);
            if (catchData == null || catchData == "No data found")
            {
                client.AddData(jsonString);
                client.AddWCFData(jsonString);
                return Ok(jsonString);
            }
            client.Close();
            return Ok(catchData);

        }

        //public IActionResult AddWcfData([FromBody] Employee employeee)
        //{

        //    //var jsonString = JsonConvert.SerializeObject(employeee);
        //    //var catchEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(2));
        //    //if(_cache.Get("MyCatchData") == null)
        //    //{
        //    //    _cache.Set("MyCatchData",jsonString,catchEntryOptions);
        //    //    return Ok(jsonString);
        //    //}


        //    //else
        //    //{
        //    //    ServiceClient client = new ServiceClient();


        //    //    client.AddData(jsonString);
        //    //    client.Close();
        //    //    return Ok(jsonString);
        //    //}




        //}


        [HttpGet]
        [Route("GeWCFData")]


        public IActionResult GetData()
        {


            ServiceClient client = new ServiceClient();
            var data = client.GetWCFData();
            if (data == null || data == "No data found")
            {
                var result = client.GetData();
                if(result == null)
                {
                    return NotFound("No data available here....");
                }
                return Ok(result);
            }
            client.Close();
            return Ok(data);

        }
        //public IActionResult GetData()
        //{
        //if(_cache.TryGetValue("MyCatchData",out  var result)) { 

        // return Ok(result); 
        //}
        //else
        //{
        //    ServiceClient client = new ServiceClient();
        //    string[] data = new string[] { "sai", "vijay", "vinay" };
        //    Console.WriteLine(data);
        //    var res = JsonConvert.SerializeObject(data);
        //    client.AddData(res);
        //   // var response = client.GetData();

        //    client.Close();
        //    return Ok(res);
        //}



        //}


        //[Authorize(Roles ="User")]
        [HttpGet]

        [Route("GetEmployeesList")]
        public async Task<List<Employee>> GetEmployeesList()
        {
           
            // var result = _repo.GetALLEmployees();
            // var result = await _service.GetALLEmployees();
            List<Employee> employees;
            if(!_cache.TryGetValue("Employee", out employees))
            {
                employees = await _service.GetALLEmployees();
                _cache.Set("Employee", JsonConvert.SerializeObject(employees), TimeSpan.FromMinutes(2));

            }

           return employees;
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Employee> GetById(int id)
        {
          //  var result = _repo.GetEmpById(id);
          var result = await _service.GetEmpById(id);
            return result;
        }
        [HttpPut]
        [Route("UpdateEmp")]
        public async Task<Employee> UpdateEmp(int id, Employee employee)
        {
           // var result = _repo.UpdateEmployee(id, employee);
           var result =  await _service.UpdateEmployee(id, employee);
            return result;
        }
       

        [HttpDelete]
        [Route("DeleteEmployeeById")]
        public async Task DeleteEmployeeById(int id)
        {
            //var result =  await _service.DeleteEmployeeById(id);
            //return result;
            await _service.DeleteEmployeeById(id);

        }
        //  public async Task<Employee> DeleteEmployeeById(int id)
        //  {
        //var result =  await _service.DeleteEmployeeById(id);
        //return result;


        //  }

    }
}
