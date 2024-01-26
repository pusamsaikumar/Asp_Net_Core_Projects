
//using CommonLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
//using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
//using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class StudentService : IStudentyService
    {
        private readonly IConfiguration _configuration;
        private readonly IStudentRepository _studentRepository;
        private readonly IOptions<AppSettings> _options;

        public StudentService(IConfiguration configuration,IStudentRepository studentRepository,IOptions<AppSettings> options)
        {
            _configuration = configuration;
            _studentRepository = studentRepository;
           _options = options;
        }




        public Response AddStudent(Student student)
        {
            Response response = new Response();
            try
            {
               // var result = _studentRepository.AddStudent(student);
                var result = _studentRepository.AddStudent(student);
                if (result != null)
                {
                    response.StatusCode = result.StatusCode;
                    response.StatusMessage = result.StatusMessage;
                    response.Student = result.Student;
                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusMessage = "An error occurred! please try again";
                }

            // return response;
            }catch (Exception ex)
            {
                  response.StatusCode =500;
                  response.StatusMessage = ex.Message;
                //throw new Exception(ex.Message);
            }

            return response;
        }



        public Response DeleteStudent(int? id)
        {
            Response response = new Response();
            try
            {
                if (id != 0)
                {
                    var result = _studentRepository.DeleteStudent(id);
                    response.StatusCode = result.StatusCode;
                    response.StatusMessage = result.StatusMessage;
                    response.ListStudent = result.ListStudent;

                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusMessage = "Invalid Student Id!";
                }

              
            }
            catch (Exception ex)

            {
                response.StatusCode = 500;
                response.StatusMessage = ex.Message;
                //  throw;
            }

            return response;

        }

        public List<Student> GetAllStudent()
        {
            try
            {
                var result =_studentRepository.GetAllStudent();
             
               
                return result;
            }
            catch (Exception ex)
            {
             throw new Exception(ex.Message); 
               // throw new Exception("Something went wrong...");
            }
           
        }

        public Response GetStudentAndEmpTableList()
        {
            
            try
            {
                 var result = _studentRepository.GetStudentAndEmpTableList();
               
               
                return result;
             

            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
              // throw new Exception("Something went wrong...");
            }
        }

        //public Response GetEmployeeAndStudentDetails()
        //{
        //    try
        //    {
        //         var resutl = _studentRepository.GetStudentsAndEmployeesList();
        //        return resutl;

        //    }catch(Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public Student GetStudentDetails(int id)
        {
            try
            {
              
                var result = _studentRepository.GetStudentDetails(id);
              
                return result;
            }
            catch (Exception ex)
            {
              
               // throw new Exception("Internal server error.... Please try again!");

               throw new Exception(ex.Message);
            }
              
          
                    
                    
              
           
            
        }

        public  DataSet GetStudentsAndEmployeesList()
        {
            try

            {
                var result = _studentRepository.GetStudentsAndEmployeesList();
                
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
               
           
        }

        public Response UpdateStudent(int id, Student student)
        { 
            Response response = new Response();
            try
            {
                if (id != 0)
                {
                    var result = _studentRepository.UpdateStudent(id, student);
                    if(result != null )
                    {
                        response.StatusCode = result.StatusCode;
                        response.StatusMessage = result.StatusMessage;
                        response.Student = result.Student;
                    }
                    else
                    {
                        response.StatusCode=400;
                        response.StatusMessage = "Something went wrong";
                    }
                   
                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusMessage = "Invalid student id or BadRequest ";
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
       
    }
}
