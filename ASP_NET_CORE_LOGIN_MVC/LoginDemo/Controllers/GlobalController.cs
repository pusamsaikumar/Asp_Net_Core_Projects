using LoginDemo.Data;
using LoginDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.Security.Permissions;

namespace LoginDemo.Controllers
{
    public class GlobalController : Controller
    {
        private readonly ApplicationDBContext _context;

        public GlobalController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // addclient
        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }
        [HttpPost, ActionName("AddClient")]

        // submit
        public IActionResult SubmitClientDetails(RetailersModel model)
        {

            var result = _context.Retailers.Add(model);
            _context.SaveChanges();

            return View();
        }

        // to display retailer details
        public IActionResult ViewRetailers()

        {
            var result = _context.Retailers.ToList();
            return View(result);
        }

        // addclient store
        [HttpGet]
        public IActionResult AddClientStore()
        {
            return View();

        }
        [HttpPost, ActionName("AddClientStore")]
        public IActionResult SubmitClientStoreDetails(RetailersStoreModel model)
        {
            var result = _context.RetailersStore.Add(model);
            _context.SaveChanges();
            Console.WriteLine(result);
            return View();
        }
        [HttpGet]
        // view client stores
        public ActionResult ViewClientStores(int RSAClientId)
        {
            var model = _context.RetailersStore.FirstOrDefault(c => c.RSAClientId == RSAClientId);
            var result = _context.RetailersStore.ToList();

            return View(result);
            // RetailersStoreModel retailer = new RetailersStoreModel();
            // retailer.ClientStoreId = model.RSAClientId;
            //  retailer.ClientStoreId=model.ClientStoreId;
            //  retailer.StoreName = model.StoreName;
            //  retailer.StoreEmail = model.StoreEmail;
            //retailer.StoreProfile = model.StoreProfile;
            //  retailer.AddressLine1 = model.AddressLine1;
            //  retailer.City = model.City;
            //  retailer.StorePhone = model.StorePhone;
            //  retailer.ZipCode = model.ZipCode;
            //  retailer.StoreTimings = model.StoreTimings;
            //  return View(retailer);
        }

        // edit modal popup // get data 
        [HttpGet]
        public async Task<IActionResult> EditRetailerStoreDetails(int RSAClientId = 0)
        {
            // var result = _context.RetailersStore.FirstOrDefault(c=>c.RSAClientId == RSAClientId);
            if (RSAClientId == 0)
            {
                return View();
            }
            else
            {
                var result = await _context.RetailersStore.FindAsync(RSAClientId);
                if (result == null)
                {
                    return NotFound();
                }
                // Console.WriteLine(result);
                   return View(result);
               // return PartialView("_EditRetailerStoreDetails", result);
            }

        }

        // post editdata for modal
        [HttpPost]
        public IActionResult EditRetailerStoreDetails(int RSAClientId, RetailersStoreModel model)
        {
            var result = _context.RetailersStore.FirstOrDefault(c => c.RSAClientId == RSAClientId);
            if (result == null)
            {
                return PartialView("_EditRetailerStoreDetails", model);
            }

            result.ClientStoreId = model.ClientStoreId;
            result.AddressLine1 = model.AddressLine1;
            result.StoreEmail = model.StoreEmail;
            result.StoreName = model.StoreName;
            result.StoreProfile = model.StoreProfile;
            result.StorePhone = model.StorePhone;
            result.ZipCode = model.ZipCode;
            result.City = model.City;
            result.StoreTimings = model.StoreTimings;
            _context.RetailersStore.Update(result);
            _context.SaveChanges();
            //return PartialView("_EditRetailerStoreDetails", result);

            return RedirectToAction("ViewClientStores", "Global");
        }

        // Edit retailers details model popup
        [HttpGet]
        public async Task<IActionResult> EditRetailerDetails(int RSAClientId = 0)
        {
            if (RSAClientId == 0)
            {
                return View();
            }
            var result = await _context.Retailers.FindAsync(RSAClientId);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> EditRetailerDetails(int RSAClientId, RetailersModel model)
        {
            var result = await _context.Retailers.FirstOrDefaultAsync(c=>c.RSAClientId == RSAClientId);
            if (result == null)
            {
                return View(model);
            }
            result.RSAClientId = RSAClientId;

            result.ClientName = model.ClientName;
            result.Email = model.Email;
            result.AndriodArn = model.AndriodArn;
            result.IphoneArn = model.IphoneArn;
            result.AllUsersArn = model.AllUsersArn;
            result.DBName = model.DBName;
            result.PushNOtificationEnabled = model.PushNOtificationEnabled;
            result.IsEditView = model.IsEditView;
      _context.Retailers.Update(result);
             _context.SaveChanges();
        
            return RedirectToAction("ViewRetailers", "Global");
        }
    }
}