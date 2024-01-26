using MembershipMVC.Models.ExcelFileModels;

namespace MembershipMVC.Services
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        List<Student> SaveStudents(List<Student> students);
    }
}
