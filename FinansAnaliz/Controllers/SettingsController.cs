using FinansAnaliz.Data;
using FinansAnaliz.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Controllers
{
    public class SettingsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly UserManager<IdentityUser> UserManager;
        public SettingsController(AppDbContext appDbContext,SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager)
        {
            _appDbContext = appDbContext;
            SignInManager = signInManager;
            UserManager = userManager;
        }
        public IActionResult Index()
        {
            var userEmail = SignInManager.UserManager.GetUserName(User);
            var user = _appDbContext.AppUsers.Where(x => x.Email == userEmail).Select(x=>x.CompanyName).FirstOrDefault();
            var IsClient = _appDbContext.AppUsers.Where(x => x.CompanyName == user).Select(x => x.IsClient).FirstOrDefault();
            var hasEntity = _appDbContext.Settings.Where(x => x.CompanyName == user).FirstOrDefault();
            if (hasEntity != null)
            {
                return View(hasEntity);
            }
            var settin = new Settings();
            return View(settin);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Settings model)
        {
            var IsClient = _appDbContext.AppUsers.Where(x => x.CompanyName == model.CompanyName).Select(x => x.IsClient).FirstOrDefault();
            var hasEntity = _appDbContext.Settings.Where(x => x.CompanyName == model.CompanyName).Any();
            if (ModelState.IsValid&&hasEntity==false)
            {
                Settings newSettings = new Settings() {CompanyName = model.CompanyName,IsAlertRuleWarning=model.IsAlertRuleWarning,IsAlertTeminatEnds=model.IsAlertTeminatEnds,IsClientShowBook=model.IsClientShowBook,AlertTeminatRemainingDay=model.AlertTeminatRemainingDay,ExtraEmail1=model.ExtraEmail1,ExtraEmail2=model.ExtraEmail2,ExtraEmail3=model.ExtraEmail3 };
                await _appDbContext.Settings.AddAsync(newSettings);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Settings");
            }
            else if (ModelState.IsValid && hasEntity == true)
            {
                var Entity = _appDbContext.Settings.Where(x => x.CompanyName == model.CompanyName).FirstOrDefault();
                Entity.IsAlertRuleWarning = model.IsAlertRuleWarning;
                Entity.IsAlertTeminatEnds = model.IsAlertTeminatEnds;
                Entity.IsClientShowBook = model.IsClientShowBook;
                Entity.AlertTeminatRemainingDay = model.AlertTeminatRemainingDay;
                Entity.ExtraEmail1 = model.ExtraEmail1;
                Entity.ExtraEmail2 = model.ExtraEmail2;
                Entity.ExtraEmail3 = model.ExtraEmail3;
                _appDbContext.Settings.Update(Entity);
                await _appDbContext.SaveChangesAsync();
                TempData["message"] = "Başarıyla Güncellendi";
                return RedirectToAction("Index", "Settings", TempData["message"]);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Client()
        {
            var userEmailClient = SignInManager.UserManager.GetUserName(User);
            var userClient = _appDbContext.AppUsers.Where(x => x.Email == userEmailClient).Select(x => x.CompanyName).FirstOrDefault();
            var hasEntity = _appDbContext.Settings.Where(x => x.CompanyName == userClient).FirstOrDefault();
            if (hasEntity != null)
            {
                return View(hasEntity);
            }
            var settin = new Settings();
            return View(settin);
        }
        [HttpPost]
        public async Task<IActionResult> Client(Settings model)
        {
            var IsClient = _appDbContext.AppUsers.Where(x => x.CompanyName == model.CompanyName).Select(x => x.IsClient).FirstOrDefault();
            var hasEntity = _appDbContext.Settings.Where(x => x.CompanyName == model.CompanyName).Any();
            if (ModelState.IsValid && hasEntity == false)
            {
                Settings newSettings = new Settings() { CompanyName = model.CompanyName, IsAlertRuleWarning = model.IsAlertRuleWarning, IsAlertTeminatEnds = model.IsAlertTeminatEnds, IsClientShowBook = model.IsClientShowBook, AlertTeminatRemainingDay = model.AlertTeminatRemainingDay, ExtraEmail1 = model.ExtraEmail1, ExtraEmail2 = model.ExtraEmail2, ExtraEmail3 = model.ExtraEmail3 };
                await _appDbContext.Settings.AddAsync(newSettings);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction("Client", "Settings");
            }
            else if (ModelState.IsValid && hasEntity == true)
            {
                var Entity = _appDbContext.Settings.Where(x => x.CompanyName == model.CompanyName).FirstOrDefault();
                Entity.IsAlertRuleWarning = model.IsAlertRuleWarning;
                Entity.IsAlertTeminatEnds = model.IsAlertTeminatEnds;
                Entity.IsClientShowBook = model.IsClientShowBook;
                Entity.AlertTeminatRemainingDay = model.AlertTeminatRemainingDay;
                Entity.ExtraEmail1 = model.ExtraEmail1;
                Entity.ExtraEmail2 = model.ExtraEmail2;
                Entity.ExtraEmail3 = model.ExtraEmail3;
                _appDbContext.Settings.Update(Entity);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction("Client", "Settings");

            }
            return View();
        }
    }
}
