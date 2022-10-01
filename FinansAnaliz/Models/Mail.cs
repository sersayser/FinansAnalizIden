﻿using FinansAnaliz.Data;
using FinansAnaliz.Models.AnalizModel;
using FinansAnaliz.Models.Interface;
using FinansAnaliz.Models.UoW;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace FinansAnaliz.Models
{
    
    public static class Mail
    {

        public static void SendMail(string ToMailAddress, string RuleName, string CompanyName)
        {
           
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.bayianaliz.com";
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            NetworkCredential credential = new NetworkCredential("serkan@bayianaliz.com", "SerSay15963!");
            MailAddress From = new MailAddress("serkan@bayianaliz.com");
            MailAddress To = new MailAddress("serkansaykal@gmail.com");

            MailMessage message = new MailMessage(From, To);
            message.Body = $"{CompanyName} için girdiğiniz kural için uyarı oluşmuştur. {RuleName} kuralı için eşik referans değeri geçimiştir.";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = $"{CompanyName} Kural Uyarısı";
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;
            smtp.Port = 587;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                var error = $"Bir hata oluştu. {ex.Message}";
            }
        }

    }
}
