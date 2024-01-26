using Employee.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repositories.Interfaces
{
   public interface IEmployeeRepository
    {
        public Response GetEmployeeById(int id, SqlConnection connection);
        public Response GetByName(string name, SqlConnection connection);
        public Response GetAllEmployees(SqlConnection connection);
        public Response CreateEmployee(Employee1 employee, SqlConnection connection);
        public Response UpdateEmployee(Employee1 employee, int id, SqlConnection con);
        public Response DeleteEmployee(int id, SqlConnection con);
    }
}
