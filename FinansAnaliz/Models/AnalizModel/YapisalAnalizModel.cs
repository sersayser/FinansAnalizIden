using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.AnalizModel
{
    public class YapisalAnalizModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Donem { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DonenVarliklar { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DuranVarliklar { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal KisaVadeliYabanciKaynaklar { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UzunVadeliYabanciKaynaklar { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OzKaynaklar { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OdenmisSermaye { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SermayeYedekleri { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal KarYedekleri { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal GecmisYıllarKarlar { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal GecmisYillarZararlari { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DonemNetKarı_Zarari { get; set; }
    }
}
