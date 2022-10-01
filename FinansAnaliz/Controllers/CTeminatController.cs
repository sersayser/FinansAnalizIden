using FinansAnaliz.Data;
using FinansAnaliz.Models;
using FinansAnaliz.Models.Identity;
using FinansAnaliz.Models.Interface;
using FinansAnaliz.Models.UoW;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Controllers
{

    public class CTeminatController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITeminatRepository _teminatRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUoW _uoW;
        public CTeminatController(AppDbContext appDbContext, ITeminatRepository teminatRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IUoW uoW)
        {
            _appDbContext = appDbContext;
            _teminatRepository = teminatRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _uoW = uoW;
        }
        public IActionResult AlinanTeminat()
        {
            
            List<Banka> bankalar = _appDbContext.Bankalar.ToList();
            SelectList Bankalar = new SelectList(bankalar, "BankaAdi", "BankaAdi");
            ViewBag.BankaselectList = Bankalar;

            var signedinUser = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User));
            List<AppUser> users = _appDbContext.AppUsers.Where(x => x.MainCompanyCode == signedinUser.MainCompanyCode).Where(k => k.IsClient == true).ToList();
            SelectList userList = new SelectList(users, "CompanyName", "CompanyName");
            ViewBag.UserList = userList;

            var alinanTeminatListe = _appDbContext.Teminats.Where(x => x.CompanyName == signedinUser.CompanyName).Where(x => x.IsAlinanTeminat == true).ToList();
            ViewBag.AlinanTeminatListesi = alinanTeminatListe;

            var model = new Teminat();
            return View(model);
        }
        [HttpPost]
        public IActionResult AlinanTeminat(Teminat model)
        {
            var signedinUser = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User));
            if (ModelState.IsValid)
            {
                var yeniTeminat = new Teminat
                {
                    ToCompanyName = model.ToCompanyName,
                    CompanyName = signedinUser.CompanyName,
                    Banka = model.Banka,
                    TeminatNo = model.TeminatNo,
                    Tutar = model.Tutar,
                    BitisTarihi = model.BitisTarihi,
                    MainCompanyCode = signedinUser.MainCompanyCode.ToString(),
                    ToMainCompany = false,
                    IsEkTeminat = model.IsEkTeminat,
                    IsAlinanTeminat = true
                    
                };
                _teminatRepository.Create(yeniTeminat);
                _uoW.Commit();
                var alinanTeminatListe = _appDbContext.Teminats.Where(x => x.CompanyName == signedinUser.CompanyName).Where(x => x.IsAlinanTeminat == true).ToList();

                ViewBag.AlinanTeminatListesi = alinanTeminatListe;
            }
            else
            {

                return View();
            }
            List<Banka> bankalar = _appDbContext.Bankalar.ToList();
            SelectList Bankalar = new SelectList(bankalar, "BankaAdi", "BankaAdi");
            ViewBag.BankaselectList = Bankalar;


            List<AppUser> users = _appDbContext.AppUsers.Where(x => x.MainCompanyCode == signedinUser.MainCompanyCode).Where(k => k.IsClient == true).ToList();
            SelectList userList = new SelectList(users, "CompanyName", "CompanyName");
            ViewBag.UserList = userList;

            return View();
        }
        public IActionResult VerilenTeminat()
        {
            List<Banka> bankalar = _appDbContext.Bankalar.ToList();
            SelectList Bankalar = new SelectList(bankalar, "BankaAdi", "BankaAdi");
            ViewBag.BankaselectList = Bankalar;

            var signedinUser = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User));

            var VerilenTeminatListe = _appDbContext.Teminats.Where(x => x.CompanyName == signedinUser.CompanyName).Where(x => x.IsAlinanTeminat == false).ToList();
            ViewBag.VerilenTeminatListe = VerilenTeminatListe;

            var model = new Teminat();
            return View(model);
        }
        [HttpPost]
        public IActionResult VerilenTeminat(Teminat model)
        {
            var signedinUser = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User));
            if (ModelState.IsValid)
            {
                var yeniTeminat = new Teminat
                {
                    ToCompanyName = model.ToCompanyName,
                    CompanyName = signedinUser.CompanyName,
                    Banka = model.Banka,
                    TeminatNo = model.TeminatNo,
                    Tutar = model.Tutar,
                    BitisTarihi = model.BitisTarihi,
                    MainCompanyCode = signedinUser.MainCompanyCode.ToString(),
                    IsEkTeminat = model.IsEkTeminat,
                    IsAlinanTeminat = false,
                    ToMainCompany = model.ToMainCompany
                };
                _teminatRepository.Create(yeniTeminat);
                _uoW.Commit();
                var VerilenTeminatListe = _appDbContext.Teminats.Where(x => x.CompanyName == signedinUser.CompanyName).Where(x => x.IsAlinanTeminat == false).ToList();
                ViewBag.VerilenTeminatListe = VerilenTeminatListe;
                List<Banka> bankalar = _appDbContext.Bankalar.ToList();
                SelectList Bankalar = new SelectList(bankalar, "BankaAdi", "BankaAdi");
                ViewBag.BankaselectList = Bankalar;
                return View();
            }
            else
            {
                var VerilenTeminatListe = _appDbContext.Teminats.Where(x => x.CompanyName == signedinUser.CompanyName).Where(x => x.IsAlinanTeminat == false).ToList();
                ViewBag.VerilenTeminatListe = VerilenTeminatListe;
                List<Banka> bankalar = _appDbContext.Bankalar.ToList();
                SelectList Bankalar = new SelectList(bankalar, "BankaAdi", "BankaAdi");
                ViewBag.BankaselectList = Bankalar;
                return  View();
            }
        }
        [HttpPost]
        public IActionResult DeleteSet(int Id)
        {
            var DeletingTeminat = _appDbContext.Teminats.Where(x => x.Id == Id).FirstOrDefault();
            _appDbContext.Teminats.Remove(DeletingTeminat);
            _appDbContext.SaveChanges();

            return RedirectToAction("VerilenTeminat", "CTeminat");
        }
        [HttpPost]
        public IActionResult DeleteGet(int Id)
        {
            var DeletingTeminat = _appDbContext.Teminats.Where(x => x.Id == Id).FirstOrDefault();
            _appDbContext.Teminats.Remove(DeletingTeminat);
            _appDbContext.SaveChanges();

            return RedirectToAction("AlinanTeminat", "CTeminat");
        }
    }
}
