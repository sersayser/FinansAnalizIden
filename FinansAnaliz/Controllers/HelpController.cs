using FinansAnaliz.Data;
using FinansAnaliz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HelpController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _appDbContext;
        public HelpController(AppDbContext appDbContext, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _appDbContext = appDbContext;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var user = _signInManager.UserManager.GetUserName(User);
            var HelpList = _appDbContext.Helps.Where(x => x.UserEmail == user).ToList();
            ViewBag.HelpList = HelpList;
            Help help = new Help();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  NewHelp(Help model)
        {
            var userEmail = _signInManager.UserManager.GetUserName(User);
            Help helpRequest = new Help();
            if (ModelState.IsValid)
            {
                helpRequest.IsSolved = false;
                helpRequest.Subject = model.Subject;
                helpRequest.Problem = model.Problem;
                helpRequest.ProblemDate = model.ProblemDate;
                helpRequest.UserEmail = userEmail;
                helpRequest.SolvingDate = String.Empty;
                helpRequest.Solution = String.Empty;
                await _appDbContext.AddAsync(helpRequest);
                await _appDbContext.SaveChangesAsync();
            }
            
            var HelpList = _appDbContext.Helps.Where(x => x.UserEmail == userEmail).ToList();
            ViewBag.HelpList = HelpList;
            TempData["message"] = "Başarıyla Eklendi!";
            return RedirectToAction("Index","Help");
        }
    }
}
