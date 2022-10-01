using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models
{
    public class Rule
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int MainCompanyCode { get; set; }
        public string RuleName { get; set; }
        public string RulePropery { get; set; }
        public string Operant { get; set; }
        [Required(ErrorMessage = "Zorunlu alandır. Lütfen numerik bir referans değeri giriniz")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RefrenceValue { get; set; }
        public bool IsMailSent { get; set; } = false;

    }
}
