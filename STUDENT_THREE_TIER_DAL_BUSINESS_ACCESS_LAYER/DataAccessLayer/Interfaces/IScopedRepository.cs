﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IScopedRepository
    {
         Guid GetTaskID();
      //  Guid GetScooedGuid();
    }
}
