using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using socialMedia.Models;

namespace socialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment _env;

        public FileUploadController(IConfiguration configuration, IWebHostEnvironment env) {
            this.configuration = configuration;
            _env = env;
        }
        
        // upload the files:
        [HttpPost]
        [Route("uploadFile")]
        public Response UploadFile([FromForm] Fileupload fileupload)
        {
            Response response = new Response();
            Dal dal = new Dal();
            response = dal.UploadFile(fileupload);
            

            return response;

        }


        [HttpPost]
        [Route("SaveFile")]
        public JsonResult SaveFile([FromForm] Fileupload fileupload)
        {
            try
            {
                var httpRequest = Request.Form;
                var PostedFile = httpRequest.Files[0];
                string filename = PostedFile.FileName;
                // var PhysicalPath = _env.ContentRootPath + "/Photos/" + fileupload.FileName;
                var PhysicalPath = _env.ContentRootPath + "/Photos/" + filename;
                using (var stream = new FileStream(PhysicalPath, FileMode.Create))
                {
                   // PostedFile.CopyTo(stream);
                   fileupload.file.CopyTo(stream);
                }
                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }


    }
}
