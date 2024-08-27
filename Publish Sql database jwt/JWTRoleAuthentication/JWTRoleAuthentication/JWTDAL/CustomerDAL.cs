using Dapper;
using JWTRoleAuthentication.CommonLayer.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace JWTRoleAuthentication.JWTDAL
{
    public class CustomerDAL
    {
        private readonly IOptions<ConnectionStrings> _options;
        private readonly SqlHelpers _sqlHelpers;

        public CustomerDAL(IOptions<ConnectionStrings> options)
        {
            _options = options;
            // _sqlHelpers = new SqlHelpers(_options.Value.AuthDBCon.ToString());
            _sqlHelpers = new SqlHelpers(_options.Value.AzureDBCon.ToString());
        }

        //public async Task<DataRow> GetCustomerDetailsById(int id)
        //{
        //    var storedProcName = "GetCustomerById";


        //    return await _sqlHelpers.GetSingleRow(storedProcName, new SqlParameter("@Id", id));
        //}

        //public async Task<DataSet> GetMultipleTablesData()
        //{

        //    string[] storedProcNames =
        //    {
        //         "GetUserDetails",
        //        "GetCustomers"
        //    };
        //    return await _sqlHelpers.GetMultipleTablesData(storedProcNames,  null);
        //}


        // create mapcustomer model for retrive the data using IDataRecord:
        private Task<CustomerModel> MapCustomer(IDataRecord record)
        {
            var model = new CustomerModel
            {
                Id = Convert.ToInt32(record["Id"]),
                UserName = record["UserName"].ToString(),
                Email = record["Email"].ToString(),
                MobileNumber = record["MobileNumber"].ToString(),
                Address = record["Address"].ToString()

            };
            Console.WriteLine(model);
           return Task.FromResult(model);
        }

        // create map customers list using IDataRecord
        private async Task<List<CustomerModel>> MapCustomerList(IDataRecord  record)
        {
            

            var customerList = new List<CustomerModel>();
            customerList.Add(new CustomerModel
            {
                Id = Convert.ToInt32(record["Id"]),
                UserName = record["UserName"].ToString(),
                Email = record["Email"].ToString(),
                MobileNumber = record["MobileNumber"].ToString(),
                Address = record["Address"].ToString()
            });
           
            return await Task.FromResult(customerList);   
        }
        
        public async Task<CustomerModel> GetCustomerDetailsById(int id)
        {
            try
            {
                var storedProcName = "GetCustomerById";
                var result = await _sqlHelpers.GetSingleRow(storedProcName, new SqlParameter("@Id", id));
                var customer = new CustomerModel
                {
                    Id = Convert.ToInt32(result["Id"]),
                    UserName = result["UserName"].ToString(),
                    Email = result["Email"].ToString(),
                    MobileNumber = result["MobileNumber"].ToString(),
                    Address = result["Address"].ToString()

                };


                // iDataReader
                //var iDataReader = await _sqlHelpers.IDataReaderAsync(storedProcName, new SqlParameter("@Id", id));

                //if(iDataReader.Read())
                //{
                //    var model = new CustomerModel
                //    {
                //       Id = Convert.ToInt32(iDataReader["Id"]),
                //       UserName = iDataReader["UserName"].ToString(),
                //       Email = iDataReader["Email"].ToString(),
                //       MobileNumber = iDataReader["MobileNumber"].ToString(),
                //       Address = iDataReader["Address"].ToString()
                //    };
                //    Console.WriteLine(model);

                //    // IDataRecord:
                //     await  MapCustomer((IDataRecord)iDataReader);

                //}


                // using dapper:

                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);

                var getCustomerDetails = await _sqlHelpers.DapperQuerySingleRow<CustomerModel>(storedProcName, parameters);

               

                // return getCustomerDetails;

                return customer;
              
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<DatasetResponse> GetMultipleTablesData()
        {
            DatasetResponse datasetResponse = null;
            datasetResponse = new DatasetResponse();
            string[] storedProcNames =
            {
                  "GetUserDetails",
                 "GetCustomers"
             };
             var dataset =  await _sqlHelpers.GetMultipleTablesData(storedProcNames,  null);
         
            try
            {
                   var userTable = dataset.Tables[0];
                  var customerTable = dataset.Tables[1];    
                  datasetResponse.users = (from DataRow r in userTable.Rows 
                                           select new Register
                                           {
                                               UserID = (Guid)r["UserID"],
                                               FirstName = r["FirstName"].ToString(),
                                               LastName = r["LastName"].ToString(),

                                               UserName = r["UserName"].ToString(),
                                               Email = r["Email"].ToString(),
                                               DateOfBirth = Convert.ToDateTime(r["DateOfBirth"]),
                                               MobileNumber = r["MobileNumber"].ToString(),
                                               ZipCode = r["ZipCode"].ToString(),
                                               StoreID = Convert.ToInt32(r["StoreID"]),
                                               Role = r["Role"].ToString()
                                           }
                                           ).ToList();
                datasetResponse.Customer = (from DataRow dt in customerTable.Rows select new CustomerModel
                {
                    Id = Convert.ToInt32(dt["Id"]),
                    UserName = dt["UserName"].ToString(),
                    Email = dt["Email"].ToString(),
                    MobileNumber = dt["MobileNumber"].ToString(),
                    Address = dt["Address"].ToString()
                }).ToList();
                datasetResponse.StatusCode = 200;
                datasetResponse.StatusMessage= "OK";
            }catch (Exception ex)
            {
                datasetResponse.StatusCode = 500;
                datasetResponse.StatusMessage = "Something went wrong.";
            }
            return datasetResponse;
        }

        public async Task<string> GetCustomerEmail(int id)
        {
            var storedProcName = "GetCustomerEmail";
            //using (var cmd = _sqlHelpers.CreateStoredProcedureCommand(storedProcName))
            //{
            //    cmd.Parameters.AddWithValue("@Id", id);  
            //    string email = await _sqlHelpers.ExecuteScalarString(cmd);
            //    return email;
            //}

            // USING DAPPER:
            var parameter = new DynamicParameters();
            parameter.Add("@Id",id,DbType.Int32);
            var getEmail = await _sqlHelpers.DapperGetSingleValue<string>(storedProcName,parameter);
            return getEmail;

        }

        public async Task<List<CustomerModel>> GetCustomers()
        {
           
            try
            {
                var customers = new List<CustomerModel>();
                var listCustomers = new List<CustomerModel>();
                var storedProcName = "GetCustomers";






                // using multiple Rows:
                //var customerTable = await _sqlHelpers.GetMultipleRows(storedProcName, null);

                var customerTable = await _sqlHelpers.GetMultipleDataRows(storedProcName, null);



                customers = (from DataRow dr in customerTable
                             select new CustomerModel
                             {
                                 Id = Convert.ToInt32(dr["Id"]),
                                 UserName = dr["UserName"].ToString(),
                                 Email = dr["Email"].ToString(),
                                 MobileNumber = dr["MobileNumber"].ToString(),
                                 Address = dr["Address"].ToString()
                             }).ToList();


                // IDataReader for multiple data rows:


                //var iDataReader = await _sqlHelpers.IDataReaderAsync(storedProcName, null);
                //while (iDataReader.Read())
                //{
                //    listCustomers.Add(new CustomerModel
                //    {
                //        Id = Convert.ToInt32(iDataReader["Id"]),
                //        UserName = iDataReader["UserName"].ToString(),
                //        Email = iDataReader["Email"].ToString(),
                //        MobileNumber = iDataReader["MobileNumber"].ToString(),
                //        Address = iDataReader["Address"].ToString()
                //    });
                //    //await MapCustomerList((IDataRecord)iDataReader);

                //}



                // var iDataReader = await _sqlHelpers.IDataReaderMultiRows(storedProcName, null);
                //listCustomers = (from DataRow dr in iDataReader
                //                 select new CustomerModel
                //                 {
                //                     Id = Convert.ToInt32(dr["Id"]),
                //                     UserName = dr["UserName"].ToString(),
                //                     Email = dr["Email"].ToString(),
                //                     MobileNumber = dr["MobileNumber"].ToString(),
                //                     Address = dr["Address"].ToString()

                //                 }
                //                 ).ToList();


                // var IDataRecordsData = await _sqlHelpers.IDataRecordsData(storedProcName, null);

                // IDataRecord for list of customer
                // var records  = IDataRecordsData.Select(async record => await MapCustomerList(record)).ToList();


                //using (var cmd = _sqlHelpers.CreateStoredProcedureCommand(storedProcName))
                //{

                //   // using adapter:
                //     var customerTable = await _sqlHelpers.ExecuteDataTableAsync(cmd);


                //   // using reader:
                //    // var customerTable = await _sqlHelpers.ReadDataTable(cmd);



                //    customers = (from DataRow dr in customerTable.Rows
                //                 select new CustomerModel
                //                 {
                //                     Id = Convert.ToInt32(dr["Id"]),
                //                     UserName = dr["UserName"].ToString(),
                //                     Email = dr["Email"].ToString(),
                //                     MobileNumber = dr["MobileNumber"].ToString(),
                //                     Address = dr["Address"].ToString()
                //                 }).ToList();

                //}



                // using dapper get customer list data:

                var customersList = await _sqlHelpers.DapperMultipleRows<CustomerModel>(storedProcName,null);
                return customersList;


                //return customers;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    
        public async Task<CustomerResponse> UpdateCustomer(int id, CustomerModel model)
        {
            CustomerResponse customerResponse = new CustomerResponse();
            try
            {
                var storedProcName = "UpdateCustomer";
                // using sqlparameter:
                //var parameters = new SqlParameter[]
                //{
                //    new SqlParameter ("@Id",id),
                //    new SqlParameter("@UserName",model.UserName),
                //    new SqlParameter("@Email",model.Email),
                //    new SqlParameter("@MobileNumber",model.MobileNumber),
                //    new SqlParameter("@Address",model.Address),
                //};

                // sql
                // int rowsAffected = await _sqlHelpers.UpdateTable(storedProcName, parameters);


                // using Dapper 
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id, DbType.Int32);
                parameters.Add("@UserName", model.UserName, DbType.String, size: 100);
                parameters.Add("@Email", model.Email, DbType.String, size: 100);
                parameters.Add("@MobileNumber", model.MobileNumber, DbType.String, size: 100);
                parameters.Add("@Address", model.Address, DbType.String, size: 100);


                //var rowsAffected = await _sqlHelpers.DapperExecuteNonQueryAsync(storedProcName, parameters);
                int rowsAffected = await _sqlHelpers.DapperExecuteNonQueryAsync(storedProcName,parameters);
                if (rowsAffected > 0)
                {
                    customerResponse.Customer = new CustomerModel();
                    customerResponse.Customer.Id = id;
                    customerResponse.Customer.UserName = model.UserName;
                    customerResponse.Customer.Email = model.Email;
                    customerResponse.Customer.MobileNumber = model.MobileNumber;
                    customerResponse.Customer.Address = model.Address;
                    customerResponse.StatusCode = 200;
                    customerResponse.StatusMessage = "Customer has been updated successfully.";
                }
            }
            catch (Exception ex)
            {
                customerResponse.StatusCode = 500;
                customerResponse.StatusMessage = "Something went wrong.";
            }
            return customerResponse;
        }


        public async Task<CustomerResponse> AddCustomer(CustomerModel model)
        {
            CustomerResponse customerResponse = new CustomerResponse();
            try
            {
                var storedProcName = "InsertCustomer";

                // USING SQL COMMANDS:

                //        var parameters = new SqlParameter[]
                //        {
                //            new SqlParameter("@UserName",model.UserName),
                //            new SqlParameter("@Email",model.Email),
                //            new SqlParameter("@MobileNumber",model.MobileNumber),
                //            new SqlParameter("@Address",model.Address),
                //        };
               
                //        int rowsAffected = await _sqlHelpers.InsertTable(storedProcName, parameters);


                // USING DAPPER:

                var parameters = new DynamicParameters();
                parameters.Add("@UserName", model.UserName, DbType.String, size:100);
                parameters.Add("@Email", model.Email, DbType.String, size: 100);
                parameters.Add("@MobileNumber", model.MobileNumber, DbType.String, size: 100);
                parameters.Add("@Address", model.Address, DbType.String, size: 100);

                var affectedRow = await _sqlHelpers.DapperExecuteNonQueryAsync(storedProcName,parameters);
                if(affectedRow > 0)
                {

                    customerResponse.Customer = model;
                    customerResponse.StatusCode = 200;
                    customerResponse.StatusMessage = "Customer details has been add successfully.";
                }
                else
                {
                   // customerResponse.Customer = null;
                    customerResponse.StatusCode = 400;
                    customerResponse.StatusMessage = "Insert of customer details has been failed.";
                }
            }catch(Exception ex)
            {
                customerResponse.StatusCode = 500;
                customerResponse.StatusMessage = "Something went wrong. Please try again later.";
            }
            return customerResponse;
        }   
        }
    
}
