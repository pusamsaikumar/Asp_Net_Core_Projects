using JWTRoleAuthentication.CommonLayer.Models;
using JWTRoleAuthentication.JWTBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JWTRoleAuthentication.Controllers
{

    // publish url:  https://rsaecrsapi02-atgdf2a5huedapb5.eastus-01.azurewebsites.net/api/Customer
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        [Route("GetCustomerById")]
        public async Task<IActionResult> GetCustomerDetails(int id)
        {
            var result = await _customerService.GetCustomerDetailsById(id);
             if(result  == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetMultiTablesData")]
       
         
        public async Task<IActionResult> GetMultipleTableData()
        {
            var result = await _customerService.GetMultipleTablesData();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetCustomerEmail")]
        public async Task<IActionResult> GetCustomerEmail(int id)
        {
            var result = await _customerService.GetCustomerEmail(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result); 
        }
        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IActionResult> Getcustomers()
        {
            var result = await _customerService.GetCustomers();
            return Ok(result);
        }
        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerModel model)
        {
             var result = await _customerService.AddCustomer(model);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(int id,CustomerModel model)
        {
            var result = await _customerService.UpdateCustomer( id, model);
            if (result == null)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
