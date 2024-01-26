
//using CommonLayer.Models;
using DataAccessLayer.Entities;
using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//using Xceed.Wpf.Toolkit;

namespace DataAccessLayer.Interfaces
{
    public class EmployeeRepository : IEmployeeRepository
    {
        
        private readonly IOptions<ConnectionStrings> _config;

        public EmployeeRepository(
           
             IOptions<ConnectionStrings> config
            )
        {
           
            _config = config;
        }
        public async Task<Employee> AddEmployee(Employee employee)

        {
            string connection = _config.Value.SNCon.ToString();

            if (employee != null)
            {

               // SqlConnection conn = new SqlConnection(connection);
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    try
                    {
                        // check emaill exist or not before post 
                        conn.Open();
                        SqlCommand checkEmail = new SqlCommand("usp_checkEmail_Employee", conn);
                        checkEmail.CommandType = CommandType.StoredProcedure;
                        checkEmail.Parameters.AddWithValue("@Email", employee.Email);
                        string email = (string)checkEmail.ExecuteScalar();

                        if (email == employee.Email)
                        {
                            string message = "Alread existed username";
                            //  Console.WriteLine(message);
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("usp_Insert_Employee", conn);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                            cmd.Parameters.AddWithValue("@Email", employee.Email);
                            cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                            cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                            cmd.Parameters.AddWithValue("@Salary", employee.Salary);

                            int i = cmd.ExecuteNonQuery();
                            conn.Close();
                            if (i > 0)
                            {

                                return await Task.FromResult(employee);
                            }
                            else
                            {
                                return null;

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                
            }
            return await Task.FromResult(employee);
        }

        //public string DeleteEmployee(int id)
        //{
        //    var res = GetEmpById(id);
        //    Console.WriteLine(res.Result.FirstName);

        //    Employee emp = new Employee();
        //    emp.FirstName = res.Result.FirstName;
        //    emp.LastName = res.Result.LastName;
        //    emp.Email = res.Result.Email;
        //    emp.PhoneNumber = res.Result.PhoneNumber;
        //    emp.DOB = res.Result.DOB;
        //    emp.Salary = res.Result.Salary;

        //    string message = "";
        //    SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("SNCon"));
        //    SqlCommand cmd = new SqlCommand("usp_Delete_Employee", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Id", id);
        //    conn.Open();
        //    int i = cmd.ExecuteNonQuery();
        //    conn.Close();
        //    if (i > 0)
        //    {
        //        message = "Record has been deleted successfully";

        //    }
        //    else
        //    {
        //        message = "Record deletion has failed";

        //    }

        //   return message;
        //}

        // public async Task<Employee> DeleteEmployeeById(int id)
        public async Task DeleteEmployeeById(int id)
        {

            //  var res = GetEmpById(id);
            //  Employee emp = new Employee();
            string connection = _config.Value.SNCon.ToString();

           
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_Delete_Employee", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    //if (i > 0)
                    //{

                    //    emp.FirstName = res.Result.FirstName;
                    //    emp.LastName = res.Result.LastName;
                    //    emp.Email = res.Result.Email;
                    //    emp.PhoneNumber = res.Result.PhoneNumber;
                    //    emp.DOB = res.Result.DOB;
                    //    emp.Salary = res.Result.Salary;
                    //    return await Task.FromResult(emp);


                    //}
                    //else
                    //{
                    //   throw new ArgumentNullException(nameof(i));

                    //}

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            


              await Task.CompletedTask;


        }

        public async Task<List<Employee>> GetALLEmployees()
        {
           List<Employee> employees = new List<Employee>();
            string connection = _config.Value.SNCon.ToString();


            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_Get_EmployeeList", conn);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            Employee employee = new Employee();
                            employee.Id = Convert.ToInt32(dataTable.Rows[i]["Id"]);
                            employee.FirstName = dataTable.Rows[i]["FirstName"].ToString();
                            employee.LastName = dataTable.Rows[i]["LastName"].ToString();
                            employee.Email = dataTable.Rows[i]["Email"].ToString();
                            employee.PhoneNumber = dataTable.Rows[i]["PhoneNumber"].ToString();
                            employee.DOB = Convert.ToDateTime(dataTable.Rows[i]["DOB"]);
                            employee.Salary = Convert.ToDecimal(dataTable.Rows[i]["Salary"]);
                            employees.Add(employee);
                        }
                    }
                    else
                    {
                        return null;
                    }
                    //if(employees.Count > 0)
                    //{
                    //    return Task.FromResult(employees);
                    //}
                    //else
                    //{
                    //    return null;
                    //}
                }
                catch (Exception ex) {
                    throw;
                }
            }
                
           return await Task.FromResult(employees);
        }

        public async Task<Employee> GetEmpById(int id)
        {
            string connection = _config.Value.SNCon.ToString();

            Employee employee = new Employee();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_GetById_Employee", conn);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Id", id);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    
                    if (dataTable.Rows.Count > 0)
                    {
                        employee.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
                        employee.FirstName = Convert.ToString(dataTable.Rows[0]["FirstName"]);
                        employee.LastName = Convert.ToString(dataTable.Rows[0]["LastName"]);
                        employee.Email = Convert.ToString(dataTable.Rows[0]["Email"]);
                        employee.PhoneNumber = Convert.ToString(dataTable.Rows[0]["PhoneNumber"]);
                        employee.DOB = Convert.ToDateTime(dataTable.Rows[0]["DOB"]);
                        employee.Salary = Convert.ToDecimal(dataTable.Rows[0]["Salary"]);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
               
           return  await Task.FromResult(employee);
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            if (employee != null)
            {

                string connection = _config.Value.SNCon.ToString();

                
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("usp_Update_Employee", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                        cmd.Parameters.AddWithValue("@Email", employee.Email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                        cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                        cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                        conn.Open();
                        int i = cmd.ExecuteNonQuery();
                        conn.Close();
                        //if (i > 0)
                        //{

                        //    return Task.FromResult(employee);
                        //}
                        //else
                        //{
                        //    return null;

                        //}

                        // return Task.FromResult(employee);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                   }
                

            }
            return  await Task.FromResult(employee);
        }

       
    }
}
