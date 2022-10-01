using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Lütfen kayıtlı email adresinizi giriniz.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; } = false;


    }
}
