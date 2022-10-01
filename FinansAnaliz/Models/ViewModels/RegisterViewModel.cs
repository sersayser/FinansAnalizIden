using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.ViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage ="Ad / Soyad alanı gereklidir.")]
        [Display(Name = "Ad/Soyad")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email alanı gereklidir.")]
        [EmailAddress(ErrorMessage ="Geçerli bir email giriniz.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [StringLength(100, ErrorMessage = "En az 6 karakter olmalıdır", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Şifreyi Onayla")]
        [Compare("Password", ErrorMessage = "Şifreler aynı değil. Kontrol ediniz.")]
        public string ConfirmPass { get; set; }
        
        [Required(ErrorMessage = "Alanı seçilmelidir.")]
        public bool AcceptTerms { get; set; }

        [Required(ErrorMessage = "Firma adını giriniz!")]
        [MinLength(5, ErrorMessage = "En az 5 karakter olmalı")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter olmalı")]
        public string CompanyName { get; set; }

        [Required]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Lütfen sadece rakam kullanınız!")]
        [Range(1, 1000000, ErrorMessage = "Lütfen ana firmanın size sağladığı kodu kullanınız!")]
        public int MainCompanyCode { get; set; } = 4000;
        
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

    }
    
}
