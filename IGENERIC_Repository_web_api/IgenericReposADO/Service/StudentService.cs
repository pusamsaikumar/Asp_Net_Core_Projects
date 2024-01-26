using IgenericReposADO.IService;
using IgenericReposADO.Models;

namespace IgenericReposADO.Service
{
    public class StudentService : IGenericService<Student>
    {
        List<Student> students = new List<Student>();
        public StudentService() { 
        
         for(int i=1; i<=9; i++)
            {
                students.Add(new Student()
                {
                    StudentId = i,
                    StudentName = "Student "+i,
                    Roll="100"+i
                });
            }
        }

        public List<Student> Delete(int id)
        {
            students.RemoveAll(x => x.StudentId == id);
            return students;
        }

        public List<Student> Edit(Student item)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetAll()
        {
           return students;
        }

        public Student GetById(int id)
        {
            
            return students.Where(x => x.StudentId == id).SingleOrDefault();
        }

        public List<Student> Insert(Student item)
        {
           students.Add(item);
            return students;
        }

      

       

       
    }
}
