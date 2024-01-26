using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IPaginationService
    {
        Task<StudentResults> GetStudentsRecords(int Page, int Limit, string? SearchTerm, string? SortColumn, string? SortDirection, string? MultiNames);
    }
}
