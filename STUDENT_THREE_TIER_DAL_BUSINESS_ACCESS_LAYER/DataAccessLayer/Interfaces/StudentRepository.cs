using DataAccessLayer.Entities;
//using CommonLayer.Models;
using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
//using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace DataAccessLayer.Interfaces
{
    public class StudentRepository : IStudentRepository
    {
      
        private readonly IConfiguration _configuration;


        private readonly IOptions<ConnectionStrings> _config;
      

        public StudentRepository(
            IConfiguration configuration, 
           
            IOptions<ConnectionStrings> config
            
            )
        {
          
            _configuration = configuration;

            _config = config;
            
         }

        public List<Student> GetAllStudent()
        {
            string connection = _config.Value.SNCon.ToString();
            //SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("SNCon"));
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_Get_StudentList", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                   conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Student> students = new List<Student>();
                    while ( reader.Read())
                    {
                       var student = new Student();
                        student.Id = Convert.ToInt32(reader["Id"]);
                        student.FirstName = reader["FirstName"].ToString();
                        student.LastName = reader["LastName"].ToString();
                        student.DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                        student.RollNumber = reader["RollNumber"].ToString();
                        student.Address = reader["Address"].ToString();
                        student.Marks = reader["Marks"].ToString();
                        student.Grades = reader["Grades"].ToString();
                        students.Add(student);

                    }
                    reader.Close();
                    conn.Close();
                    return students;
                }
                catch (Exception ex)
                {
                    throw;
                }


            }


        }


        //public List<Student> GetAllStudent()
        //  {
        //      string connection = _config.Value.SNCon.ToString();
        //      //SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("SNCon"));
        //      using (SqlConnection conn = new SqlConnection(connection))
        //      {
        //          try
        //          {
        //              SqlDataAdapter da = new SqlDataAdapter("usp_Get_StudentList", conn);
        //              da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //              DataTable dt = new DataTable();
        //              //  DataSet ds = new DataSet();
        //              // da.Fill(ds);
        //              da.Fill(dt);
        //              List<Student> students = new List<Student>();
        //              if (dt.Rows.Count > 0)
        //              {
        //                  for (int i = 0; i < dt.Rows.Count; i++)
        //                  {
        //                      Student student = new Student();
        //                      student.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
        //                      student.FirstName = dt.Rows[i]["FirstName"].ToString();
        //                      student.LastName = dt.Rows[i]["LastName"].ToString();
        //                      student.DateofBirth = Convert.ToDateTime(dt.Rows[i]["DateOfBirth"]);
        //                      student.RollNumber = Convert.ToString(dt.Rows[i]["RollNumber"]);
        //                      student.Address = dt.Rows[i]["Address"].ToString();
        //                      student.Marks = dt.Rows[i]["Marks"].ToString();
        //                      student.Grades = dt.Rows[i]["Grades"].ToString();
        //                      students.Add(student);
        //                  }

        //              }

        //              if (students.Count > 0)
        //              {
        //                  return students;
        //              }
        //              else
        //              {
        //                  return null;
        //              }
        //          }
        //          catch (Exception ex)
        //          {
        //              throw;
        //          }


        //      }


        //  }

        //public Student GetStudentDetails(int id)
        //{
         
        //        var connection = _config.Value.SNCon.ToString();
        //        //SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("SNCon"));
        //        using (SqlConnection conn= new SqlConnection(connection))
        //        {
        //            try
        //            {
        //                SqlDataAdapter da = new SqlDataAdapter("usp_GetById_Student", conn);
        //                da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //                da.SelectCommand.Parameters.AddWithValue("@Id", id);
        //                DataTable dt = new DataTable();
        //                da.Fill(dt);
        //                Student student = new Student();
        //                if (dt.Rows.Count > 0)
        //                {
        //                    student.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
        //                    student.FirstName = dt.Rows[0]["FirstName"].ToString();
        //                    student.LastName = dt.Rows[0]["LastName"].ToString();
        //                    student.DateofBirth = Convert.ToDateTime(dt.Rows[0]["DateOfBirth"]);
        //                    student.RollNumber = dt.Rows[0]["RollNumber"].ToString();
        //                    student.Address = dt.Rows[0]["Address"].ToString();
        //                    student.Marks = dt.Rows[0]["Marks"].ToString();
        //                    student.Grades = dt.Rows[0]["Grades"].ToString();
        //                }
        //                if (student != null)
        //                {
        //                    return student;
        //                }
        //                else
        //                {
        //                    return null;
        //                }

        //            }
        //            catch ( Exception ex )
        //            {
        //                throw;
        //            }
                   
        //        }
              
                
         



        //}
        public Student GetStudentDetails(int id)
        {

            var connection = _config.Value.SNCon.ToString();
            //SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("SNCon"));
            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("usp_GetById_Student", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Student student = new Student();
                while (reader.Read())
                {

                    student.Id = Convert.ToInt32(reader["Id"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.DateofBirth = Convert.ToDateTime(reader["DateofBirth"]);
                    student.RollNumber = reader["RollNumber"].ToString();
                    student.Address = reader["Address"].ToString();
                    student.Marks = reader["Marks"].ToString();
                    student.Grades = reader["Grades"].ToString();

                    // ReadSingleRow((IDataRecord)reader);


                }



                reader.Close();
                conn.Close();
               
                return student;

            }

         }

 
        // reading singleRow data
        private void  ReadSingleRow(IDataRecord dataRecord)
        {
            Student student = new Student();
            student.Id = Convert.ToInt32(dataRecord["Id"]);
            student.FirstName = dataRecord["FirstName"].ToString();
            student.LastName = dataRecord["LastName"].ToString();
            student.DateofBirth = Convert.ToDateTime(dataRecord["DateofBirth"]);
            student.RollNumber = dataRecord["RollNumber"].ToString();
            student.Address = dataRecord["Address"].ToString();
            student.Marks = dataRecord["Marks"].ToString();
            student.Grades = dataRecord["Grades"].ToString();
            Console.WriteLine(student);
          
          
        }

        public Response AddStudent(Student student)
        {
            Response response = new Response();


            //if (student != null)
            //{



            //}
            //else
            //{
            //    response.StatusCode=400;
            //    response.StatusMessage = "BadRequest";
            //}

            // Console.WriteLine(conn);
            //SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("SNCon"));



            string connection = _config.Value.SNCon.ToString();
            //  SqlConnection conn = new SqlConnection(connection);
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    SqlCommand checkRollNumber = new SqlCommand("check_RollNumber_Student", conn);

                    checkRollNumber.CommandType = System.Data.CommandType.StoredProcedure;
                    checkRollNumber.Parameters.AddWithValue("@RollNumber", student.RollNumber);
                    string rollnumber = (string)checkRollNumber.ExecuteScalar();
                    if (rollnumber == student.RollNumber)
                    {
                        response.StatusCode = 200;
                        response.StatusMessage = "Student RollNumber  is already Existed!";
                    }
                    else
                    {

                        SqlCommand cmd = new SqlCommand("usp_Insert_Students", conn);

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", student.LastName);
                        cmd.Parameters.AddWithValue("@DateOfBirth", student.DateofBirth);
                        cmd.Parameters.AddWithValue("@RollNumber", student.RollNumber);
                        cmd.Parameters.AddWithValue("@Address", student.Address);
                        cmd.Parameters.AddWithValue("@Marks", student.Marks);
                        cmd.Parameters.AddWithValue("@Grades", student.Grades);

                        int i = cmd.ExecuteNonQuery();
                        conn.Close();
                        if (i > 0)
                        {
                            Student student1 = new Student();
                          
                            student1.FirstName = student.FirstName;
                            student1.LastName = student.LastName;
                            student1.DateofBirth = student.DateofBirth;
                            student1.RollNumber = student.RollNumber;
                            student1.Address = student.Address;
                            student1.Marks = student.Marks;

                            student1.Grades = student.Grades;
                            response.StatusCode = 200;
                            response.StatusMessage = "Record has been inserted successfully.";
                            response.Student = student1;
                        }
                        else
                        {
                            response.StatusCode = 400;
                            response.StatusMessage = "Record insertion has failed.";
                        }
                    }

                }
                catch (Exception ex)
                {
                    response.StatusCode = 500;
                     response.StatusMessage = ex.Message;
                     throw new Exception(ex.Message);
                }





            }


            return response;
        }
     

       

        public Response UpdateStudent(int id, Student student)
        {
           Response response = new Response();
            string connection = _config.Value.SNCon.ToString();
            //  SqlConnection conn = new SqlConnection(connection);
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_check_rollId", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@Id", id);
                   // cmd.Parameters.AddWithValue ("@Id", student.Id);
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@DateofBirth", student.DateofBirth);
                    cmd.Parameters.AddWithValue("@RollNumber", student.RollNumber);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@Marks", student.Marks);
                    cmd.Parameters.AddWithValue("@Grades", student.Grades);

                   conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (i > 0)
                    {
                       Student student1 = new Student();
                        student1.Id = id;
                        student1.FirstName = student.FirstName;
                        student1.LastName = student.LastName;
                        student1.DateofBirth = student.DateofBirth;
                        student1.RollNumber = student.RollNumber;
                        student1.Address = student.Address;
                        student1.Marks = student.Marks;
                            
                        student1.Grades = student.Grades;

                       

                        response.StatusCode = 200;
                        response.StatusMessage = "Record has been Updated successfully";
                        response.Student = student1;
                    }
                    else
                    {
                        response.StatusCode = 400;
                        response.StatusMessage = "Student already available with this rollnumber  or  enable to update student details";
                    }


                }
                catch (Exception ex)
                {
                   // response.StatusCode = 500;
                    response.StatusMessage = ex.Message;
                    //throw;
                }

            }

            return response;
        }

        public Response DeleteStudent(int? id)
        {
            Response response = new Response();
            string connection = _config.Value.SNCon.ToString();
            // SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("SNCon"));

            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    // SqlConnection conn = new SqlConnection(connection);
                    SqlCommand cmd = new SqlCommand("usp_Delete_Student", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (i > 0)
                    {
                        response.StatusCode = 200;
                        response.StatusMessage = "Record has been deleted successfully";


                    }
                    else
                    {
                        response.StatusCode = 400;
                        response.StatusMessage = "Record deletion has been failed?";
                    }
                }
                catch(Exception ex)

                {
                    response.StatusCode = 500;
                    response.StatusMessage = ex.Message;
                  //  throw;
                }

            }
               return response;
        }

        // To Read Multiple Tables using Dataset: Students and Employees
        public Response GetStudentAndEmpTableList()
        {
            Response response = new Response();

            var connection = _config.Value.SNCon.ToString();
            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("usp_Dataset_Tables", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Open();
                List<Student> studentslist = new List<Student>();
                List<Employee> employees = new List<Employee>();



                //using  Linq

                var studentList = ds.Tables[0].Rows.Cast<DataRow>().Select(r => new Student
                {
                    //Column1 = r["Column1"].ToString(),
                    Id = Convert.ToInt32(r["Id"]),
                    FirstName = r["FirstName"].ToString(),
                    LastName = r["LastName"].ToString(),
                    //  Column4 = r["Column4"].ToString(),
                    DateofBirth = Convert.ToDateTime(r["DateOfBirth"]),
                    RollNumber = r["RollNumber"].ToString(),
                    Address = r["Address"].ToString(),
                    Marks = r["Marks"].ToString(),
                    Grades= r["Grades"].ToString(),
                   
                }).ToList();

                if(studentList.Count > 0 )
                {
                    response.StatusCode = 200;
                                 response.ListStudent = studentList;
                                response.StatusMessage = "Ok";
                }









                // using AsEnumerable
                //        var studentList = ds.Tables[0].AsEnumerable()
                //     .Select(dataRow => new Student
                //     {
                //Id = Convert.ToInt32(dataRow["id"]),
                //FirstName = dataRow["FirstName"].ToString(),
                //LastName = dataRow["LastName"].ToString(),
                //DateofBirth = Convert.ToDateTime(dataRow["DateOfBirth"]),
                //RollNumber = dataRow["RollNumber"].ToString(),
                //Address = dataRow["Address"].ToString(),
                //Marks = dataRow["Marks"].ToString(),
                //Grades = dataRow["Grades"].ToString()
                //     }).ToList();
                //   if(studentList.Count > 0)
                //        {
                //            response.StatusCode = 200;
                //             response.ListStudent = studentList;
                //            response.StatusMessage = "Ok";
                //        }

                // using foreach

                //foreach (DataRow row in ds.Tables[0].Rows)
                //{
                //    var student = new Student();
                //    student.Id = Convert.ToInt32(row["Id"]);
                //    student.FirstName = row["FirstName"].ToString();
                //    student.LastName = row["LastName"].ToString();
                //    student.DateofBirth = Convert.ToDateTime(row["DateofBirth"]);
                //    student.RollNumber = row["RollNumber"].ToString();
                //    student.Address = row["Address"].ToString();
                //    student.Marks = row["Marks"].ToString();
                //    student.Grades = row["Grades"].ToString();
                //    studentslist.Add(student);

                //}
                //foreach (DataRow row in ds.Tables[1].Rows)
                //{
                //    var employee = new Employee();
                //    employee.Id = Convert.ToInt32(row["Id"]);
                //    employee.FirstName = row["FirstName"].ToString();
                //    employee.LastName = row["LastName"].ToString();
                //    employee.Email = row["Email"].ToString();
                //    employee.DOB = Convert.ToDateTime(row["DOB"]);
                //    employee.Salary = Convert.ToDecimal(row["Salary"]);
                //    employees.Add(employee);

                //}
                //if (employees.Count > 0)
                //{
                //    response.StatusCode = 200;
                //    response.StatusMessage = "OK";
                //    response.Employeeslist = employees;
                //}
                //if (studentslist.Count > 0)
                //{
                //    response.StatusCode = 200;
                //    response.StatusMessage = "OK";
                //    response.ListStudent = studentslist;
                //}

            }
            return response;
        }
        public  DataSet GetStudentsAndEmployeesList()
        {
            
            DataSet ds = new DataSet();
         //  ds.Clear();

            var connection = _config.Value.SNCon.ToString();
            using (SqlConnection conn = new SqlConnection(connection))
            {
               using(SqlCommand cmd = new SqlCommand("usp_Dataset_Tables", conn))
                {
                   // SqlCommand cmd = new SqlCommand();

                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                   // DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();

                }
            }
            return ds;
        }
       
    }
}
