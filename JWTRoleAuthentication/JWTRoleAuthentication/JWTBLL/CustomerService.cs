using JWTRoleAuthentication.CommonLayer.Models;
using JWTRoleAuthentication.JWTDAL;
using System.Data;

namespace JWTRoleAuthentication.JWTBLL
{
    public class CustomerService
    {
        private readonly CustomerDAL _customerDAL;

        public CustomerService(CustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }
        public async Task<CustomerModel> GetCustomerDetailsById(int id)
        {
            var result = await _customerDAL.GetCustomerDetailsById(id);
            return result;  
        }
        //public async Task<DataSet> GetMultipleTableData()
        //{
        //    var result = await _customerDAL.GetMultipleTablesData();
        //    return result;
        //}
        public async Task<DatasetResponse> GetMultipleTablesData()
        {
               var result = await _customerDAL.GetMultipleTablesData();
               return result;
        }
        public async Task<string> GetCustomerEmail(int id)
        {
            var result = await _customerDAL.GetCustomerEmail(id);
            return result;
        }
        public async Task<List<CustomerModel>> GetCustomers()
        {
            var result = await _customerDAL.GetCustomers();
            return result;

        }
        public async Task<CustomerResponse> AddCustomer(CustomerModel model)
        {
            var result = await _customerDAL.AddCustomer(model);
            return result;
        }
        public async Task<CustomerResponse> UpdateCustomer(int id,CustomerModel model)
        {
            var result = await _customerDAL.UpdateCustomer(id,model);
            return result;
        }
    }
}
