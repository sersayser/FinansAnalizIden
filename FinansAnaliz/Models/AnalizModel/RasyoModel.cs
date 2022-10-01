using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.AnalizModel
{
    public class RasyoModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CompanyName { get; set; }
        public string Donem { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CariOran { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LikiditeOrani { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NakitOrani { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BrutFinansalBorc_FAVOK { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetFinansalBorc_FAVÖK { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal KisaVadeliYabanciKaynaklar_Ozkaynaklar { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OzKaynaklar_AktiflerToplami { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal InterestCoverageRatio { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FinansalKaldirac { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BorclanmaKatsayisi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OzSermayeCarpani { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal KisVadBorc_AktOr { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BorcYapisiOrani { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UzVadBor_AktOr { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal UzvadBorc_DevSerOr { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FinBorc_AktOr { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Ser_OzSerOr { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MadDuranVar_OzSerOr { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DurVar_DevSerOr { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MadDurVar_DevSerOr { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DurVar_OzSerOr { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FinDurVar_DurVarOrani { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FinDurVar_DevSerOr { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AlacakTahsilSuresi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BorcOdemeSuresi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal StokDevirSuresi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AlacakDevirHizi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AlacaklarinOrtalamaTahsilSuresi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal StokDevirHizi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal StoklarinOrtalamaTuketilmeSuresi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal EtkinlikSuresi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TicariBorclarDevirHizi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TicariBorclariOdemeSuresi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NakitCevirmeSuresi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetIsletmeSermayesiDevirHizi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DonenVarliklarDevirHizi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal MaddiDuranVarliklarDevirHizi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AktifToplamiDevirHizi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OzSermayeDevirHizi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DevamliSermayeDevirHizi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SermayeDevirHizi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BrutKarMarji { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetKarMarji { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal EsasFaaliyetKarliligi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FaaliyetKarliligi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FaizveVergiOncesiKarMarji { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Vergi_NetSatisOrani { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal VergiDonemKariOrani { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OzSerKarMar { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        //public decimal Vergi_VOKMarji { get; set; }
        //[Column(TypeName = "decimal(18,2)")]
        public decimal DevamliSermayeKarMarji { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AktifKarMarji { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DevamliSermayeBuyumeOrani { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetKarBuyumeOrani { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetSatislarBuyumeOrani { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetIsletmeSermayesiBuyumeOrani { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AktiflerBuyumeOrani { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OzSermayeBuyumeOrani { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetYabanciParaPozisyonu { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Satıslarinİcerisindekiİhracat { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetisletmeSermayesi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LikitHizliAktifler { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetFinansalBorc_NFB { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BrutFinansalBorc { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FAVÖK_EBITDA { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ToplamVarliklar { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Ozkaynak_Ozkaynak { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetSatislar_NetSatislar { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetFaaliyetKari_NetFaaliyetKari { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DevamliSermaye { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FaizveVergiOncesiKar { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HisseBasiDefterDegeri { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TaahhutFaaliyetlerindenGeciciKarZarar { get; set; } 
        [Column(TypeName = "decimal(18,2)")]
        public decimal EBITDA_Marji { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetIslSer_AO { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LikAkt_AktOr { get; set; }

    }
}
