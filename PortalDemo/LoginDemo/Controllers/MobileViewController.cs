using LoginDemo.Data;
using LoginDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginDemo.Controllers
{
    public class MobileViewController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MobileViewController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult QueueRewardResults()
        {

            return View();
        }
        [HttpPost]
        public IActionResult QueueRewardResults(LoyalityMember model)
        {
            var result = _context.LoyalityMembers.ToList();
            
            return View(result);
        }
    }
}
