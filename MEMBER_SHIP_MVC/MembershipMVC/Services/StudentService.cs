using EFCore.BulkExtensions;
using MembershipMVC.Data;
using MembershipMVC.Models.ExcelFileModels;

namespace MembershipMVC.Services
{
    public class StudentService : IStudentService

    {
        private readonly ApplicationDBContext _context;

        public StudentService(ApplicationDBContext context)
        {
            _context = context;
        }

       public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

      public  List<Student> SaveStudents(List<Student> students)
        {
            _context.BulkInsert(students);
            return students;
        }
    }
}
