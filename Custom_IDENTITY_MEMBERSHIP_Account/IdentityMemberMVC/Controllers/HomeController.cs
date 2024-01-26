using IdentityMemberMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdentityMemberMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
     //   private readonly ILogger<HomeController> _logger;
        public HomeController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;   
        }


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        // SINGLE FILE UPLOAD
        //public async Task<IActionResult>  Index(IFormFile file)
        //{
        //    string uploadsFolder = Path.Combine(_webHost.WebRootPath,"Uploads");
        //    if(!Directory.Exists(uploadsFolder))
        //    {
        //        Directory.CreateDirectory(uploadsFolder);
        //    }
        //    string fileName = Path.GetFileName(file.FileName);
        //    string fileSavePath = Path.Combine(uploadsFolder,fileName);
        //    using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
        //    {
        //         await file.CopyToAsync(stream);
        //    }
        //    ViewBag.Message = fileName + "upload successfully";
        //   return View(file);
        //}

        // Multiple uploads:
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            string uploadsFolder = Path.Combine(_webHost.WebRootPath, "Uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            foreach ( var file in files)
            {
                string fileName = Path.GetFileName(file.FileName);
                string fileSavePath = Path.Combine(uploadsFolder, fileName);
                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                ViewBag.Message +=  string.Format("<b>{0}</b> uploaded successfully. <br/>", fileName);
            }
          
          
            return View(files);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}