using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Incorrect Credentials");
                return View();
            }
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Incorrect Credentials");
                return View();
            }
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }
        //public async Task<IActionResult> CreateUser()
        //{
        //    IdentityUser user = new IdentityUser
        //    {
        //        Email = "admin@mysite.com",
        //        UserName = "admin"
        //    };
        //    IdentityResult identityResult = await _userManager.CreateAsync(user, "Admin010");
        //    if (!identityResult.Succeeded) return Json(identityResult.Errors.Select(x => x.Description));
        //    return Content("ok");
        //}

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
