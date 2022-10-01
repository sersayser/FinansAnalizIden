using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models
{
    [BsonIgnoreExtraElements]
    public class TekliVeri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("Company Name")]
        public string CompanyName { get; set; }



        [BsonElement("RiskMetre Puanı")]
        public string FirmaSkoru { get; set; }


        [BsonElement("ALTMAN-Z Üretim")]
        public string Altman_Z_Uretim { get; set; }


        [BsonElement("ALTMAN-Z Hizmet")]
        public string Altman_Z_Hizmet { get; set; }


        [BsonElement("DUPONT ANALİZİ")]
        public string Dupond_Analizi { get; set; }


        [BsonElement("Etkinlik Süresi")]
        public string EtkinlikCevirmeSuresi { get; set; }


        [BsonElement("Nakit Çevirme Süresi")]
        public string NakitCevirmeSuresi { get; set; }
        

        [BsonElement("Net işletme Sermayesi")]
        public string NetIsletmeSermayesi { get; set; }
    }
}
