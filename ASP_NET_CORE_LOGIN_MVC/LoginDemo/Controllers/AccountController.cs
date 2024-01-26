using LoginDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace LoginDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(

              UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model ,string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
             var checkEmail = await _userManager.FindByNameAsync(model.Email!);
                if(checkEmail == null)
                {
                    TempData["checkEmail"] = "Invalid Email Address";
                    return View(model);
                }
                if(await _userManager.CheckPasswordAsync(checkEmail,model.Password!) == false)
                {
                    TempData["WrongPass"] = "Invalid Password";
                    return View(model);
                }
                var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, false, false);
                if (result.Succeeded)
                {
                    TempData["success"] = "User logged in successfully";
                    
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                   // ModelState.AddModelError("", "Invalid Login Attempt");
                    TempData["errorMessage"] = "Invalid login attempt!";
                }
            }
           

            return View(model);
           
        }

        // register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)

        {
            if (ModelState.IsValid)
            {

               var checkEmail = await _userManager.FindByEmailAsync(model.Email);
                if (checkEmail != null)
                {
                    ModelState.AddModelError("", "Email Address already Existed!");
                    TempData["chkEmail"] = "Email Address already Existed";
                    return View(model);
                }
                else
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email,

                    };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                
            }
            return View(model);
        }
     
        public async Task<IActionResult>  Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
           
        }
    }
}
