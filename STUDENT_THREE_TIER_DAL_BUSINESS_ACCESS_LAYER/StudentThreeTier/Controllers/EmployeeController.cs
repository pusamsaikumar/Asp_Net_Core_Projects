using BusinessLogicLayer;
//using CommonLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

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
      ////  public async Task<Employee> DeleteEmployeeById(int id)
      //  {
      //      //var result =  await _service.DeleteEmployeeById(id);
      //      //return result;
             
            
      //  }
       public async Task DeleteEmployeeById(int id)
        {
            //var result =  await _service.DeleteEmployeeById(id);
            //return result;
            await _service.DeleteEmployeeById(id);

        }
}
}
