
//using CommonLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IEmployeeRepository
    {

        Task<List<Employee>> GetALLEmployees();
        Task<Employee> GetEmpById(int  id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(int id,Employee employee);
        // string DeleteEmployee(int id);

        //  Task<Employee> DeleteEmployeeById(int id);
        Task DeleteEmployeeById(int id);
    }


}
