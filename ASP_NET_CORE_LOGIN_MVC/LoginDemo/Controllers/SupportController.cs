using LoginDemo.Data;
using LoginDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using static LoginDemo.Models.GetClientsInputModel;

namespace LoginDemo.Controllers
{
    public class SupportController : Controller
    {
        private readonly ApplicationDBContext _context;

        public SupportController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // get all records of tables for system over view:
        [HttpGet] 
       public JsonResult GelAllRecords()

        { 
            var Table= _context.Basket.ToList();
            var Table1 = _context.Redemption.ToList();
            var Table2= _context.Reward.ToList();
            var Table3 = _context.OptIns.ToList();
            var Table4=_context.UserRegister.ToList();

            var data = new { Table,Table1,Table2,Table3,Table4 };
            string allrecord = JsonConvert.SerializeObject(data);
            var record = JsonConvert.DeserializeObject<RootObject>(allrecord);
            Console.WriteLine(record);
           return Json(new { data=record});
        }
        // Find shopper:
        public ActionResult FindShopper()
        {
            var result = _context.ShopperInfos.ToList();
            return View(result);
        }
        [HttpPost]
        public ActionResult FindShopper(string UserName = "", string MemberNumber = "")
        {
            var shopperData = from s in _context.ShopperInfos select s;
            if (!string.IsNullOrEmpty(UserName))
            {
                shopperData = shopperData.Where((s) =>
                s.USERNAME.ToString().Contains(UserName.ToLower())
                );
            }
            if (!string.IsNullOrEmpty(MemberNumber))
            {
                shopperData = shopperData.Where((s) =>
                 s.MemberNumber.ToString().Contains(MemberNumber.ToLower())
                );
            }
           
            // return View(shopperData);
            return PartialView("_FindShopperSearchResult", shopperData);
        }
        [HttpGet]
        public ActionResult FindShopperSearchResult()
        {
            var result = _context.ShopperInfos.ToList();



           // return View(result);
            return PartialView("_FindShopperSearchResult", result);
        }

       

        [HttpPost]
        public  IActionResult FindShopperSearchResult(ShopperInfo? shopperJson, string UserName = "", string MemberNumber = "")
        {


            IQueryable<ShopperInfo> queryable = _context.ShopperInfos;

         //   var shopperData = from s in _context.ShopperInfos select s;
            if (!string.IsNullOrEmpty(UserName))
            {
                //shopperData = shopperData.Where((s) =>
                //s.USERNAME.Contains(UserName)
                //);

                queryable = queryable.Where((s) => s.USERNAME.Contains(UserName));
           
            }
            if (!string.IsNullOrEmpty(MemberNumber))
            {
                //shopperData = shopperData.Where((s) =>
                //s.USERNAME.Contains(MemberNumber)
                //);
                queryable = queryable.Where((s) => s.MemberNumber.Contains(MemberNumber));
            }
            //Console.WriteLine(shopperData);
            // return View(shopperData);
           
            return PartialView("_FindShopperSearchResult", queryable.ToList());

           

        }

        // MissingQtoken
        [HttpGet]
        public IActionResult MissingQtoken()
        {
            return View();
        }
        //Pushnotification
        [HttpGet]
        public IActionResult Pushnotification()
        {
            return View();  
        }
        //SystemOverView
        [HttpGet]
        public IActionResult SystemOverView()
        {
            return View();
        }

        //BasketReceived
        [HttpGet]
        public IActionResult BasketReceived()
        {
            return View();
        }
        //LastRedemption
        [HttpGet]
        public IActionResult LastRedemption()
        {
            return View();
        }
        //RewardStuck
        [HttpGet]
        public IActionResult RewardStuck(string FindMember="")
        {
            RewardsModel model = new RewardsModel();    
            
            return View(model);
        }
        //GetMyRewards
        [HttpGet]
        public IActionResult GetMyRewards()
        {
            var result = _context.lMGetRewards.ToList();
            return View(result);
        }
        //upcs
        [HttpGet]
        public ActionResult AddMoreUpcs()
        {
            //return PartialView("_AddMoreUPCs");
            return View();
        }
        //RewardOpt_Ins
        [HttpGet]
        public IActionResult RewardOpt_Ins()
        {
            return View();
        }
    }
}
