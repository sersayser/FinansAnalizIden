using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.Identity
{
    public class AppUser:IdentityUser
    {
        [Required]
        public string NameOfUser { get; set; }
        [Required(ErrorMessage = "Firma adını giriniz!")]
        [MinLength(5, ErrorMessage = "En az 5 karakter olmalı")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter olmalı")]
        public string CompanyName { get; set; }
        [Required]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Lütfen sadece rakam kullanınız!")]
        [Range(1, 1000000, ErrorMessage = "Lütfen ana firmanın size sağladığı kodu kullanınız!")]
        public int MainCompanyCode { get; set; }
        public bool IsClient { get; set; }
        public bool IsAlertTeminatEnds { get; set; } = false;
        [Required(ErrorMessage = "Lütfen 90 güne kadar bir rakam giriniz!")]
        [Range(1, 90, ErrorMessage = "0 ile 90 gün arası sayı giriniz!")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Lütfen sadece rakam kullanınız!")]
        public int? AlertTeminatRemainingDay { get; set; } = 15;
        public bool IsAlertRuleWarning { get; set; } = false;
        public string ExtraEmail1 { get; set; } = String.Empty;
        public string ExtraEmail2 { get; set; } = String.Empty;
        public string ExtraEmail3 { get; set; } = String.Empty;
        public bool IsClientShowBook { get; set; } = false;
        [Required(ErrorMessage = "Alanı seçilmelidir.")]
        public bool AcceptTerms { get; set; } = true;
    }
}
