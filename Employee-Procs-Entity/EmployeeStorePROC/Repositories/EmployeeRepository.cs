using EmployeeStorePROC.Data;
using EmployeeStorePROC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EmployeeStorePROC.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeStoreProcDbContext _employeeStoreProcDbContext;

        public EmployeeRepository(EmployeeStoreProcDbContext employeeStoreProcDbContext) 
        {
            _employeeStoreProcDbContext = employeeStoreProcDbContext;
        }

       

       public async Task<int> AddEmployee(Employee employee)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@FirstName", employee.FirstName));
            parameter.Add(new SqlParameter("@LastName", employee.LastName));
            parameter.Add(new SqlParameter("@DateofBirth", employee.DateofBirth));
            parameter.Add(new SqlParameter("@Email", employee.Email));
            parameter.Add(new SqlParameter("@Salary", employee.Salary));
            var result = await Task.Run(()=>  _employeeStoreProcDbContext.Database
                .ExecuteSqlRawAsync("exec usp_insert_Employee @FirstName,@LastName,@DateofBirth, @Email,  @Salary",parameter.ToArray())
                );


             return result;
            
        }

        //var result = await Task.Run(() => _dbContext.Database
        //  .ExecuteSqlRawAsync(@"exec UpdateProduct @ProductId, @ProductName, @ProductDescription, @ProductPrice, @ProductStock", parameter.ToArray()));
        //    return result;
        

      
       
       public async  Task<List<Employee>> GetEmployees()
        {
            return await _employeeStoreProcDbContext.Employees.FromSqlRaw<Employee>("usp_Get_EmployeesList").ToListAsync();
        }

        


       public async Task<List<Employee>> GetEmployeeById(int id)
        {
            var param = new SqlParameter("@Id", id);
            var EmployeeDetails = await Task.Run(() => _employeeStoreProcDbContext.Employees
            .FromSqlRaw("exec GetEmployeeById @Id", param).ToListAsync()
            );
            return EmployeeDetails;
        }

       

        public async Task<int> DeleteEmployee(int id)
        {
            return await Task.Run(() => _employeeStoreProcDbContext.Database.ExecuteSqlInterpolatedAsync($"usp_Delete_Employees {id}"));
        }
        
        public async Task<int> UpdatEmployee(Employee employee,int id)
        {
            var param = new SqlParameter("@Id" ,id);
            var parameter = new List<SqlParameter>();
           
          // parameter.Add(new SqlParameter("@Id", employee.Id));
            parameter.Add(new SqlParameter("@FirstName", employee.FirstName));
            parameter.Add(new SqlParameter("@LastName", employee.LastName));
            parameter.Add(new SqlParameter("@DateofBirth", employee.DateofBirth));
            parameter.Add(new SqlParameter("@Email", employee.Email));
            parameter.Add(new SqlParameter("@Salary", employee.Salary));
            var result = await Task.Run(() => _employeeStoreProcDbContext.Database
             .ExecuteSqlRawAsync($"exec UpdateEmployee {id},@FirstName,@LastName,@DateofBirth, @Email, @Salary", parameter.ToArray())

               );
            Console.WriteLine($" parameter:{parameter} ");
            Console.ReadLine();
          //  var result = await _employeeStoreProcDbContext.Database.ExecuteSqlRawAsync($"exec UpdateEmployee {employee.FirstName},{employee.LastName},{employee.DateofBirth},{employee.Email},{employee.Salary}",param);
            return result;
        }
    }
}
