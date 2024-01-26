using DataAccessLayer.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class TaskService : ITransientService, IScopedService, ISingleTonService
    {
        private readonly ITransientRepository _transientRepository;
        private readonly IScopedRepository _scopedRepository;
        private readonly ISingleTonRepository _singleTonRepository;
       

        public TaskService(
            ITransientRepository transientRepository,
            IScopedRepository scopedRepository,
            ISingleTonRepository singleTonRepository
            
            ) {
            _transientRepository = transientRepository;
            _scopedRepository = scopedRepository;
            _singleTonRepository = singleTonRepository;
            
        }

        public Guid GetScooedGuid()
        {
            var result = _scopedRepository.GetTaskID();
            return result;
        }

        public Guid GetSingleTonGuid()
        {
            var result = _singleTonRepository.GetTaskID();
            return result;
        }

        public Guid GetTaskID()
        {
            throw new NotImplementedException();
        }

        public Guid GetTransientGuid()
        {
          var result = _transientRepository.GetTaskID();
            
          
          return result;
        }

        //Guid id;
        //public TaskService()
        //{
        //    id = Guid.NewGuid();
        //}




        //public Guid GetTaskID()
        //{
        //    return id;
        //}
    }
}
