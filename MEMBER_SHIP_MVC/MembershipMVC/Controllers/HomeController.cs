using ExcelDataReader;
using Humanizer;
using MembershipMVC.Data;
using MembershipMVC.Models;
using MembershipMVC.Models.ExcelFileModels;
using MembershipMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MembershipMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IConfiguration _config;
        private readonly IPhotoService _photoService;
        private readonly IPhotosDataRepo _photosDataRepo;
        private readonly ApplicationDBContext _context;

        public HomeController(
            ILogger<HomeController> logger,
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IConfiguration configuration,
          IPhotoService photoService,
          IPhotosDataRepo photosDataRepo,
          ApplicationDBContext context
            )
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = configuration;
            _photoService = photoService;
            _photosDataRepo = photosDataRepo;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {

            return View();

        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,


                };


                var result = await _userManager.CreateAsync(user, model.Password);


                if (result.Succeeded)
                {
                    //  await _signInManager.SignInAsync(user, isPersistent: false);
                    TempData["successMessage"] = "User Register successfully";
                    //   return RedirectToAction("Index", "Home");
                    //  return RedirectToAction("Dashboard", "Admin");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    TempData["errorMessage"] = "User Registration has been failed.";
                }
            }
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> About()
        {
            var result = await _photosDataRepo.GetAll();
            return View(result);

        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(PhotoUploadModel photoUploadModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(photoUploadModel.Image);
                var photo = new PhotoViewModel
                {
                    Id = photoUploadModel.Id,
                    Image = result.Uri.ToString(),
                };

                // return View(photo);
                _photosDataRepo.Add(photo);
                //return View("index");
                return RedirectToAction("About","Home");

            } else {
                ModelState.AddModelError("", "Photo Update has been failed");

            }

            return View(photoUploadModel);
        }

        // Get by Id edit image
        [HttpGet]
        public async Task<IActionResult> EditImage(int id)
        {
            var result = await _photosDataRepo.GetByIdAsync(id);
            if(result == null)
            {
                return RedirectToAction("Error");
            }
        
                var model = new EditImageView
                {
                    Id = result.Id,
                    URL = result.Image,



                };
                return View(model);
            
            
        }

        [HttpPost]
        public async Task<IActionResult> EditImage(EditImageView model)
        {
            if(ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(model.Image);
                if (result == null)
                {

                    return View("Error");
                }
                var EditPhoto = new PhotoViewModel
                {
                    Id = model.Id,
                    Image = result.Uri.ToString()
                };

                _photosDataRepo.Update(EditPhoto);
                return RedirectToAction("About","Home");
            }
         

     
            return View(model);


        }
        [HttpGet]
        public async Task<IActionResult> DeleteImg(int id)
        {
            var photo = await _photosDataRepo.GetByIdAsync(id);
            if (photo != null)
            {
                return View(photo);
            }
            return View("Error");
        }
        [HttpPost, ActionName("DeleteImg")]
        public async Task<IActionResult> Delete(int id)
        {
            var details = await _photosDataRepo.GetByIdAsync(id);
            if (details == null)
            {
                return View("Error");
            }
            if (!string.IsNullOrEmpty(details.Image))
            {
                _ = _photoService.DeletePhotoAsync(details.Image);
            }
            _photosDataRepo.Delete(details);
            return RedirectToAction("About","Home");
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        // EXCEL FILE READER
        [HttpGet]
        public IActionResult ExcelFileReader()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ExcelFileReader(IFormFile file)
        {
            // upload file
            if(file != null && file.Length > 0)
            {
                var uploadDirectory = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Uploads";
                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }
                var filePath = Path.Combine(uploadDirectory, file.Name);
                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // read file:
                using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    var excelData = new List<List<object>>();
                    using( var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            while (reader.Read())
                            {
                                var rowData = new List<object>();
                                for(int column =0; column < reader.FieldCount; column++)
                                {
                                    rowData.Add(reader.GetValue(column));
                                }
                                excelData.Add(rowData);
                                ViewBag.ExcelData = excelData;  
                            }

                        } while (reader.NextResult());
                    }
                }
            }
            return View();
        }

        // Excel to Database
        [HttpGet]
        public IActionResult ExcelToDb() { return View(); }
        [HttpPost]
        public async Task<IActionResult> ExcelToDb(IFormFile file)
        {
            if(file != null && file.Length > 0)
            {

                // upload file
                var uploadDirectory = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Uploads";
                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }
                var filePath = Path.Combine(uploadDirectory, file.Name);
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // save to databse

                using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            bool isHeaderSkipped = false;
                            while (reader.Read())
                            {
                                if (!isHeaderSkipped)
                                {
                                    isHeaderSkipped = true;
                                    continue;
                                }

                                // Assing data inside student table here

                                Student s = new Student();
                                s.Name = reader.GetValue(1).ToString();   
                                s.Marks = Convert.ToInt32(reader.GetValue(2).ToString());    

                              _context.Students.Add(s);
                                await _context.SaveChangesAsync();  
                            }
                        } while (reader.NextResult());
                        ViewBag.Message = "success";
                    }
                }
            }
            else
            {
                ViewBag.Message = "empty";
            }
            return View();
        }
       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}