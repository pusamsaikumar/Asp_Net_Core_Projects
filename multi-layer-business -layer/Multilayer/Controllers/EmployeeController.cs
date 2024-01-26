


using Employee.Common.Models;
using Employee.Repositories;
using Employee.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;


namespace Multilayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private  IEmployeeService _EmployeeService;

        public EmployeeController(IConfiguration configuration ,IEmployeeService employeeService) {
            _configuration = configuration;
            _EmployeeService = employeeService;
        }

        // get employee list by id
        // URL https://localhost:7030/api/Employee/10
        [HttpGet]
        [Route("{id:int}")]

        public Response GetEmployeeById(int id)
        {

            Response response = new Response();
           
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            
            EmployeeRepository reppo = new EmployeeRepository();
            response = reppo.GetEmployeeById(id,connection);



            return response;


        }

        // get by Name
        // URL : https://localhost:7030/api/Employee/name?name=VIJAY
        [HttpGet]
        [Route("Name")]
        public Response GetByName(string name)
        {
            Response response = new Response();

            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());

            EmployeeRepository reppo = new EmployeeRepository();
            response = reppo.GetByName(name, connection);




          


            return response;
        }


        // get all employees
        // URL https://localhost:7030/api/Employee/getAllEmployees
        [HttpGet]
        [Route("getAllEmployees")]
        public Response GetAllEmployees()
        {
            Response response = new Response();
           
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            var result = _EmployeeService.GetAllEmployees(connection);
            response = result;
           // EmployeeRepository reppo = new EmployeeRepository();
           // response = reppo.GetAllEmployees( connection);



            return response;
        }


        // create employee record
        [HttpPost]
        [Route("CreateEmployee")]
        public Response CreateEmployee(Employee1 employee)
        {
            Response response = new Response();

            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());

            EmployeeRepository reppo = new EmployeeRepository();
            response = reppo.CreateEmployee( employee,connection);



            return response;
        }

        // Edit employees
        [HttpPut]
        [Route("update/{id}")]
        public Response UpdateEmployee(Employee1 employee, int id)
        {
            Response response = new Response();

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());

            EmployeeRepository reppo = new EmployeeRepository();
            response = reppo.UpdateEmployee(employee,id, con);



            return response;
        }

        // Delete employee based id
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public Response DeleteEmployee(int id)
        {
            Response response = new Response();
          
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("SNCon"));
            EmployeeRepository reppo = new EmployeeRepository();
            response = reppo.DeleteEmployee(id, con);

            return response;
        }


    }
}
