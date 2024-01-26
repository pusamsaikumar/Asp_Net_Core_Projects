
//using CommonLayer.Models;
using DataAccessLayer.Entities;
using System.Data;

namespace BusinessLogicLayer
{
    public interface IStudentyService
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
