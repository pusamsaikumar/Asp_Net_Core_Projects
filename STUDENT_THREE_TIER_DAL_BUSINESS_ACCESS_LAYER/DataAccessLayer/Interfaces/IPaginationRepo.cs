using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IPaginationRepo
    {
        Task<StudentResults> GetStudentsRecords(int Page, int Limit,string? SearchTerm,string? SortColumn,string? SortDirection,string? MultiNames);
    }
}
