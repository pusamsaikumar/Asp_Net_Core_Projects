using Employee.Common.Models;
using Employee.Repositories;
using Employee.Repositories.Interfaces;
using Employee.Service.Interfaces;
using System.Data.SqlClient;

namespace Employee.Service
{
    public class EmployeeService : IEmployeeService
    {

        //   private EmployeeRepository _emp = new EmployeeRepository(); 
        private IEmployeeRepository _emp;
        public EmployeeService(IEmployeeRepository emp) { 
            _emp = emp;
        }
     

        public Response GetEmployeeById(int id, SqlConnection connection)
        {
            return _emp.GetEmployeeById(id, connection);
        }

        public Response GetByName(string name, SqlConnection connection)
        {
            return _emp.GetByName(name, connection);
        }

        public Response GetAllEmployees(SqlConnection connection)
        {
            return _emp.GetAllEmployees(connection);
        }
        public Response CreateEmployee(Employee1 employee, SqlConnection connection)
        {
            return _emp.CreateEmployee(employee, connection);
        }
        public Response UpdateEmployee(Employee1 employee, int id, SqlConnection con)
        {
            return _emp.UpdateEmployee(employee, id, con);
        }

        public Response DeleteEmployee(int id, SqlConnection con)
        {
            return _emp.DeleteEmployee(id, con);
        }
    }
}