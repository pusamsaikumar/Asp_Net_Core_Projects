using MembershipMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Differencing;

namespace MembershipMVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            
            _signInManager = signInManager;
        }
        [HttpGet]
        public ActionResult Index()
        {
          
                var userId = _userManager.GetUserId(User);

             if(userId == null)
            {
                return RedirectToAction("Login","Account");
            } 

                ApplicationUser user = _userManager.FindByIdAsync(userId).Result!;

            return View(user); 
        }
        [HttpGet]
        public ActionResult View(string? id)
        {
            var user  =  _userManager.FindByIdAsync(id).Result!;
           

            var model = new LoginViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password =user.PasswordHash,
                PhoneNumber = user.PhoneNumber,

            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Settings(string Id)
        {
            if (Id == null)
            {
                var userId = _userManager.GetUserId(User);
                if (userId == null)
                {
                    return RedirectToAction("Login", "Account");
                }

                var user = _userManager.FindByIdAsync(userId).Result!;
                var model = new Edit
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                   Password = user.PasswordHash,
                    PhoneNumber = user.PhoneNumber,

                };
                return View(model);
            }
            else
            {
                var user = _userManager.FindByIdAsync(Id).Result!;

                var model = new Edit
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                   Password = user.PasswordHash,
                    PhoneNumber = user.PhoneNumber,

                };
                return View(model);
            }






        }
        [HttpPost]
        public async Task<IActionResult> Settings(Edit edit)
        {

          

            var user = await _userManager.FindByIdAsync(edit.Id);
            if (user == null )
            {

                ViewBag.Message = $"User with id = {edit.Id} can not be found";
                TempData["errorMessage"] = $"User with id = {edit.Id} can not be found";

                
                return RedirectToAction("Login", "Account");
            }
            else
            {

                //var hashPassword = _userManager.PasswordHasher.HashPassword(user, edit.Password!);
              //  user.PasswordHash = hashPassword;

                //  user.PasswordHash = await _userManager.PasswordHasher.HashPassword(newPassword);
                user.FirstName = edit.FirstName;
                user.LastName = edit.LastName;
                user.Email = edit.Email;
                 user.PasswordHash = edit.Password;
                user.PhoneNumber = edit.PhoneNumber;
             
                var result = await _userManager.UpdateAsync(user);
              //  await _signInManager.RefreshSignInAsync(user);

                if (result.Succeeded)
                {
                    TempData["successMessage"] = "Your profile has been updated";
                    return RedirectToAction("Dashboard", "Admin");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    TempData["errorMessage"] = "User Updation has been failed";
                }
                return View(edit);
            }
        }

        

        [HttpGet]
        public IActionResult Dashboard()
        {
            var result =  _userManager.Users;
            return View(result);
        }
        [HttpGet] 
        public IActionResult DeleteUser(string Id)

        {
            var user = _userManager.FindByIdAsync(Id).Result!;
            if(user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            
            var model = new DeleteViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,

            };
            return View(model);


          
        }
        [ActionName("DeleteUser")]
        [HttpPost]

        public async Task<IActionResult> ConfirmDeleteUser(string id)
        {
       
            ApplicationUser user = _userManager.FindByIdAsync(id).Result!;
            if (user == null)
            {
                ViewBag.Message = $"User with Id={id} can not be found";
                TempData["errorMessage"] = $"User with Id={id} can not be found";
                //  return View("NotFound");
                return RedirectToAction("Login", "Account");
            }
            else
            {
                IdentityResult result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    // await _signInManager.SignOutAsync();
                    TempData["successMessage"] = "User Deleted successfully";
                    //return RedirectToAction("Login", "Account");
                    return RedirectToAction("Dashboard", "Admin");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    TempData["errorMessage"] = "User deletion has been failed.";
                }

            }
            return View("Index", "Admin");
        }

     

        [HttpGet]
        public async  Task<IActionResult> EditProfile(string Id)
        {
            //var userId = _userManager.GetUserId(User);
            //if (userId == null)
            //{
            //    return RedirectToAction("Login", "Account");
            //}
            //ApplicationUser user = _userManager.FindByIdAsync(userId).Result!;
            //return View(user);

            var user = _userManager.FindByIdAsync(Id).Result!;

            if (user == null)
            {

                ViewBag.Message = $"User with id = {Id} can not be found";
                return View("NotFound");
            }
            
            var model = new Edit
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
              //  Password = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
               
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(Edit edit)
        {

            var user = await _userManager.FindByIdAsync(edit.Id);
            if (user == null)
            {

                ViewBag.Message = $"User with id = {edit.Id} can not be found";
                return View("NotFound");
            }
            else
            {
             
//var hashPassword = _userManager.PasswordHasher.HashPassword(user, edit.Password);
              //  user.PasswordHash = hashPassword;

                //  user.PasswordHash = await _userManager.PasswordHasher.HashPassword(newPassword);
                user.FirstName = edit.FirstName;
                user.LastName = edit.LastName;
                user.Email = edit.Email;
               // user.PasswordHash = edit.Password;
                user.PhoneNumber = edit.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                foreach(var item in result.Errors) {
                    ModelState.AddModelError("", item.Description);
                }
                return View(edit);
            }
         //   return View(edit);
        }
       
    }
}
