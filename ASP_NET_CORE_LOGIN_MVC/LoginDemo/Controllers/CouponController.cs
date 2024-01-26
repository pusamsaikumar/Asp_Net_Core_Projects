using Microsoft.AspNetCore.Mvc;

namespace LoginDemo.Controllers
{
    public class CouponController : Controller
    {
        //ViewCoupon
        [HttpGet]
        public IActionResult ViewCoupon()
        {
            return View();
        }

        //RecurringCoupons
        [HttpGet]
        public IActionResult RecurringCoupons()
        {
            return View();
        }
    }
}
