using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PaginationService : IPaginationService
    {
        private readonly IPaginationRepo _paginationRepo;

        public PaginationService(IPaginationRepo paginationRepo) {
           _paginationRepo = paginationRepo;
        }
        public Task<StudentResults> GetStudentsRecords(int Page, int Limit, string? SearchTerm, string? SortColumn, string? SortDirection, string? MultiNames)
        {
           var result = _paginationRepo.GetStudentsRecords(Page, Limit, SearchTerm, SortColumn, SortDirection, MultiNames);
            return result;
        }
    }
}
