//using CommonLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result =  await _employeeRepository.AddEmployee(employee);
            return result;
        }

        //public string DeleteEmployee(int id)
        //{
        //    var result = _employeeRepository.DeleteEmployee(id);
        //    return result;
        //}

        public async Task DeleteEmployeeById(int id)
        {
          await  _employeeRepository.DeleteEmployeeById(id);
         
        }

        public async Task<List<Employee>> GetALLEmployees()
        {
          var result= await _employeeRepository.GetALLEmployees();
            return result;
        }

        public async Task<Employee> GetEmpById(int id)
        {
            var result = await _employeeRepository.GetEmpById(id);
            return result;
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
          var result = await _employeeRepository.UpdateEmployee(id, employee);
            return result;
        }
    }
}
