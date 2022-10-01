using FinansAnaliz.Data;
using FinansAnaliz.Models;
using FinansAnaliz.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FinansAnaliz.Controllers
{
    [Authorize(Roles = "Client")]
    public class MizanYukleController : Controller
    {
        private readonly AppDbContext _appDbContext;
        
        public MizanYukleController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
         }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Yukleme()
        {
            var appuser = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == User.Identity.Name);
            var MizanGonderimListesi = _appDbContext.MizanGonderims.Where(x => x.CompanyName == appuser.CompanyName).ToList();
            ViewBag.MizanGonderimListesi = MizanGonderimListesi;
            return View();
        }
        [HttpPost]
        public IActionResult Yukleme(MizanGonderim mizanYukleme)
        {
            var appuser = _appDbContext.AppUsers.FirstOrDefault(x => x.UserName == User.Identity.Name);
            mizanYukleme.CompanyName = appuser.CompanyName.ToString();
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.bayianaliz.com";
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            NetworkCredential credential = new NetworkCredential("serkan@bayianaliz.com", "SerSay15963!");
            MailAddress From = new MailAddress("serkan@bayianaliz.com");
            MailAddress To = new MailAddress("serkansaykal@gmail.com");

            MailMessage message = new MailMessage(From, To);
            if (mizanYukleme.formFile == null)
            {
                ViewBag.Success = "Hata!";
                ViewBag.Message = $"Dosya seçilmedi! Lütfen mizan dosyası seçiniz!";
                return View();
            }
            else if(mizanYukleme.formFile.Length > 0)
            {
                string filename = Path.GetFileName(mizanYukleme.formFile.FileName);
                message.Attachments.Add(new Attachment(mizanYukleme.formFile.OpenReadStream(), filename));

            }
            message.Body = $"{mizanYukleme.BaslangicTarihi.ToShortDateString()} ile {mizanYukleme.BitisTarihi.ToShortDateString()} dönemi mizan dosyası ";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = $"{mizanYukleme.CompanyName} dan gelen mizan dosyası";
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;
            smtp.Port = 587;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            try
            {
                smtp.Send(message);
                var yeniMizanGonderim = new MizanGonderim();
                yeniMizanGonderim.CompanyName = appuser.CompanyName.ToString();
                yeniMizanGonderim.BaslangicTarihi = mizanYukleme.BaslangicTarihi;
                yeniMizanGonderim.BitisTarihi = mizanYukleme.BitisTarihi;
                yeniMizanGonderim.FilePath = mizanYukleme.formFile.FileName;
                yeniMizanGonderim.GonderimTarihi = DateTime.Now.ToString("yyyy-MM-dd");
                _appDbContext.MizanGonderims.Add(yeniMizanGonderim);
                _appDbContext.SaveChanges();
                var MizanGonderimListesi = _appDbContext.MizanGonderims.Where(x => x.CompanyName == "TEST AGR").ToList().OrderByDescending(x=>x.Id);
                ViewBag.MizanGonderimListesi = MizanGonderimListesi;
                ViewBag.Success = "Tebrikler";
                ViewBag.Message = $"Dosya Başarıyla Gönderildi";
            }
            catch (Exception ex)
            {

                ViewBag.Message = $"Bir hata oluştu. {ex.Message}";
            }



            return View();
        }
    }
}
