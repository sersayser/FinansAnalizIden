using FinansAnaliz.Data;
using FinansAnaliz.Models;
using FinansAnaliz.Models.Interface;
using FinansAnaliz.Models.UoW;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Controllers
{
    public class CDetailController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITeminatRepository _teminatRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUoW _uoW;
        public CDetailController(AppDbContext appDbContext, ITeminatRepository teminatRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IUoW uoW)
        {
            _appDbContext = appDbContext;
            _teminatRepository = teminatRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _uoW = uoW;

        }
        public IActionResult Index()
        {

            var signedinCompanyName = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == _signInManager.UserManager.GetUserName(User)).CompanyName;
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://serkansaykal:Serk9143@cluster0.1qmbi.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("riskMetre");

            //------------------------ Rasyo Veri ------------------------------------------------

            var objRasyo = database.GetCollection<Rasyo>("rasyoAnalizleri").Find(x => x.CompanyName == signedinCompanyName).ToList();
            
            

            //------------------------Rasyo SONU ------------------------------------------------

            //---------------------------------Gelir Tablosu--------------------------------------------

            var firmaGelir = new List<Dictionary<string, string>>();
            var seriGelir = String.Empty;
            var deseriGelir = new Dictionary<string, string>();
            var firmaGelirSelect = new List<Dictionary<string, string>>();

            var objGelir = database.GetCollection<Object>("gelirTablosu").Find(_ => true).ToList();

            for (int i = 0; i < objGelir.Count; i++)
            {
                seriGelir = JsonConvert.SerializeObject(objGelir[i]);
                deseriGelir = JsonConvert.DeserializeObject<Dictionary<string, string>>(seriGelir);
                firmaGelir.Add(deseriGelir);
            }
            var YuklemeTarihList = _appDbContext.EntryDates.Select(x => x.DateEntry).ToList();
            var firmaTarih = _appDbContext.EntryDates.Where(x => x.CompanyName == signedinCompanyName).Select(x => x.DateEntry).ToList();

            foreach (var item in firmaTarih)
            {
                for (int i = 0; i < firmaGelir.Count; i++)
                {
                    if (firmaGelir[i]["Tarih"] == item.ToString("yyyy-MM-dd") && firmaGelir[i]["Company Name"] == signedinCompanyName)
                    {
                        if (firmaGelir[i]["Type"] == item.ToString("yyyy-MM-dd"))
                        {
                            firmaGelirSelect.Add(firmaGelir[i]);
                        }
                        else if (firmaGelir[i]["Type"] == "Dikey A.")
                        {
                            firmaGelirSelect.Add(firmaGelir[i]);
                        }
                    }
                }
            }

            

            //-----------------------------------Gelir Tablosu Sonu-------------------------------------

            //------------------------------------ Bilanco -------------------------------------------


            var aktifBilanco = database.GetCollection<Object>("aktifBilanço").Find(_ => true).ToList();
            var pasifBilanco = database.GetCollection<Object>("pasifBilanço").Find(_ => true).ToList();

            var firmaAktif = new List<Dictionary<string, string>>();
            var seriAktif = String.Empty;
            var deseriAktif = new Dictionary<string, string>();
            var firmaAktifSelect = new List<Dictionary<string, string>>();

            var firmaPasif = new List<Dictionary<string, string>>();
            var seriPasif = String.Empty;
            var deseriPasif = new Dictionary<string, string>();
            var firmaPasifSelect = new List<Dictionary<string, string>>();


            for (int i = 0; i < aktifBilanco.Count; i++)
            {
                seriAktif = JsonConvert.SerializeObject(aktifBilanco[i]);
                deseriAktif = JsonConvert.DeserializeObject<Dictionary<string, string>>(seriAktif);
                firmaAktif.Add(deseriAktif);
            }
            for (int i = 0; i < pasifBilanco.Count; i++)
            {
                seriPasif = JsonConvert.SerializeObject(pasifBilanco[i]);
                deseriPasif = JsonConvert.DeserializeObject<Dictionary<string, string>>(seriPasif);
                firmaPasif.Add(deseriPasif);
            }


            foreach (var item in firmaTarih)
            {
                for (int i = 0; i < firmaAktif.Count; i++)
                {
                    if (firmaAktif[i]["Tarih"] == item.ToString("yyyy-MM-dd") && firmaAktif[i]["Company Name"] == signedinCompanyName)
                    {
                        if (firmaAktif[i]["Type"] == item.ToString("yyyy-MM-dd"))
                        {
                            firmaAktifSelect.Add(firmaAktif[i]);
                        }
                        else if (firmaAktif[i]["Type"] == "Dikey A.")
                        {
                            firmaAktifSelect.Add(firmaAktif[i]);
                        }
                        else if (firmaAktif[i]["Type"] == "Yatay A.")
                        {
                            firmaAktifSelect.Add(firmaAktif[i]);
                        }
                        else if (firmaAktif[i]["Type"] == "Gurup A.")
                        {
                            firmaAktifSelect.Add(firmaAktif[i]);
                        }
                    }
                }
            }

            foreach (var item in firmaTarih)
            {
                for (int i = 0; i < firmaPasif.Count; i++)
                {
                    if (firmaPasif[i]["Tarih"] == item.ToString("yyyy-MM-dd") && firmaPasif[i]["Company Name"] == signedinCompanyName)
                    {
                        if (firmaPasif[i]["Type"] == item.ToString("yyyy-MM-dd"))
                        {
                            firmaPasifSelect.Add(firmaPasif[i]);
                        }
                        else if (firmaPasif[i]["Type"] == "Dikey A.")
                        {
                            firmaPasifSelect.Add(firmaPasif[i]);
                        }
                        else if (firmaPasif[i]["Type"] == "Yatay A.")
                        {
                            firmaPasifSelect.Add(firmaPasif[i]);
                        }

                    }
                }
            }


            //-------------------------------------Bilanco Sonu-------------------------------------- -


            var entryDates = _appDbContext.EntryDates.Where(x => x.CompanyName == signedinCompanyName).Select(x => x.DateEntry).OrderByDescending(x => x.ToString()).ToList();
            if (entryDates == null || entryDates.Count == 0)
            {
                ViewBag.entryDates = new List<DateTime>() { };
                ViewBag.aktif = 0;
                ViewBag.pasif = 0;
                ViewBag.Rasyo = 0;
                ViewBag.gelir = 0;
            }
            else
            {
                ViewBag.entryDates = entryDates;
                ViewBag.aktif = firmaAktifSelect;
                ViewBag.pasif = firmaPasifSelect;
                ViewBag.Rasyo = objRasyo;
                ViewBag.gelir = firmaGelirSelect;
            }

            return View();
        }
    }
}
