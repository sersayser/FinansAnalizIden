using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.AnalizModel
{
    public class TekliVeriModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string CompanyName { get; set; }
        public string FirmaSkoru { get; set; }
        public string Altman_Z_Uretim { get; set; }
        public string Altman_Z_Hizmet { get; set; }
        public string Dupond_Analizi { get; set; }
        public string EtkinlikCevirmeSuresi { get; set; }
        public string NetIsletmeSermayesi { get; set; }
        public string NakitCevirmeSuresi { get; set; }
    }
}
