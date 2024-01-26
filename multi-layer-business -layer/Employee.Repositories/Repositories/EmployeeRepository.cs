using Employee.Common.Models;
using Employee.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Employee.Repositories
{
    public class EmployeeRepository  : IEmployeeRepository
    {
        public Response GetEmployeeById(int id,SqlConnection connection)
        {

            Response response = new Response();
            string query = "select * from Employee where Id = '" + id + "' ";
           // SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Employee1> employees = new List<Employee1>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee1 employee = new Employee1();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    employee.DateofBirth = Convert.ToDateTime(dt.Rows[i]["DateofBirth"]);
                    employee.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    employees.Add(employee);

                }
                if (employees.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "fond employees data";
                    response.Employeeslist = employees;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No data found";
                    response.Employeeslist = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.Employeeslist = null;
            }



            return response;


        }
        public Response GetByName(string name, SqlConnection connection)
        {
            Response response = new Response();
            string query = "select * from Employee where Name = '" + name + "' ";
            //SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //  List<Employee> employees = new List<Employee>();
                List<Employee1> employees = new List<Employee1>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee1 employee = new Employee1();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    employee.DateofBirth = Convert.ToDateTime(dt.Rows[i]["DateofBirth"]);
                    employee.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    employees.Add(employee);

                }
                if (employees.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "fond employees data";
                    response.Employeeslist = employees;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No data found";
                    response.Employeeslist = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.Employeeslist = null;
            }



            return response;
        }

        public Response GetAllEmployees(SqlConnection connection)
        {
            Response response = new Response();
            string query = "select * from Employee";
           // SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Employee1> employees = new List<Employee1>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee1 employee = new Employee1();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    employee.DateofBirth = Convert.ToDateTime(dt.Rows[i]["DateofBirth"]);
                    employee.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    employees.Add(employee);

                }
                if (employees.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "fond employees data";
                    response.Employeeslist = employees;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No data found";
                    response.Employeeslist = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.Employeeslist = null;
            }



            return response;
        }


        public Response CreateEmployee(Employee1 employee,SqlConnection connection)
        {
            Response response = new Response();
            string query = "insert into Employee values('" + employee.Name + "',GetDate(),'" + employee.Email + "')";
            //SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("SNCon"));
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Created Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Creation Failed";
            }
            return response;
        }


        public Response UpdateEmployee(Employee1 employee, int id,SqlConnection con)
        {
            Response response = new Response();
           // SqlConnection con = new SqlConnection(_configuration.GetConnectionString("SNCon"));
            string query = "update Employee set Name='" + employee.Name + "',DateofBirth='" + employee.DateofBirth + "',Email='" + employee.Email + "' where Id = '" + id + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Updated successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Not updated";
            }

            return response;
        }

        public Response DeleteEmployee(int id ,SqlConnection con)
        {
            Response response = new Response();
            string query = "delete from Employee where Id='" + id + "'";
            //SqlConnection con = new SqlConnection(_configuration.GetConnectionString("SNCon"));
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (id < 0)
            {
                throw new Exception("Employee id does not less than 0");
            }

            if (i > 0)
            {

                response.StatusCode = 200;
                response.StatusMessage = "deleted successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = $"Employee details are not deleted or {id} does not exist";
            }
            return response;
        }

    }
}