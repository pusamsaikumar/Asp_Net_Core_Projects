using IdentityMemberMVC.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityMemberMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser>signInManager , UserManager<ApplicationUser>userManager)
        {
            _signInManager = signInManager;
           _userManager = userManager;
        }
        [HttpGet]

     
        public IActionResult Login()
        {
           

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login model)


        {
            var result = await _signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);
            if (ModelState.IsValid)
            {
                if (result.Succeeded)
                {
                   // return RedirectToAction("Index", "Home");
                   return RedirectToAction("Index","Admin");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }


            return View(model);
            //if(model.Username !=null && model.Password != null)
            //{
            //    var result = await _signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);
            //    if (ModelState.IsValid)
            //    {
            //        if (result.Succeeded)
            //        {
            //            return RedirectToAction("Index", "Home");
            //        }
            //        ModelState.AddModelError("", "Invalid login attempt.");
            //        return View(model);
            //    }


            //    return View(model);
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Please Enter Details");
            //    return View(model);
            //}
        }
        [HttpGet] 
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    Address = model.Address

                };
                var result = await _userManager.CreateAsync(user,model.Password!);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error  in result.Errors) { 
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View(model);
        }
        // UserManager is used to proived the register api   to user and used for require validation
        public async Task<IActionResult>  Logout()
        {
            await _signInManager.SignOutAsync();
           // return RedirectToAction("Index","Home");
           return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
