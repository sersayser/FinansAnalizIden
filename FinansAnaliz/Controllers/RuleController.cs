using FinansAnaliz.Data;
using FinansAnaliz.Models;
using FinansAnaliz.Models.Identity;
using FinansAnaliz.Models.Interface;
using FinansAnaliz.Models.UoW;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using FinansAnaliz.Models.AnalizModel;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using System.Linq.Expressions;

namespace FinansAnaliz.Controllers
{
    public class RuleController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITeminatRepository _teminatRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUoW _uoW;
        public RuleController(AppDbContext appDbContext, ITeminatRepository teminatRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IUoW uoW)
        {
            _appDbContext = appDbContext;
            _teminatRepository = teminatRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _uoW = uoW;
        }

        [HttpGet]
        public IActionResult Settings()
        {
            var Rule = _appDbContext.RuleNames.ToList();
            var rulelist = Rule.Select(s => new SelectListItem { Text = s.ruleName, Value = s.Rule }).ToList();
            ViewBag.RuleList = rulelist;

            List<string> operantList = new List<string>();
            operantList.Add("Büyüktür");
            operantList.Add("BüyüktürEşittir");
            operantList.Add("Küçüktür");
            operantList.Add("KüçüktürEşittir");
            var OperantList = operantList.Select(s => new SelectListItem { Text = s, Value = s }).ToList();
            ViewBag.OperantList = OperantList;

            var user = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User));

            var RuleCheckList = _appDbContext.Rules.Where(x => x.CompanyName == user.CompanyName).ToList();
            ViewBag.RuleCheckList = RuleCheckList;

            var companyEntryDates = GetCompanyEnrtyDates();

            foreach (var item in RuleCheckList)
            {
                for (int i = 0; i < companyEntryDates.Count; i++)
                {
                    RuleCheck(item.RefrenceValue, item.RulePropery, companyEntryDates[i].CompanyName, companyEntryDates[i].DateEntry.ToString("yyyy-MM-dd"), item.Id, item.Operant, user.CompanyName, item.RuleName);
                }
            }

            var ProblemCompanyList = _appDbContext.ruleProblemCompanies.Where(x => x.RegisterCompany == user.CompanyName).Where(x => x.IsActive == true).ToList();
            ViewBag.ProblemCompanyList = ProblemCompanyList;
            var MailingList = new List<string>() { user.Email, user.ExtraEmail1, user.ExtraEmail2, user.ExtraEmail3 };
            
            // Mailing
            //foreach (var item in ProblemCompanyList)
            //{
            //    for (int i = 0; i < MailingList.Count; i++)
            //    {
            //        Mail.SendMail(MailingList[i].Trim(), item.RuleName, item.ProblemCompanyName);
            //    }
            //    item.IsMailSent = true;
            //    _appDbContext.ruleProblemCompanies.Update(item);
            //    _appDbContext.SaveChanges();
            //}

            //List<EntryDate> entryDatesCompany = new List<EntryDate>();
            //entryDatesCompany = _appDbContext.EntryDates.Where(x => x.CompanyName == "TEST AGR").ToList();
            //var rasyoAdding = new RasyoModel();
            //var companyRasyo = objRasyo.Where(x => x.Tarih == "2020-01-31").Where(x => x.CompanyName == "Detay");
            //foreach (var item in companyRasyo)
            //{
            //    rasyoAdding.CompanyName = item.CompanyName;
            //    rasyoAdding.Donem = item.Tarih;
            //    rasyoAdding.AktifKarMarji = Convert.ToDecimal(Trimming(item.AktifKarMarji));
            //    rasyoAdding.AktiflerBuyumeOrani = Convert.ToDecimal(Trimming(item.AktiflerBuyumeOrani));
            //    rasyoAdding.AktifToplamiDevirHizi = Convert.ToDecimal(Trimming(item.AktifToplamiDevirHizi));
            //    rasyoAdding.AlacakDevirHizi = Convert.ToDecimal(Trimming(item.AlacakDevirHizi));
            //    rasyoAdding.AlacaklarinOrtalamaTahsilSuresi = Convert.ToDecimal(Trimming(item.AlacaklarinOrtalamaTahsilSuresi));
            //    rasyoAdding.AlacakTahsilSuresi = Convert.ToDecimal(Trimming(item.AlacakTahsilSuresi));
            //    rasyoAdding.BorclanmaKatsayisi = Convert.ToDecimal(Trimming(item.BorclanmaKatsayisi));
            //    rasyoAdding.BorcOdemeSuresi = Convert.ToDecimal(Trimming(item.BorcOdemeSuresi));
            //    rasyoAdding.BorcYapisiOrani = Convert.ToDecimal(Trimming(item.BorcYapisiOrani));
            //    rasyoAdding.BrutFinansalBorc = Convert.ToDecimal(Trimming(item.BrutFinanasalBorc));
            //    //rasyoAdding.BrutFinansalBorc_FAVOK = Convert.ToDecimal(item.);
            //    rasyoAdding.BrutKarMarji = Convert.ToDecimal(Trimming(item.BrutKarMarji));
            //    rasyoAdding.CariOran = Convert.ToDecimal(Trimming(item.CariOran));
            //    rasyoAdding.DevamliSermaye = Convert.ToDecimal(Trimming(item.DevamliSermaye));
            //    rasyoAdding.DevamliSermayeBuyumeOrani = Convert.ToDecimal(Trimming(item.DevamliSermayeBuyumeOrani));
            //    rasyoAdding.DevamliSermayeDevirHizi = Convert.ToDecimal(Trimming(item.DevamliSermayeDevirHizi));
            //    rasyoAdding.DevamliSermayeKarMarji = Convert.ToDecimal(Trimming(item.DevamliSermayeKarMarji));
            //    rasyoAdding.DonenVarliklarDevirHizi = Convert.ToDecimal(Trimming(item.DonenVarliklarDevirHizi));
            //    rasyoAdding.DurVar_DevSerOr = Convert.ToDecimal(Trimming(item.DurVar_DevSerOr));
            //    rasyoAdding.DurVar_OzSerOr = Convert.ToDecimal(Trimming(item.DurVar_OzSerOr));

            //    rasyoAdding.EsasFaaliyetKarliligi = Convert.ToDecimal(Trimming(item.EsasFaaliyetKarliligi));
            //    rasyoAdding.EtkinlikSuresi = Convert.ToDecimal(Trimming(item.EtkinlikSuresi));
            //    rasyoAdding.FaaliyetKarliligi = Convert.ToDecimal(Trimming(item.FaaliyetKarliligi));
            //    rasyoAdding.FaizveVergiOncesiKar = Convert.ToDecimal(Trimming(item.FaizveVergiOncesiKar));
            //    rasyoAdding.FaizveVergiOncesiKarMarji = Convert.ToDecimal(Trimming(item.FaizveVergiOncesiKarMarji));
            //    rasyoAdding.FAVOK_EBITDA = Convert.ToDecimal(Trimming(item.FAVÖK_EBITDA));
            //    rasyoAdding.FinansalKaldirac = Convert.ToDecimal(Trimming(item.FinansalKaldirac));
            //    rasyoAdding.FinBorc_AktOr = Convert.ToDecimal(Trimming(item.FinBorc_AktOr));
            //    rasyoAdding.FinDurVar_DevSerOr = Convert.ToDecimal(Trimming(item.FinDurVar_DevSerOr));
            //    rasyoAdding.FinDurVar_DurVarOr = Convert.ToDecimal(Trimming(item.FinDurVar_DurVarOr));
            //    rasyoAdding.HisseBasiDefterDegeri = Convert.ToDecimal(Trimming(item.HisseBasiDefterDegeri));
            //    rasyoAdding.InterestCoverageRatio = Convert.ToDecimal(Trimming(item.InterestCoverageRatio));
            //    rasyoAdding.KisaVadeliYabanciKaynaklar_Ozkaynaklar = Convert.ToDecimal(Trimming(item.KisaVadYabKay_Ozk));
            //    rasyoAdding.KisVadBorc_AktOr = Convert.ToDecimal(Trimming(item.KisVadBorc_AktOr));
            //    rasyoAdding.LikAkt_AktOr = Convert.ToDecimal(Trimming(item.LikAkt_AktOr));
            //    rasyoAdding.LikiditeOrani = Convert.ToDecimal(Trimming(item.LikiditeOrani));
            //    rasyoAdding.LikitHizliAktifler = Convert.ToDecimal(Trimming(item.LikitHizliAktifler));
            //    rasyoAdding.MaddiDuranVarliklarDevirHizi = Convert.ToDecimal(Trimming(item.MaddiDuranVarliklarDevirHizi));
            //    rasyoAdding.MadDuranVar_OzSerOr = Convert.ToDecimal(Trimming(item.MadDuranVar_OzSerOr));
            //    rasyoAdding.MadDurVar_DevSerOr = Convert.ToDecimal(Trimming(item.MadDurVar_DevSerOr));
            //    rasyoAdding.NakitCevirmeSuresi = Convert.ToDecimal(Trimming(item.NakitCevirmeSuresi));
            //    rasyoAdding.NakitOrani = Convert.ToDecimal(Trimming(item.NakitOrani));
            //    rasyoAdding.NetFaaliyetKari_NetFaaliyetKari = Convert.ToDecimal(Trimming(item.NetFaaliyetKari_NetFaaliyetKari));
            //    rasyoAdding.NetFinansalBorc_FAVÖK = Convert.ToDecimal(Trimming(item.NetFinansalBorş_FAVOK));
            //    //rasyoAdding.NetFinansalBorc_NFB = Convert.ToDecimal(item.nfb);
            //    rasyoAdding.NetIsletmeSermayesiBuyumeOrani = Convert.ToDecimal(Trimming(item.NetIsletmeSermayesiBuyumeOrani));
            //    rasyoAdding.NetIsletmeSermayesiDevirHizi = Convert.ToDecimal(Trimming(item.NetIsletmeSermayesiDevirHizi));
            //    rasyoAdding.NetIslSer_AO = Convert.ToDecimal(Trimming(item.NetIslSer_AO));
            //    rasyoAdding.NetişletmeSermayesi = Convert.ToDecimal(Trimming(item.NetisletmeSermayesi));
            //    rasyoAdding.NetKarBuyumeOrani = Convert.ToDecimal(Trimming(item.NetKarBuyumeOrani));
            //    rasyoAdding.NetKarMarji = Convert.ToDecimal(Trimming(item.NetKarMarji));
            //    //rasyoAdding.NetKarMarji_EBITDAmarji = Convert.ToDecimal(item.netk);
            //    rasyoAdding.NetSatislarBuyumeOrani = Convert.ToDecimal(Trimming(item.NetSatislarBuyumeOrani));
            //    rasyoAdding.NetSatislar_NetSatislar = Convert.ToDecimal(Trimming(item.NetSatislar_NetSatislar));
            //    rasyoAdding.NetYabanciParaPozisyonu = Convert.ToDecimal(Trimming(item.NetYabanciParaPozisyonu));

            //    rasyoAdding.OzKaynaklar_AktiflerToplami = Convert.ToDecimal(Trimming(item.Ozkaynak_AktTop));
            //    rasyoAdding.Ozkaynak_Ozkaynak = Convert.ToDecimal(Trimming(item.Ozkaynak_Ozkaynak));

            //    rasyoAdding.OzSerKarMar = Convert.ToDecimal(Trimming(item.OzSermayeKarMarji));
            //    rasyoAdding.OzSermayeBuyumeOrani = Convert.ToDecimal(Trimming(item.OzSermayeBuyumeOrani));
            //    rasyoAdding.OzSermayeCarpani = Convert.ToDecimal(Trimming(item.OzSermayeCarpani));
            //    rasyoAdding.OzSermayeDevirHizi = Convert.ToDecimal(Trimming(item.OzSermayeDevirHizi));

            //    rasyoAdding.SatislarınIcerisindekiIhracatPayi = Convert.ToDecimal(Trimming(item.Satıslarinİcerisindekiİhracat));
            //    rasyoAdding.SermayeDevirHizi = Convert.ToDecimal(Trimming(item.SermayeDevirHizi));
            //    rasyoAdding.Ser_OzSerOr = Convert.ToDecimal(Trimming(item.Ser_OzSerOr));
            //    rasyoAdding.StokDevirHizi = Convert.ToDecimal(Trimming(item.StokDevirHizi));
            //    rasyoAdding.StokDevirSuresi = Convert.ToDecimal(Trimming(item.StokDevirSuresi));
            //    rasyoAdding.StoklarinOrtalamaTuketilmeSuresi = Convert.ToDecimal(Trimming(item.StoklarinOrtalamaTuketilmeSuresi));
            //    rasyoAdding.TaahhutFaaliyetlerindenGeciciKarZarar = Convert.ToDecimal(Trimming(item.TaahhutFaaliyetlerindenGeciciKar));
            //    rasyoAdding.TicariBorclarDevirHizi = Convert.ToDecimal(Trimming(item.TicariBorclarDevirHizi));
            //    rasyoAdding.TicariBorclariOdemeSuresi = Convert.ToDecimal(Trimming(item.TicariBorclariOdemeSuresi));
            //    rasyoAdding.ToplamVarliklar = Convert.ToDecimal(Trimming(item.ToplamVarliklar));
            //    rasyoAdding.UzvadBorc_DevSerOr = Convert.ToDecimal(Trimming(item.UzvadBorc_DevSerOr));
            //    rasyoAdding.UzVadBor_AktOr = Convert.ToDecimal(Trimming(item.UzVadBor_AktOr));
            //    rasyoAdding.VergiDonemKariOrani = Convert.ToDecimal(Trimming(item.Vergi_DonemKariOrani));
            //    //rasyoAdding.Vergi_VOKMarji = Convert.ToDecimal(item.ver);
            //    _appDbContext.RasyoModels.Add(rasyoAdding);
            //    _appDbContext.SaveChanges();
            //}





            var model = new Rule();
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Settings(Rule model)
        {
            var user = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User));
            var ruleName = _appDbContext.RuleNames.Where(x => x.Rule == model.RuleName).Select(x=>x.ruleName).FirstOrDefault();
            var newRule = new Rule();
            newRule.RuleName = ruleName;
            newRule.RulePropery = model.RuleName;
            newRule.CompanyName = user.CompanyName;
            newRule.IsMailSent = false;
            newRule.MainCompanyCode = user.MainCompanyCode;
            newRule.Operant = model.Operant;
            newRule.RefrenceValue = model.RefrenceValue;
            await _appDbContext.Rules.AddAsync(newRule);
            await _appDbContext.SaveChangesAsync();

            var RuleCheckList = _appDbContext.Rules.Where(x => x.MainCompanyCode == user.MainCompanyCode).ToList();
            ViewBag.RuleCheckList = RuleCheckList;

            var companyEntryDates = GetCompanyEnrtyDates();

            foreach (var item in RuleCheckList)
            {
                for (int i = 0; i < companyEntryDates.Count; i++)
                {
                    RuleCheck(item.RefrenceValue, item.RulePropery, companyEntryDates[i].CompanyName, companyEntryDates[i].DateEntry.ToString("yyyy-MM-dd"), item.Id, item.Operant, user.CompanyName, item.RuleName);
                }
            }

            var ProblemCompanyList = _appDbContext.ruleProblemCompanies.Where(x => x.RegisterCompany == user.CompanyName).Where(x => x.IsActive == true).ToList();
            ViewBag.ProblemCompanyList = ProblemCompanyList;
            var MailingList = new List<string>() { user.Email, user.ExtraEmail1, user.ExtraEmail2, user.ExtraEmail3 };
            // Mailing
            //foreach (var item in ProblemCompanyList)
            //{
            //    for (int i = 0; i < MailingList.Count; i++)
            //    {
            //        Mail.SendMail(MailingList[i].Trim(), item.RuleName, item.ProblemCompanyName);
            //    }
            //    item.IsMailSent = true;
            //    _appDbContext.ruleProblemCompanies.Update(item);
            //    _appDbContext.SaveChanges();
            //}



            var Rule = _appDbContext.RuleNames.ToList();
            var rulelist = Rule.Select(s => new SelectListItem { Text = s.ruleName, Value = s.Rule }).ToList();
            ViewBag.RuleList = rulelist;

            List<string> operantList = new List<string>();
            operantList.Add("Büyüktür");
            operantList.Add("BüyüktürEşittir");
            operantList.Add("Küçüktür");
            operantList.Add("KüçüktürEşittir");
            var OperantList = operantList.Select(s => new SelectListItem { Text = s, Value = s }).ToList();
            ViewBag.OperantList = OperantList;

            var RuleCheckList2 = _appDbContext.Rules.Where(x => x.CompanyName == user.CompanyName).ToList();
            ViewBag.RuleCheckList = RuleCheckList2;

            //var nearEntryDate = _appDbContext.EntryDates.Where(x => x.CompanyName == user.CompanyName).OrderByDescending(x => x.DateEntry).FirstOrDefault();
            //var EntryList = _appDbContext.EntryDates.OrderByDescending(x => x.DateEntry).Select(x => x.CompanyName).Distinct().ToList();
            TempData["message"] = "Başarıyla Eklendi";
            return View();
        }
        [HttpGet]
        public IActionResult Kural()
        {
            var user = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User));
            var ProblemCompanyList = _appDbContext.ruleProblemCompanies.Where(x => x.RegisterCompany == user.CompanyName).ToList();
            ViewBag.ProblemCompanyList = ProblemCompanyList;

            var RuleIdList = _appDbContext.Rules.Where(x=>x.CompanyName == user.CompanyName).Select(x => x.Id).ToList();
            ViewBag.RuleIdList = RuleIdList;

            var RuleNameList = _appDbContext.Rules.Select(x => x.Id).ToList();

            RuleProblemCompany model = new RuleProblemCompany();
            return View(model);
        }
        // girilen kuralları göstermek için if bloğu oluştur ki
        // null kural olduğunda eişk değer, vs gözükebilsin
        [HttpGet]
        public IActionResult Firma()
        {
            var user = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User));
            var ProblemCompanyList = _appDbContext.ruleProblemCompanies.Where(x => x.RegisterCompany == user.CompanyName).ToList();
            ViewBag.ProblemCompanyList = ProblemCompanyList;

            var RuleIdList = _appDbContext.Rules.Where(x=>x.CompanyName == user.CompanyName).Select(x => x.Id).ToList();
            ViewBag.RuleIdList = RuleIdList;

            var companyList = _appDbContext.EntryDates.Select(x => x.CompanyName).Distinct().ToList();
            ViewBag.companyList = companyList;

            RuleProblemCompany model = new RuleProblemCompany();
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int ruleId)
        {
            var ruleToBeDeleted = _appDbContext.Rules.Where(x => x.Id == ruleId).FirstOrDefault();
            _appDbContext.Rules.Remove(ruleToBeDeleted);
            _appDbContext.SaveChanges();

            var problemToBeDeleted = _appDbContext.ruleProblemCompanies.Where(x => x.RuleId == ruleId).ToList();
            if (problemToBeDeleted.Any())
            {
                foreach (var item in problemToBeDeleted)
                {
                    _appDbContext.ruleProblemCompanies.Remove(item);
                    _appDbContext.SaveChanges();
                }
            }

            var Rule = _appDbContext.RuleNames.ToList();
            var rulelist = Rule.Select(s => new SelectListItem { Text = s.ruleName, Value = s.Rule }).ToList();
            ViewBag.RuleList = rulelist;

            List<string> operantList = new List<string>();
            operantList.Add("Büyüktür");
            operantList.Add("BüyüktürEşittir");
            operantList.Add("Küçüktür");
            operantList.Add("KüçüktürEşittir");
            var OperantList = operantList.Select(s => new SelectListItem { Text = s, Value = s }).ToList();
            ViewBag.OperantList = OperantList;

            var user = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User));

            var RuleCheckList = _appDbContext.Rules.Where(x => x.CompanyName == user.CompanyName).ToList();
            ViewBag.RuleCheckList = RuleCheckList;

            var ProblemCompanyList = _appDbContext.ruleProblemCompanies.Where(x => x.RegisterCompany == user.CompanyName).Where(x => x.IsActive == true).ToList();
            ViewBag.ProblemCompanyList = ProblemCompanyList;

            TempData["message"] = "Başarıyla Silindi!";
            return RedirectToAction("Settings","Rule");
        }
        public string Trimming(string a)
        {
            char[] charsToTrim = {'₺','-'};
            return a.Trim(charsToTrim);
        }
        public List<EntryDate> GetCompanyEnrtyDates()
        {
            List<EntryDate> CompanyEntryDates = new List<EntryDate>();
            List<string> CompanyList = _appDbContext.EntryDates.Select(x => x.CompanyName).Distinct().ToList();
            foreach (var item in CompanyList)
            {
                EntryDate CompanyMaxEntryDate = _appDbContext.EntryDates.Where(x => x.CompanyName == item).OrderByDescending(x => x.DateEntry).FirstOrDefault();
                CompanyEntryDates.Add(CompanyMaxEntryDate);
            }
            return CompanyEntryDates;
        }
        public List<RasyoModel> GetCompanyRasyoList()
        {
            var CompanyEntryDates = GetCompanyEnrtyDates();
            List<RasyoModel> RasyoCompanyEntrydates = new List<RasyoModel>();
            foreach (var item in CompanyEntryDates)
            {
                RasyoModel rasyo = _appDbContext.RasyoModels.Where(x => x.CompanyName == item.CompanyName).Where(x => x.Donem == item.DateEntry.ToString("yyyy-MM-dd")).FirstOrDefault();
                RasyoCompanyEntrydates.Add(rasyo);
            }
            return RasyoCompanyEntrydates;
        }
        public void RuleCheck(decimal cons, string rasyoProperty, string CompanyName, string donem, int ruleId, string operant, string registerCompany, string ruleName)
        { 
            if (!_appDbContext.ruleProblemCompanies.Where(x => x.RuleId == ruleId).Where(x => x.ProblemCompanyName == CompanyName).Where(x => x.Donem == donem).Any())
            {
                ParameterExpression parameterExpression = Expression.Parameter(Type.GetType(typeof(RasyoModel).ToString()), "RasyoModel");
                ConstantExpression constant = Expression.Constant(cons);
                MemberExpression property = Expression.Property(parameterExpression, $"{rasyoProperty}");

                if (operant == "Büyüktür")
                {
                    BinaryExpression expression = Expression.GreaterThan(property, constant);
                    var whereLambda = Expression.Lambda<Func<RasyoModel, bool>>(expression, parameterExpression);
                    var selectLambda = Expression.Lambda<Func<RasyoModel, decimal>>(property, parameterExpression);
                    Decimal result = _appDbContext.RasyoModels.Where(x => x.CompanyName == $"{CompanyName}").Where(x => x.Donem == $"{donem}").Where(whereLambda).Select(selectLambda).FirstOrDefault();
                    if (result != 0)
                    {
                        RuleProblemCompany ruleProblem = new RuleProblemCompany() { RuleId = ruleId, ProblemCompanyName = CompanyName, Donem = donem, RuleProperty = rasyoProperty, Value = result.ToString(), IsActive = true, referanceValue = cons.ToString(), Operant = operant, RegisterCompany = registerCompany, RuleName = ruleName };
                        _appDbContext.ruleProblemCompanies.Add(ruleProblem);
                        _appDbContext.SaveChanges();
                        var companyEntryDates = GetCompanyEnrtyDates();
                        var entryDate = companyEntryDates.Where(x => x.CompanyName == CompanyName).Where(x => x.DateEntry.ToString("yyyy-MM-dd") == donem).Select(x => x.DateEntry.ToString("yyyy-MM-dd")).Any();
                        if (!entryDate)
                        {
                            var ruleToBeUpdate = _appDbContext.ruleProblemCompanies.Where(x => x.ProblemCompanyName == $"{CompanyName}").Where(x => x.RuleId == ruleId).FirstOrDefault();
                            ruleToBeUpdate.IsActive = false;
                            _appDbContext.ruleProblemCompanies.Update(ruleToBeUpdate);
                            _appDbContext.SaveChanges();
                        }
                    }
                }
                else if (operant == "BüyüktürEşittir")
                {
                    BinaryExpression expression = Expression.GreaterThanOrEqual(property, constant);
                    var whereLambda = Expression.Lambda<Func<RasyoModel, bool>>(expression, parameterExpression);
                    var selectLambda = Expression.Lambda<Func<RasyoModel, decimal>>(property, parameterExpression);
                    Decimal result = _appDbContext.RasyoModels.Where(x => x.CompanyName == $"{CompanyName}").Where(x => x.Donem == $"{donem}").Where(whereLambda).Select(selectLambda).FirstOrDefault();
                    if (result != 0)
                    {
                        RuleProblemCompany ruleProblem = new RuleProblemCompany() { RuleId = ruleId, ProblemCompanyName = CompanyName, Donem = donem, RuleProperty = rasyoProperty, Value = result.ToString(), IsActive = true, referanceValue = cons.ToString(),Operant= operant, RegisterCompany = registerCompany, RuleName = ruleName };
                        _appDbContext.ruleProblemCompanies.Add(ruleProblem);
                        _appDbContext.SaveChanges();
                        var companyEntryDates = GetCompanyEnrtyDates();
                        var entryDate = companyEntryDates.Where(x => x.CompanyName == CompanyName).Where(x => x.DateEntry.ToString("yyyy-MM-dd") == donem).Select(x => x.DateEntry.ToString("yyyy-MM-dd")).Any();
                        if (!entryDate)
                        {
                            var ruleToBeUpdate = _appDbContext.ruleProblemCompanies.Where(x => x.ProblemCompanyName == $"{CompanyName}").Where(x => x.RuleId == ruleId).FirstOrDefault();
                            ruleToBeUpdate.IsActive = false;
                            _appDbContext.ruleProblemCompanies.Update(ruleToBeUpdate);
                            _appDbContext.SaveChanges();
                        }
                    }
                }
                else if (operant == "Küçüktür")
                {
                    BinaryExpression expression = Expression.LessThan(property, constant);
                    var whereLambda = Expression.Lambda<Func<RasyoModel, bool>>(expression, parameterExpression);
                    var selectLambda = Expression.Lambda<Func<RasyoModel, decimal>>(property, parameterExpression);
                    Decimal result = _appDbContext.RasyoModels.Where(x => x.CompanyName == $"{CompanyName}").Where(x => x.Donem == $"{donem}").Where(whereLambda).Select(selectLambda).FirstOrDefault();
                    if (result != 0)
                    {
                        RuleProblemCompany ruleProblem = new RuleProblemCompany() { RuleId = ruleId, ProblemCompanyName = CompanyName, Donem = donem, RuleProperty = rasyoProperty, Value = result.ToString(), IsActive = true, referanceValue = cons.ToString(), Operant = operant, RegisterCompany = registerCompany, RuleName = ruleName };
                        _appDbContext.ruleProblemCompanies.Add(ruleProblem);
                        _appDbContext.SaveChanges();
                        var companyEntryDates = GetCompanyEnrtyDates();
                        var entryDate = companyEntryDates.Where(x => x.CompanyName == CompanyName).Where(x => x.DateEntry.ToString("yyyy-MM-dd") == donem).Select(x => x.DateEntry.ToString("yyyy-MM-dd")).Any();
                        if (!entryDate)
                        {
                            var ruleToBeUpdate = _appDbContext.ruleProblemCompanies.Where(x => x.ProblemCompanyName == $"{CompanyName}").Where(x => x.RuleId == ruleId).FirstOrDefault();
                            ruleToBeUpdate.IsActive = false;
                            _appDbContext.ruleProblemCompanies.Update(ruleToBeUpdate);
                            _appDbContext.SaveChanges();
                        }
                    }
                }
                else if (operant == "KüçüktürEşittir")
                {
                    BinaryExpression expression = Expression.LessThanOrEqual(property, constant);
                    var whereLambda = Expression.Lambda<Func<RasyoModel, bool>>(expression, parameterExpression);
                    var selectLambda = Expression.Lambda<Func<RasyoModel, decimal>>(property, parameterExpression);
                    Decimal result = _appDbContext.RasyoModels.Where(x => x.CompanyName == $"{CompanyName}").Where(x => x.Donem == $"{donem}").Where(whereLambda).Select(selectLambda).FirstOrDefault();
                    if (result != 0)
                    {
                        RuleProblemCompany ruleProblem = new RuleProblemCompany() { RuleId = ruleId, ProblemCompanyName = CompanyName, Donem = donem, RuleProperty = rasyoProperty, Value = result.ToString(), IsActive = true, referanceValue = cons.ToString(), Operant = operant, RegisterCompany = registerCompany, RuleName = ruleName };
                        _appDbContext.ruleProblemCompanies.Add(ruleProblem);
                        _appDbContext.SaveChanges();
                        var companyEntryDates = GetCompanyEnrtyDates();
                        var entryDate = companyEntryDates.Where(x => x.CompanyName == CompanyName).Where(x => x.DateEntry.ToString("yyyy-MM-dd") == donem).Select(x => x.DateEntry.ToString("yyyy-MM-dd")).Any();
                        if (!entryDate)
                        {
                            var ruleToBeUpdate = _appDbContext.ruleProblemCompanies.Where(x => x.ProblemCompanyName == $"{CompanyName}").Where(x => x.RuleId == ruleId).FirstOrDefault();
                            ruleToBeUpdate.IsActive = false;
                            _appDbContext.ruleProblemCompanies.Update(ruleToBeUpdate);
                            _appDbContext.SaveChanges();
                        }
                    }
                }
            } 
        }
    }
}


