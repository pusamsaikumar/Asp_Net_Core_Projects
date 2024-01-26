using CloudinaryDotNet;
using ExcelDataReader;
using MembershipMVC.Data;
using MembershipMVC.Models.ExcelFileModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Simplify;
using NuGet.Protocol.Core.Types;
using System.Linq.Dynamic.Core;

namespace MembershipMVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDBContext _context;
        public SearchController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
           


            var result = _context.Customers.ToList();
            var model = new List<Customer>();
            foreach (var customer in result)
            {
                model.Add(customer);
            }
            return View(result);
        }

        [HttpPost]
        public IActionResult Index(string id)
        {

            return View();
        }
        //[HttpGet]
        //public IActionResult GlobalSearch()
        //{
        //    var result = _context.Customers.ToList();
           
        //    return View(result);
          
        //}
        [HttpGet]
        public IActionResult GlobalSearch(string searchString)

        {

          
            ViewData["filterString"] = searchString;
           
           var customerData = from c in _context.Customers  select c;
            if (!string.IsNullOrEmpty(searchString))
            {

              
                customerData = customerData.Where((c) => 
              c.Id.ToString().Contains(searchString)
             ||
             c.FirstName.ToLower().Contains(searchString.ToLower()) ||
             c.LastName.ToLower().Contains(searchString.ToLower())  ||
              c.Job.ToLower().Contains(searchString.ToLower())  ||
              c.Amount.ToString().Contains(searchString) ||

              c.Tdate.ToString().Contains(searchString)
              
             

               );
               
            }
          //  Console.WriteLine(customerData);
          
            var model = new List<Customer>();
            foreach (var customer in customerData)
            {
                model.Add(customer);
            }
            //Console.WriteLine(model);
            return View(customerData.ToList());
           
        }

        [HttpGet]    
        public IActionResult DataTableAjax()

        {
            // var result = _context.Customers.ToList();
            // return View(result);
            return View();
        }
        [HttpGet]  //get 
        public IActionResult GetCustomerList()
        {
            var result = _context.Customers.ToList();
            
            return new JsonResult(result);
        }
        [HttpPost]  // post
        public async Task<IActionResult>  GetCustomerLists()
        {
            try
            {
                // var req = Request.Form;
                int pageSize = 10;
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn= Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() +"][name]"].FirstOrDefault();
                var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                 pageSize = length != null ? Convert.ToInt32(length) : 0; 
                int skip = start != null ? Convert.ToInt32(start) : 0;
                var data = (from customerData in _context.Customers select customerData);
                 if(!string.IsNullOrEmpty(sortColumn)  && !string.IsNullOrEmpty(sortColumnDir))
                {
                    data = data.OrderBy(sortColumn + " " + sortColumnDir);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    data= data.Where
                        (e =>  
                        e.Id.ToString().Contains(searchValue )  || 
                        e.FirstName.Contains(searchValue) ||
                        e.LastName.Contains(searchValue) ||
                        e.Job.Contains(searchValue) ||
                         e.Amount.ToString().Contains(searchValue) ||
                        e.Tdate.ToString().Contains(searchValue)

                        );
                }
                var totalRecords = data.Count();
                var finalData = data.Skip(skip).Take(pageSize).Take(pageSize).ToList();
                var jsonData = new
                {
                  draw = draw,
                recordsFiltered = totalRecords,
                totalRecords = totalRecords,
                data = finalData
                };

                return new JsonResult(jsonData);
               
               
            }
            catch (Exception ex)
            {
                throw;
            }
            //return new JsonResult("");
        }

        [HttpPost]
        public async Task<IActionResult> DataTableAjax(IFormFile file)
        {
            // upload file
            if (file != null && file.Length > 0)
            {
                var uploadDirectory = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Uploads";
                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }
                var filePath = Path.Combine(uploadDirectory, file.Name);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // read file:
                using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    var excelData = new List<List<object>>();
                   

                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            while (reader.Read())
                            {
                                var rowData = new List<object>();
                                for (int column = 0; column < reader.FieldCount; column++)
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
        [HttpGet]
        public IActionResult ViewDetails (string id)
        {  
            return View();
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        // Server side pagination
        [HttpGet] 
        public IActionResult ServerSidePagination()
        {
            //var result = _context.Customers.ToList();
            //return View(result);
            return View();
        }
    }
}
