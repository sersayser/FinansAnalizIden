using FinansAnaliz.Data;
using FinansAnaliz.Models;
using FinansAnaliz.Models.Interface;
using FinansAnaliz.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using FinansAnaliz.Models.UoW;

namespace FinansAnaliz.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TeminatController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITeminatRepository _teminatRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUoW _uoW;
        public TeminatController(AppDbContext appDbContext, ITeminatRepository teminatRepository, UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,IUoW uoW)
        {
            _appDbContext = appDbContext;
            _teminatRepository = teminatRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _uoW = uoW;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AlinanTeminat()
        {
            var user = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User));

            List<Banka> bankalar = _appDbContext.Bankalar.ToList();
            SelectList Bankalar = new SelectList(bankalar, "BankaAdi", "BankaAdi");
            ViewBag.BankaselectList = Bankalar;

            var alinanTeminatListe = _appDbContext.Teminats.Where(x => x.CompanyName == user.CompanyName).Where(x => x.IsAlinanTeminat == true).ToList();
            var alinanToMainCompanyList = _appDbContext.Teminats.Where(x => x.ToCompanyName == user.CompanyName).Where(x => x.ToMainCompany == true).Where(x=>x.IsAlinanTeminat==false).ToList();

            ViewBag.AlinanTeminatListesi = alinanTeminatListe;
            ViewBag.alinanToMainCompanyList = alinanToMainCompanyList;
            
            var model = new Teminat();
            return View(model);
        }
        [HttpPost]
        public IActionResult AlinanTeminat(Teminat model)
        {
            var user = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User));
            if (ModelState.IsValid)
            {
                var yeniTeminat = new Teminat
                {
                    ToCompanyName = model.ToCompanyName,
                    CompanyName = user.CompanyName,
                    Banka = model.Banka,
                    TeminatNo = model.TeminatNo,
                    Tutar = model.Tutar,
                    BitisTarihi = model.BitisTarihi,
                    MainCompanyCode = user.MainCompanyCode.ToString(),
                    IsEkTeminat = model.IsEkTeminat,
                    IsAlinanTeminat = true,
                    ToMainCompany = false
                    
                };
                _teminatRepository.Create(yeniTeminat);
                _uoW.Commit();
                var alinanTeminatListe = _appDbContext.Teminats.Where(x => x.CompanyName == user.CompanyName).Where(x => x.IsAlinanTeminat == true).ToList();
                var alinanToMainCompanyList = _appDbContext.Teminats.Where(x => x.MainCompanyCode == user.MainCompanyCode.ToString()).Where(x => x.ToMainCompany == true).ToList();
                foreach (var item in alinanToMainCompanyList)
                {
                    alinanTeminatListe.Add(item);
                }
                ViewBag.AlinanTeminatListesi = alinanTeminatListe;
                TempData["message"] = "Başarıyla Eklendi";
                return RedirectToAction("AlinanTeminat");
            }
            else
            {

                return RedirectToAction("AlinanTeminat");
            }
            List<Banka> bankalar = _appDbContext.Bankalar.ToList();
            SelectList Bankalar = new SelectList(bankalar, "BankaAdi", "BankaAdi");
            ViewBag.BankaselectList = Bankalar;

            
            List<AppUser> users = _appDbContext.AppUsers.Where(x => x.MainCompanyCode == user.MainCompanyCode).Where(k => k.IsClient == true).ToList();
            SelectList userList = new SelectList(users, "CompanyName", "CompanyName");
            ViewBag.UserList = userList;

            return View();
        }
        [HttpGet]
        public IActionResult VerilenTeminat()
        {
            List<Banka> bankalar = _appDbContext.Bankalar.ToList();
            SelectList Bankalar = new SelectList(bankalar, "BankaAdi", "BankaAdi");
            ViewBag.BankaselectList = Bankalar;

            var user = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User));

            var VerilenTeminatListe = _appDbContext.Teminats.Where(x => x.CompanyName == user.CompanyName).Where(x => x.IsAlinanTeminat == false).ToList();
            ViewBag.VerilenTeminatListe = VerilenTeminatListe;

            var model = new Teminat();
            return View(model);
        }
        [HttpPost]
        public IActionResult VerilenTeminat(Teminat model)
        {
            var user = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User));
            if (ModelState.IsValid)
            {
                var yeniTeminat = new Teminat
                {
                    ToCompanyName = model.ToCompanyName,
                    CompanyName = user.CompanyName,
                    Banka = model.Banka.Trim(),
                    TeminatNo = model.TeminatNo,
                    Tutar = model.Tutar,
                    BitisTarihi = model.BitisTarihi,
                    MainCompanyCode = user.MainCompanyCode.ToString(),
                    IsEkTeminat = model.IsEkTeminat,
                    IsAlinanTeminat = false,
                    ToMainCompany = false
                };
                _teminatRepository.Create(yeniTeminat);
                _uoW.Commit();
                var VerilenTeminatListe = _appDbContext.Teminats.Where(x => x.CompanyName == user.CompanyName).Where(x => x.IsAlinanTeminat == false).ToList();
                ViewBag.VerilenTeminatListe = VerilenTeminatListe;
                TempData["message"] = "Başarıyla Eklendi";
            }
            else
            {
                List<Banka> bankalar = _appDbContext.Bankalar.ToList();
                SelectList Bankalar = new SelectList(bankalar, "BankaAdi", "BankaAdi");
                ViewBag.BankaselectList = Bankalar;
                return View();
            }

            return View();
        }

        [HttpPost]
        public IActionResult DeleteGet(int Id)
        {
            var DeletingTeminat = _appDbContext.Teminats.Where(x => x.Id == Id).FirstOrDefault();
            _appDbContext.Teminats.Remove(DeletingTeminat);
            _appDbContext.SaveChanges();
            TempData["message"] = "Başarıyla Silindi";
            return RedirectToAction("AlinanTeminat","Teminat");
        }
        [HttpPost]
        public IActionResult DeleteSet(int Id)
        {
            var DeletingTeminat = _appDbContext.Teminats.Where(x => x.Id == Id).FirstOrDefault();
            _appDbContext.Teminats.Remove(DeletingTeminat);
            _appDbContext.SaveChanges();

            return RedirectToAction("VerilenTeminat", "Teminat");
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
