using DataAccessLayer.Entities;
//using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudent();
        Response AddStudent(Student student);
        Student GetStudentDetails(int id);
        Response UpdateStudent(int id, Student student);
        Response DeleteStudent(int? id);
        Response GetStudentAndEmpTableList();

        DataSet GetStudentsAndEmployeesList();



    }
}
