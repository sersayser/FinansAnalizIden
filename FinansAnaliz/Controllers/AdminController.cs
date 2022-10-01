using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using FinansAnaliz.Models.IRepository;
using FinansAnaliz.Data;
using FinansAnaliz.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;
using static System.Net.WebRequestMethods;
using System.IO;
using Newtonsoft.Json.Linq;
using FinansAnaliz.Models.Identity;
using MongoDB.Bson;

namespace FinansAnaliz.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminController(AppDbContext appDbContext, IHttpClientFactory httpClientFactory)
        {
            _appDbContext = appDbContext;
            _httpClientFactory = httpClientFactory;

        }
        public async Task<IActionResult> Index()
        {

            var currencyRate = await GetCurrency.Rate(_httpClientFactory);
            ViewBag.currencyRate = currencyRate;
            MongoClientSettings settings = MongoClientSettings.FromConnectionString("mongodb+srv://serkansaykal:Serk9143@cluster0.1qmbi.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            settings.LinqProvider = LinqProvider.V3;
            var client = new MongoClient(settings);
            var database = client.GetDatabase("riskMetre");
            var mainCode = _appDbContext.AppUsers.Where(x=>x.UserName == User.Identity.Name).Select(x=>x.MainCompanyCode).FirstOrDefault();

            var companyList = _appDbContext.AppUsers.Where(x => x.MainCompanyCode == mainCode).Select(x => x.CompanyName).ToList();
            var objRasyolist = database.GetCollection<Rasyo>("rasyoAnalizleri").Find(x => companyList.Contains(x.CompanyName)).ToEnumerable();
            var objTekliList = database.GetCollection<TekliVeri>("tekliVeriler").Find(x => companyList.Contains(x.CompanyName)).ToList();
            var entryDates = _appDbContext.EntryDates.Where(x => x.MainCompanyCode == mainCode).GroupBy(x => x.CompanyName).Select(g => new { CompanyName = g.Key, EntryDate = g.Max(x => x.DateEntry) }).ToList();
            var objRasyo = new List<Rasyo>();
            foreach (var rasyo in objRasyolist)
            {
                foreach (var entry in entryDates)
                {
                    
                    if ((entry.CompanyName == rasyo.CompanyName)&&(entry.EntryDate.ToString("yyyy-MM-dd") == rasyo.Tarih))
                    {
                        objRasyo.Add(rasyo);
                    }
                }
            }
            var objTekli = new List<TekliVeri>();
            foreach (var tekli in objTekliList)
            {
                foreach (var entry in entryDates)
                {
                    if ((entry.CompanyName == tekli.CompanyName))
                    {
                        objTekli.Add(tekli);
                    }
                }
            }

            
            ViewBag.Rasyo = objRasyo;
            ViewBag.Tekli = objTekli;
            ViewBag.Firma = companyList;

            return View();

        }
        [HttpGet]
        public IActionResult Detail(string companyName)
        {

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://serkansaykal:Serk9143@cluster0.1qmbi.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("riskMetre");
            var showBooks = _appDbContext.Settings.Where(x => x.CompanyName == companyName).Select(x => x.IsClientShowBook).FirstOrDefault();
            ViewBag.showBooks = showBooks;

            //------------------------------------Rasyolar------------------------------------------
            var objRasyo = database.GetCollection<Rasyo>("rasyoAnalizleri").Find(_ => true).ToList();
            var RasyoFirma = objRasyo.Where(x => x.CompanyName == companyName).ToList();
            ViewBag.Rasyo = RasyoFirma;

            //----------------------------------Rasyolar Sonu---------------------------------------------- 
            //---------------------------------Gelir Tablosu--------------------------------------------
            var objGelir = database.GetCollection<Object>("gelirTablosu").Find(_ => true).ToList();
            var firmaGelir = new List<Dictionary<string, string>>();
            var seriGelir = String.Empty;
            var deseriGelir = new Dictionary<string, string>();
            var firmaGelirSelect = new List<Dictionary<string, string>>();

            for (int i = 0; i < objGelir.Count; i++)
            {
                seriGelir = JsonConvert.SerializeObject(objGelir[i]);
                deseriGelir = JsonConvert.DeserializeObject<Dictionary<string, string>>(seriGelir);
                firmaGelir.Add(deseriGelir);
            }
            var YuklemeTarihList = _appDbContext.EntryDates.Select(x => x.DateEntry).ToList();
            var firmaTarih = _appDbContext.EntryDates.Where(x => x.CompanyName == companyName).Select(x => x.DateEntry).ToList();

            foreach (var item in firmaTarih)
            {
                for (int i = 0; i < firmaGelir.Count; i++)
                {
                    if (firmaGelir[i]["Tarih"] == item.ToString("yyyy-MM-dd") && firmaGelir[i]["Company Name"] == companyName)
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

            ViewBag.gelir = firmaGelirSelect;
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
                    if (firmaAktif[i]["Tarih"] == item.ToString("yyyy-MM-dd") && firmaAktif[i]["Company Name"] == companyName)
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
                    if (firmaPasif[i]["Tarih"] == item.ToString("yyyy-MM-dd") && firmaPasif[i]["Company Name"] == companyName)
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
            ViewBag.aktif = firmaAktifSelect;
            ViewBag.pasif = firmaPasifSelect;



            //-------------------------------------Bilanco Sonu-------------------------------------- -



            return View();

        }
    }
}
