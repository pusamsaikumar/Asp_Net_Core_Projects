using Microsoft.AspNetCore.Mvc;



using Microsoft.AspNetCore.Identity;
using MembershipMVC.Models;
using Microsoft.AspNetCore.Authorization;
using MembershipMVC.Data;
using System.Net.Mail;
using System.Threading.Tasks;

using System.Text.Encodings.Web;
using Microsoft.CodeAnalysis.Operations;

using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.SignalR;

namespace MembershipMVC.Controllers
{

    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
    
        private readonly ILogger _logger;

       private readonly IEmailSender _emailSender;

        public AccountController(
          
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager,
    
            ILogger<AccountController> logger,
            IEmailSender emailSender
            
           )
        {
            _signInManager = signInManager;
            _userManager = userManager;
           // _db = db;
            _logger= logger;
          
            _emailSender = emailSender;
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
                    //  return RedirectToAction("Index", "Home");
                    TempData["successMessage"] = "User logged in successfully";
                   return RedirectToAction("Index", "Admin");
                  // return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    TempData["errorMessage"] = "User login failed";
                }
               
                return View(model);
            }

            return View(model);
           
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
                    return RedirectToAction("Dashboard", "Admin");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    TempData["errorMessage"] = "User Registration has been failed.";
                }
            }
            return View(model);
        }
        // UserManager is used to proived the register api   to user and used for require validation
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out!..");
            return RedirectToAction("Index","Home");
           // return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
       
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // GET: /Account/ConfirmEmail
        [HttpGet]



        public async Task<IActionResult> ConfirmEmail(string email, string code)
        {

            if (email == null || code == null)
            {
                //return view();
                return RedirectToAction("login", "account");
            }

            
            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                //return view();
                return RedirectToAction("login", "account");

            }
            var result = await _userManager.ConfirmEmailAsync(user, code);

            //  return redirecttoaction("confirmemail", "account");

            return View(result.Succeeded ? "ConfirmEmail" : "Login");
        }
        // Account/Forgot

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotModelView model)
        {
            //if (!ModelState.IsValid)
            //    return View(model);
            //var user = await _userManager.FindByEmailAsync(model.Email!);
            //if (user == null)
            //    return RedirectToAction("ForgotPasswordConfirm", "Account");
            //var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            //var callback = Url.Action(nameof(ResetPassword), "Account", new {  email = user.Email,code =code }, Request.Scheme);
            //// var message = new Message(new string[] { user.Email }, "Reset password token", callback, null);
            //var callbackUrl = Url.Action("ResetPassword", "Account", new { Email = model.Email, code = code }, protocol: HttpContext.Request.Scheme);
            //     await _emailSender.SendEmailAsync(model.Email!, "Reset Password", $"Please reset your password by clicking following url here: <a href='{callbackUrl}'>Login</a>");

            //return RedirectToAction("ForgotPasswordConfirm", "Account");

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email!);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirm");
                }
                string code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { Email = user.Email, code = code }, protocol: HttpContext.Request.Scheme);
                await _emailSender.SendEmailAsync(model.Email!, "Reset Password", $"Please reset your password by clicking following url here: <a href='{callbackUrl}'>Login</a>");
                return RedirectToAction("ForgotPasswordConfirm", "Account");

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult ForgotPasswordConfirm()
        {
            return View(); 
        }


      
        [HttpGet]
       
        public IActionResult ResetPassword()
        {
            return  View();
        }
        

        [HttpPost]
        
        public async Task<IActionResult> ResetPassword(ResetPasswordView resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordModel);

            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }


            var result = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Code, resetPasswordModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View();
            }

            return RedirectToAction("ResetPasswordConfirmation", "Account");
        }
        [HttpGet]
  
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }


}
