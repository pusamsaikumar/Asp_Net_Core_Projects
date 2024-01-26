using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public class TaskRepository : ITransientRepository, IScopedRepository, ISingleTonRepository
    
    {
        Guid id;
        public TaskRepository() { 
             id = Guid.NewGuid();
        }


        public Guid GetTaskID()
        {
           

            return id;
        }
    }
}
