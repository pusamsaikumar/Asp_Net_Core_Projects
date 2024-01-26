

namespace Employee.Common.Models
{
    public class Response
    {
       
            public int StatusCode { get; set; }
            public string StatusMessage { get; set; }
            public List<Employee1> Employeeslist { get; set; }
        
    }
}
