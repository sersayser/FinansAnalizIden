using FinansAnaliz.Models.Identity;
using FinansAnaliz.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinansAnaliz.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUser() { NameOfUser = model.Name, Email = model.Email, UserName = model.Email, CompanyName = model.CompanyName, IsClient = true, MainCompanyCode = model.MainCompanyCode };
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    //var ss  = _signInManager.IsSignedIn(User);
                    //var mail = _userManager.GetEmailAsync(user);

                    var user = await _userManager.FindByNameAsync(newUser.Email);
                    await _userManager.AddToRoleAsync(user, "Client");
                    return RedirectToAction("Index", "Client");
                }
                else
                {
                    AddErrors(result);
                }
            }
            RegisterViewModel registerViewModel = new RegisterViewModel();

            return View(registerViewModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await _roleManager.RoleExistsAsync("Client"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Client"));
            }

            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                var user = await _signInManager.UserManager.FindByNameAsync(model.Email);
                if (result.Succeeded && await _userManager.IsInRoleAsync(user,"Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                if (result.Succeeded && await _userManager.IsInRoleAsync(user, "Client"))
                {
                    return RedirectToAction("Index", "Client");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Hatalı şifre ve kullanıcı adı kombinasyonu!");
                    return View(model);
                }

            }
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPass()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult ForgotPass(ForgotPassViewModel model)
        {
            return View();
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }
        }

    }
}
