using FinansAnaliz.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FinansAnaliz.Services
{
    public static class SendVia
    {
        public static void Mailing(RegisterViewModel model)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.bayianaliz.com";
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            NetworkCredential credential = new NetworkCredential("serkan@bayianaliz.com", "SerSay15963!");
            MailAddress From = new MailAddress("serkan@bayianaliz.com");
            MailAddress To = new MailAddress("serkansaykal@gmail.com");

            MailMessage message = new MailMessage(From, To);

            message.Body = $"{model.Name} kullanıcı doğrulama mailidir. ";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = $"{model.Email} dan gelen kullanıcı doğrulama isteği";
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;
            smtp.Port = 587;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            try
            {
                smtp.Send(message);
                //ViewBag.Success = "Tebrikler";
                //ViewBag.Message = $"Dosya Başarıyla Gönderildi";
            }
            catch (Exception ex)
            {

                //ViewBag.Message = $"Bir hata oluştu. {ex.Message}";
            }
        }
    }
}
