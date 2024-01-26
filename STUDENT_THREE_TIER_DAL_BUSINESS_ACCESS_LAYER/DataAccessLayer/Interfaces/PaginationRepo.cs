using Dapper;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public class PaginationRepo : IPaginationRepo
    {
        private readonly IOptions<ConnectionStrings> _config;

        public PaginationRepo(
            IOptions<ConnectionStrings> config
            )
        {
            _config = config;
        }
        public async Task<StudentResults> GetStudentsRecords(int Page, int Limit, string? SearchTerm, string? SortColumn, string? SortDirection, string? MultiNames)
        {

            var conn = _config.Value.SNCon.ToString();
            using IDbConnection connection = new SqlConnection( conn );
            using var multi = await connection.QueryMultipleAsync("pagination_data", new
            {
                Page, Limit, SearchTerm, SortColumn, SortDirection, MultiNames

            }, commandType: CommandType.StoredProcedure);

             var student = await multi.ReadAsync<Student>();
            var paginationData = await multi.ReadFirstAsync<PaginationData>();
            return new StudentResults{ Students = student, PaginationData = paginationData }; 

            
        }
    }
}
