using MembershipMVC.Data;
using MembershipMVC.Models.ExcelFileModels;
using MembershipMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MembershipMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICustomer _customerservice;
        private readonly ApplicationDBContext _context;

        public CustomerController(
            IStudentService studentService,
            IWebHostEnvironment webHostEnvironment,
            ICustomer customerservice,
            ApplicationDBContext context
            
            
            )
        {
            _studentService = studentService;
            _webHostEnvironment = webHostEnvironment;
            _customerservice = customerservice;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Customers.ToList();
            //Console.WriteLine( result );
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Index(IFormFile formFile)
        {
           
            if(formFile != null  && formFile.Length > 0)
            {
                string Path = _customerservice.DocumentUpload(formFile);
                DataTable dt = _customerservice.CustomerDatable(Path);
                _customerservice.ImportCustomer(dt);
                ViewBag.Message = "success";
            }
             else
            {
                ViewBag.Message = "empty";
            }

            return View();
        }
        // PAGINATION
        [HttpGet]
        public  IActionResult Pagination()
        {

            var result = _context.Customers.ToList();
            var model = new List<Customer>();
            foreach (var customer in result)
            {
                model.Add(customer);
            }
            return View(result);
        }
    
    }
}
