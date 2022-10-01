using FinansAnaliz.Data;
using FinansAnaliz.Models;
using FinansAnaliz.Models.Identity;
using FinansAnaliz.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Controllers
{
    public class AdminPanelController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private AppDbContext _appDbContext;

        public AdminPanelController(AppDbContext appDbContext, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult AddUser()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                var newUser = new AppUser() { NameOfUser = model.Name, Email = model.Email, UserName = model.Email, CompanyName = model.CompanyName, IsClient = true, MainCompanyCode = model.MainCompanyCode, PhoneNumber = model.PhoneNumber, AcceptTerms=model.AcceptTerms };
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(newUser.Email);
                    await _userManager.AddToRoleAsync(user, model.RoleOfUser);
                    return RedirectToAction("Index", "AdminPanel");
                }
                else
                {
                    TempData["err"] = "Bir Hata Oluştu!";
                    return RedirectToAction("AddUser", "AdminPanel");
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ChangeUserRole(string Email)
        {
            var usermodel = _appDbContext.AppUsers.Where(x => x.Email == Email).FirstOrDefault();
            var UserRole = await _userManager.GetRolesAsync(usermodel);
            ViewBag.UserRole = UserRole[0].ToString();
            ViewBag.usermodel = usermodel;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserRole(ChangeUserRole model)
        {
            var user = _userManager.Users.Where(x => x.Email == model.UserEmail).FirstOrDefault();
            await _userManager.RemoveFromRoleAsync(user, model.CurrentRole);
            await _userManager.AddToRoleAsync(user, model.NewRole);
            TempData["err"] = "İşlem başarıyla gerçekleştirilmiştir.";
            return RedirectToAction("Index", "AdminPanel");
        }
        [HttpGet]
        public IActionResult ChangePass(string Email)
        {
            var usermodel = _appDbContext.Users.Where(x => x.Email == Email).FirstOrDefault();
            ViewBag.User = usermodel;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePass(ChangePassViewModel changePassViewModel)
        {
            IdentityUser user = _userManager.Users.Where(x => x.Email == changePassViewModel.UserEmail).FirstOrDefault();
            var result = await _userManager.CreateAsync(user, changePassViewModel.NewPass);
            TempData["err"] = "Şifre başarıyla değiştirilmiştir.";
            return View();
        }

        [HttpGet]
        public IActionResult AddNewRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewRole(AddNewRoleViewModel addNewRoleViewModel)
        {
            IdentityRole role = new IdentityRole();
            role.Name = addNewRoleViewModel.NewRoleName;
            role.NormalizedName = addNewRoleViewModel.NewRoleName.ToUpper();
            await _appDbContext.Roles.AddAsync(role);
            await _appDbContext.SaveChangesAsync();
            TempData["err"] = $"{role.Name} kullanıcı tipi başarıyla eklendi!";
            return RedirectToAction("AddNewRole","AdminPanel");
        }
        [HttpGet]
        public IActionResult AnswerHelpRequest(int helpId)
        {
            var OpenHelp = _appDbContext.Helps.Where(x => x.Id == helpId).FirstOrDefault();
            ViewBag.OpenHelp = OpenHelp;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AnswerHelpRequest(OpenHelpViewModel openHelpViewModel)
        {
            var openHelp = _appDbContext.Helps.Where(x => x.Id == openHelpViewModel.HelpId).FirstOrDefault();
            openHelp.Solution = openHelpViewModel.Solution;
            openHelp.SolvingDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            openHelp.IsSolved = true;
            _appDbContext.Helps.Update(openHelp);
            await _appDbContext.SaveChangesAsync();
            return View();
        }
        [HttpGet]
        public IActionResult OpenHelpRequest()
        {
            var OpenHelpList = _appDbContext.Helps.Where(x => x.IsSolved == false).ToList();
            ViewBag.OpenHelpList = OpenHelpList;
            return View();
        }

        [HttpGet]
        public IActionResult AllHelpRequest()
        {
            var allHelpList = _appDbContext.Helps.Where(x=>x.IsSolved == true).OrderByDescending(x => x.ProblemDate).ToList();
            ViewBag.allHelpList = allHelpList;
            return View();
        }

        [HttpGet]
        public IActionResult ChangeEntryDate()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult ChangeEntryDate(string userEmail, DateTime date)
        {
            AppUser user = _appDbContext.AppUsers.Where(x => x.Email == userEmail).FirstOrDefault();
            List<EntryDate> enrtyDates = _appDbContext.EntryDates.Where(x => x.CompanyName == user.CompanyName).ToList();
            return View();
        }


    }
}
