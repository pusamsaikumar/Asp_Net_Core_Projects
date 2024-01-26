using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using StudentEntityFirstApproach.Models;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudentEntityFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailsController : ControllerBase
    {
        private readonly StudentContext _studentContext;

        public StudentDetailsController(StudentContext studentContext) 
        {
            _studentContext = studentContext;
        }
        // Get studentDetails  /api/StudentDetails

        [HttpGet]   
        
        //public async Task<ActionResult<IEnumerable<StudentDetail>>> GetStudentDetails()

        //{
        //    return await _studentContext.StudentDetails.ToListAsync();
        //}


      public async Task<ActionResult<IEnumerable<EmployeeDetail>>> GetEmployeeDetails()
        {
            var data = await _studentContext.EmployeeDetails.ToListAsync();

            if(data == null)
            {
                return NotFound();
            }
            else
            {
                var model = new List<EmployeeDetail>();
                foreach (var employee in  data)
                {
                    model.Add(new EmployeeDetail() {
                    
                        Id = employee.Id,                       
                        Name = employee.Name,
                        RollNumber = employee.RollNumber,
                        Country = employee.Country,
                    });
                }


              //  return Ok(data);
              return Ok(model);
                
            }



            // return await _studentContext.EmployeeDetails.ToListAsync();
        }

       
        // get details by id :

        [HttpGet("{id}")]
        public async  Task<ActionResult<EmployeeDetail>> GetEmpDetailsById(int id)
        {
            var data = await _studentContext.EmployeeDetails.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }
            else
            {
               var model = new EmployeeDetail();
                model.Id = data.Id ;
                model.Name = data.Name;
                model.RollNumber = data.RollNumber;
                model.Country = data.Country;

                return Ok(model);
            }

        }

        // create post employeedetail

        [HttpPost]
        public async Task<ActionResult<EmployeeDetail>> AddEmployeeDetail(EmployeeDetail employeeDetail)
        {
            var model = new EmployeeDetail()
            {
                Id = employeeDetail.Id,
                Name = employeeDetail.Name,
                RollNumber = employeeDetail.RollNumber,
                Country = employeeDetail.Country,
            };

            _studentContext.EmployeeDetails.Add(model);
            await _studentContext.SaveChangesAsync();
            return CreatedAtAction("GetEmployeeDetails", new { id = model.Id }, model);
        } 

        // create already existed employeedetails
              private bool  EmployeesDetailsExists(int id) { 
                
                    return _studentContext.EmployeeDetails.Any(x => x.Id == id);
        
                }

        // update put 
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployeeDetails( int id, EmployeeDetail employeeDetail)
        {
            if(id != employeeDetail.Id)
            {
                return NotFound();
            }
            _studentContext.Entry(employeeDetail).State = EntityState.Modified;
            try
            {
                await _studentContext.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException)
            {
                if(!EmployeesDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
              
            }
            // return NoContent();
            return  Ok(employeeDetail);
            
        }

        // Delete employee details by id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeeDetails(int id)
        {
            var EmpDetails = await _studentContext.EmployeeDetails.FindAsync(id);
            if(EmpDetails == null)
            {
                return NotFound();
            }
            _studentContext.EmployeeDetails.Remove(EmpDetails);
            await _studentContext.SaveChangesAsync();
            return Ok("Empployee Details has been deletee successfully...");
        }

        // search by name
        [HttpGet("search")]
        public async Task<ActionResult<EmployeeDetail>> Search(string? name)

        { 
            IQueryable<EmployeeDetail> query = _studentContext.EmployeeDetails;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where((x) => x.Name.Contains(name) || x.Name == null);
               
            }
           
           var result = await query.ToListAsync();
            return Ok(result);
            

        }
    }
}
