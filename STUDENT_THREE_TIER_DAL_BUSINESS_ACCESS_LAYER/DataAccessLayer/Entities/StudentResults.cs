using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class StudentResults
    {
        public IEnumerable<Student> Students { get; set; }
        public PaginationData PaginationData { get; set; }
     
    }
    public record PaginationData (int totalRecords,int totalPages) ;
}
