
//using CommonLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetALLEmployees();
        Task<Employee> GetEmpById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(int id, Employee employee);
        //string DeleteEmployee(int id);
        //   Task<Employee> DeleteEmployeeById(int id);
        Task DeleteEmployeeById(int id);
    }
}
