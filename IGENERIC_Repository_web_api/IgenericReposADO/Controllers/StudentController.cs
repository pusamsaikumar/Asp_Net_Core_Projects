using IgenericReposADO.IService;
using IgenericReposADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IgenericReposADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : GenericController<Student>
    {
        public StudentController(IGenericService<Student> genericService) : base(genericService)
        {
        }
    }
}
