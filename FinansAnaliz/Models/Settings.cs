using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models
{
    public class Settings
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
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
        
    }
}
