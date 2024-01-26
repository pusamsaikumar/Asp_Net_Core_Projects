using IgenericReposADO.IService;
using IgenericReposADO.Models;

namespace IgenericReposADO.Service
{
    public class TeacherService : IGenericService<Teacher>
    {
            List<Teacher> teachers = new List<Teacher>();
        public TeacherService() { 
         for(int i=1; i <=9; i++)
            {
                teachers.Add(new Teacher() { 
                    TeacherId = i,
                    TeacherName="teach"+i,
                    Subject="sub"+i
                
                });
                    
            }
        }

        public List<Teacher> Delete(int id)
        {
            teachers.RemoveAll(x=>x.TeacherId == id);   
            return teachers;
        }

        public List<Teacher> Edit(Teacher item)
        {
            throw new NotImplementedException();
        }

        public List<Teacher> GetAll()
        {
            return teachers;
        }

        public Teacher GetById(int id)
        {
            return teachers.Where(x=>x.TeacherId == id).SingleOrDefault();
        }

        public List<Teacher> Insert(Teacher item)
        {
           teachers.Add(item); 
            return teachers;
        }
    }
}
