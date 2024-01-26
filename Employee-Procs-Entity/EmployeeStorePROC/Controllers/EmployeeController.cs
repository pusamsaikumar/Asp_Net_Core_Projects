using EmployeeStorePROC.Models;
using EmployeeStorePROC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeStorePROC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // get all employees list
        [HttpGet("getallemployeelist")]
        public async Task<List<Employee>> GetEmployees()
        {
            try
            { 
            
                return await _employeeRepository.GetEmployees();
            } 
            catch(Exception e)
            {
                throw;
            }
          
        }

        // GET Employee by id 
        [HttpGet("{id}")]
        public async Task<List<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var result = await _employeeRepository.GetEmployeeById(id);
                if(result == null)
                {
                    return null;
                }
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost("addemployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _employeeRepository.AddEmployee(employee);
                return Ok(result);
            }catch(Exception e)
            {
                throw;
            }
        }

        // update employee
        [HttpPut("updateEmployee")]
        public async Task<IActionResult> UpdateEmployee(int id,Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await _employeeRepository.UpdatEmployee(employee,id);
                return Ok(result);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        [HttpDelete("deleteemployee")]
        public async Task<int> DeleteEmployee(int id)
        {
            try
            {
                var response = await _employeeRepository.DeleteEmployee(id);
                return response;
            }
            catch
            {
                throw;
            }
        }

    }
}
