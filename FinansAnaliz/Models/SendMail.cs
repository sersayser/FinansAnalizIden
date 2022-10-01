using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FinansAnaliz.Models
{
    public class SendMail
    {
        public static void SendingMail(string ToMailAddress, string message, string subject)
        {

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.bayianaliz.com";
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            NetworkCredential credential = new NetworkCredential("info@finansmetre.net", "SerSay15963!");
            MailAddress From = new MailAddress("info@finansmetre.net");
            MailAddress To = new MailAddress("serkansaykal@gmail.com");

            MailMessage mail = new MailMessage(From, To);
            mail.Body = $"{message}";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.Subject = $"{subject}";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;
            smtp.Port = 587;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                var error = $"Bir hata oluştu. {ex.Message}";
            }
        }
    }
}
