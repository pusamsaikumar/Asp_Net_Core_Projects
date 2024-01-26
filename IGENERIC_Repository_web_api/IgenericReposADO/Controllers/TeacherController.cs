using IgenericReposADO.IService;
using IgenericReposADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IgenericReposADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class TeacherController : GenericController<Teacher>
    {
        public TeacherController(IGenericService<Teacher> genericService) : base(genericService)
        {
        }
    }
}
