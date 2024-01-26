using EmployeeStorePROC.Models;

namespace EmployeeStorePROC.Repositories
{
    public interface IEmployeeRepository
    {
      public   Task<List<Employee>> GetEmployees();
        public Task <List<Employee>> GetEmployeeById(int id);
        public Task<int> AddEmployee(Employee employee);
        public Task<int> UpdatEmployee(Employee employee,int id);
        public Task<int> DeleteEmployee(int id);
        
    }
}


