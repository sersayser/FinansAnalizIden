using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models
{
    public class Teminat
    {
      
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Zorunlu alandır. Lütfen firma seçiniz.")]
        public string ToCompanyName { get; set; }
        [Required(ErrorMessage ="Zorunlu alandır. Lütfen kurum seçiniz.")]
        public string Banka { get; set; }
        [Required(ErrorMessage = "Zorunlu alandır. Lütfen teminat numarası giriniz.")]
        public string TeminatNo { get; set; }
        [Required(ErrorMessage = "Zorunlu alandır. Lütfen teminat tutarı giriniz.")]
        public string Tutar { get; set; }
        [Required(ErrorMessage = "Zorunlu alandır. Lütfen teminat bitiş tarihi seçiniz")]
        [DataType(DataType.Date)]
        public string BitisTarihi { get; set; }
        public string MainCompanyCode { get; set; }
        [Required(ErrorMessage = "Zorunlu alandır. Lütfen seçim yapınız.")]
        public bool IsEkTeminat { get; set; }
        public string CompanyName { get; set; }
        public bool ToMainCompany { get; set; } = false;
        public bool IsAlinanTeminat { get; set; }
        public bool IsMailSent { get; set; }



    }
}
