using BusinessLogicLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.ServiceModel;
using System.Threading.Tasks.Sources;

namespace StudentThreeTier.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ISingleTonService _singleTonService1;
        private readonly ISingleTonService _singleTonService2;

        public HomeController(
         
               ITransientService transientService1,
               ITransientService transientService2,
               IScopedService scopedService1,
               IScopedService scopedService2,
               ISingleTonService singleTonService1,
               ISingleTonService singleTonService2




            )
        {
         
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singleTonService1 = singleTonService1;
            _singleTonService2 = singleTonService2;
        }
      
        [HttpGet]
        [Route("GetTaskIds")]
        public IActionResult GetTaskIds()
        {
            


            //var transient1 = _transientService1.GetTaskID().ToString(); 
            //var transient2= _transientService2.GetTaskID().ToString();  
            //var scoped1= _scopedService1.GetTaskID().ToString();
            //var scoped2= _scopedService2.GetTaskID().ToString();
            //var single1=_singleTonService1.GetTaskID().ToString();
            //var single2 = _singleTonService2.GetTaskID().ToString();
            var transient1 = _transientService1.GetTransientGuid().ToString();
            var transient2 = _transientService2.GetTransientGuid().ToString();
            var scoped1 = _scopedService1.GetScooedGuid().ToString();
            var scoped2 = _scopedService2.GetScooedGuid().ToString();
            var single1 = _singleTonService1.GetSingleTonGuid().ToString();
            var single2 = _singleTonService2.GetSingleTonGuid().ToString();
            var obj = new
            {
                transient1,
               transient2,
                scoped1,
                scoped2,
                single1,
                single2,
            };

            return Ok(obj);
        }
    }
}
