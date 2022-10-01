using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.ViewModels
{
    public class ForgotPassViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
