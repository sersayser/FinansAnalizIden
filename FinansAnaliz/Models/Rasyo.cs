using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models
{
    [BsonIgnoreExtraElements]
    public class Rasyo
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Company Name")]
        public string CompanyName { get; set; }
        [BsonElement("Type")]
        public string Type { get; set; }
        [BsonElement("Tarih")]
        public string Tarih { get; set; }


        [BsonElement("Cari Oran = Dönen Varlıklar / K.V. Borçlar")]
        public string CariOran { get; set; }
        [BsonElement("Asit - Test Oranı (Likidite Oranı) =(Hazır Değerler+Menkul Kıymetler (Net)+Ticari Alacaklar+Mamuller+Ticari Mallar)/Kısa Vadeli Yabancı Kaynaklar)")]
        public string LikiditeOrani { get; set; }
        [BsonElement("Nakit Oranı = ( Hazır Değerler + Menkul Kıymetler ) / K.V. Borçlar")]
        public string NakitOrani { get; set; }
        [BsonElement("Brüt Finansal Borç/FAVÖK")]
        public string BrutFinansalBorc_FAVOK { get; set; }
        [BsonElement("Net Finansal Borç/FAVÖK")]
        public string NetFinansalBorc_FAVÖK { get; set; }
        [BsonElement("Kısa Vadeli Yabancı Kaynaklar/Özkaynaklar")]
        public string KisaVadeliYabanciKaynaklar_Ozkaynaklar { get; set; }
        [BsonElement("Öz Kaynaklar/Aktifler Toplamı")]
        public string OzKaynaklar_AktiflerToplami { get; set; }
        [BsonElement("Interest Coverage Ratio = FAVÖK (EBITDA) / Finansman Giderleri")]
        public string InterestCoverageRatio { get; set; }
        [BsonElement("Finansal Kaldıraç (Borç - Aktifler Oranı) = [( U.V. Borçlar + K.V. Borçlar ) / Toplam Aktifler ] * 100")]
        public string FinansalKaldirac { get; set; }
        [BsonElement("Borçlanma Katsayısı (Borç - Öz Sermaye Oranı) = [( U.V. Borçlar + K.V. Borçlar ) / Öz Sermaye ] * 100")]
        public string BorclanmaKatsayisi { get; set; }
        [BsonElement("Öz Sermaye Çarpanı = ( Toplam Aktifler / Öz Sermaye ) * 100")]
        public string OzSermayeCarpani { get; set; }
        [BsonElement("Kısa Vadeli Borçlar - Aktifler Oranı = ( K.V. Borçlar / Toplam Aktifler ) * 100")]
        public string KisVadBorc_AktOr { get; set; }
        [BsonElement("Borç Yapısı Oranı (K.V. Borçlar - Toplam Borçlar) = [ K.V. Borçlar / ( U.V. Borçlar + K.V. Borçlar )] * 100")]
        public string BorcYapisiOrani { get; set; }
        [BsonElement("Uzun Vadeli Borçlar - Aktifler Oranı = ( U.V. Borçlar / Toplam Aktifler ) * 100")]
        public string UzVadBor_AktOr { get; set; }
        [BsonElement("Uzun Vadeli Borçlar - Devamlı Sermaye Oranı = DURAN VARLIKLAR/(UZUN VADELİ YABANCI KAYNAKLAR+ÖZKAYNAKLAR)")]
        public string UzvadBorc_DevSerOr { get; set; }
        [BsonElement("Finansal Borçlar - Aktifler Oranı = [( U.V. Finansal Borçlar + K.V. Finansal Borçlar ) / Toplam Aktifler ] * 100")]
        public string FinBorc_AktOr { get; set; }
        [BsonElement("Sermaye - Öz Sermaye Oranı = ( Sermaye / Öz Sermaye ) * 100")]
        public string Ser_OzSerOr { get; set; }
        [BsonElement("Maddi Duran Varlıklar - Öz Sermaye Oranı = ( Maddi Duran Varlıklar / Öz Sermaye ) * 100")]
        public string MadDuranVar_OzSerOr { get; set; }
        [BsonElement("Duran Varlıklar - Devamlı Sermaye Oranı = ( Duran Varlıklar / Devamlı Sermaye ) * 100")]
        public string DurVar_DevSerOr { get; set; }
        [BsonElement("Maddi Duran Varlıklar - Devamlı Sermaye Oranı = ( Maddi Duran Varlıklar / Devamlı Sermaye ) * 100")]
        public string MadDurVar_DevSerOr { get; set; }
        [BsonElement("Duran Varlıklar - Öz Sermaye Oranı = ( Duran Varlıklar / Öz Sermaye ) * 100")]
        public string DurVar_OzSerOr { get; set; }
        [BsonElement("Finansal Duran Varlıklar - Duran Varlıklar Oranı = MALİ DURAN VARLIKLAR/DURAN VARLIKLAR")]
        public string FinDurVar_DurVarOrani { get; set; }
        [BsonElement("Finansal Duran Varlıklar - Devamlı Sermaye Oranı = ( Finansal Duran Varlıklar / Devamlı Sermaye ) * 100")]
        public string FinDurVar_DevSerOr { get; set; }
        [BsonElement("Alacak Tahsil Süresi (Gün) = 360/ Alacak Devir hızı")]
        public string AlacakTahsilSuresi { get; set; }
        [BsonElement("Borç Ödeme Süresi (Gün) = 360/Borç Devir hızı")]
        public string BorcOdemeSuresi { get; set; }
        [BsonElement("Stok Devir Süresi (Gün) = 360 /Stok Devir Hızı")]
        public string StokDevirSuresi { get; set; }
        [BsonElement("Alacak Devir Hızı = Net Satışlar / Ticari Alacaklar")]
        public string AlacakDevirHizi { get; set; }
        [BsonElement("Alacakların Ortalama Tahsil Suresi = (360* TİCARİ ALACAKLAR) / Net Satışlar")]
        public string AlacaklarinOrtalamaTahsilSuresi { get; set; }
        [BsonElement("Stok Devir Hızı = Satılan Malın Maliyeti / Stoklar")]
        public string StokDevirHizi { get; set; }
        [BsonElement("Stokların Ortalama Tuketilme Suresi = 365* Stoklar / Satışların maaliyeti")]
        public string StoklarinOrtalamaTuketilmeSuresi { get; set; }
        [BsonElement("Etkinlik Suresi = Alacakların Ort. Tahsil Suresi + Stokların Ort. Tuketilme Suresi")]
        public string EtkinlikSuresi { get; set; }
        [BsonElement("Ticari Borçlar Devir Hızı = Satılan Malın Maliyeti / Ticari Borçlar")]
        public string TicariBorclarDevirHizi { get; set; }
        [BsonElement("Ticari Borçları Ödeme Suresi = ( 365 * Ortalama Ticari Borçlar ) / Satılan Malın Maliyeti")]
        public string TicariBorclariOdemeSuresi { get; set; }
        [BsonElement("Nakit Çevirme Suresi = Etkinlik Suresi - Ticari Borçları Ödeme Suresi")]
        public string NakitCevirmeSuresi { get; set; }
        [BsonElement("Net işletme Sermayesi Devir Hızı = Net Satışlar /(Dönen varlıkar -kısa vadeli YK)")]
        public string NetIsletmeSermayesiDevirHizi { get; set; }
        [BsonElement("Dönen Varlıklar ( Brut işletme Sermayesi ) Devir Hızı = Net Satışlar / Dönen Varlıklar")]
        public string DonenVarliklarDevirHizi { get; set; }
        [BsonElement("Maddi Duran Varlıklar Devir Hızı = Net Satışlar / Maddi Duran Varlıklar")]
        public string MaddiDuranVarliklarDevirHizi { get; set; }
        [BsonElement("Aktif Toplamı Devir Hızı = Net Satışlar / Toplam Aktifler")]
        public string AktifToplamiDevirHizi { get; set; }
        [BsonElement("Öz Sermaye Devir Hızı = Net Satışlar / Öz Sermaye")]
        public string OzSermayeDevirHizi { get; set; }
        [BsonElement("Devamlı Sermaye Devir Hızı = Net Satışlar / Devamlı Sermaye")]
        public string DevamliSermayeDevirHizi { get; set; }
        [BsonElement("Sermaye Devir Hızı = Net Satışlar / Ödenmiş Sermaye")]
        public string SermayeDevirHizi { get; set; }
        [BsonElement("Brut Kar Marjı = ( Brut Satış Karı / Net Satışlar ) * 100")]
        public string BrutKarMarji { get; set; }
        [BsonElement("Net Kar Marjı= Net Kar/Net Satışlar")]
        public string NetKarMarji { get; set; }
        [BsonElement("Esas Faaliyet Karlılığı = ( Faaliyet Karı / Net Satışlar ) * 100")]
        public string EsasFaaliyetKarliligi { get; set; }
        [BsonElement("Faaliyet Karlılığı = ( Olağan Kar / Net Satışlar ) * 100")]
        public string FaaliyetKarliligi { get; set; }
        [BsonElement("Faiz ve Vergi Öncesi Kar Marjı = (Dönem karı zarar+Finansman Giderleri)/Net Satışlar")]
        public string FaizveVergiOncesiKarMarji { get; set; }
        [BsonElement("Vergi - Net Satışlar Oranı = ( Ödenecek Vergi ve Yasal Yukumlulukler / Net Satışlar ) * 100")]
        public string Vergi_NetSatisOrani { get; set; }
        [BsonElement("Vergi - Dönem Karı Oranı = ( Ödenecek Vergi ve Yasal Yukumlulukler / Dönem Karı ) * 100")]
        public string VergiDonemKariOrani { get; set; }
        [BsonElement("Öz Sermaye Kar Marjı = ( Net Kar / Öz Sermaye ) * 100")]
        public string OzSerKarMar { get; set; }
        [BsonElement("Devamlı Sermaye Kar Marjı = ( Net Kar / Devamlı Sermaye ) * 100")]
        public string DevamliSermayeKarMarji { get; set; }
        [BsonElement("Aktif Kar Marjı = ( Net Kar / Toplam Aktifler ) * 100")]
        public string AktifKarMarji { get; set; }
        [BsonElement("Devamlı Sermaye Buyume Oranı = [( Devamlı Sermaye(t) / Devamlı Sermaye(t-1) ) - 1 ] * 100")]
        public string DevamliSermayeBuyumeOrani { get; set; }
        [BsonElement("Net Kar Buyume Oranı = [( Net Dönem Karı(t) / Net Dönem Karı(t-1) ) - 1 ] * 100")]
        public string NetKarBuyumeOrani { get; set; }
        [BsonElement("Net Satışlar Buyume Oranı = [( Net Satışlar(t) / Net Satışlar(t-1) ) - 1 ] * 100")]
        public string NetSatislarBuyumeOrani { get; set; }
        [BsonElement("Net işletme Sermayesi Buyume Oranı = [( Net işletme Sermayesi(t) / Net işletme Sermayesi(t-1) ) - 1 ] * 100")]
        public string NetIsletmeSermayesiBuyumeOrani { get; set; }
        [BsonElement("Aktifler Buyume Oranı = [( Aktif Toplamı(t) / Aktif Toplamı(t-1) ) - 1 ] * 100")]
        public string AktiflerBuyumeOrani { get; set; }
        [BsonElement("Öz Sermaye Buyume Oranı = [( Öz Sermaye(t) / Öz Sermaye(t-1) ) - 1 ] * 100")]
        public string OzSermayeBuyumeOrani { get; set; }
        [BsonElement("Net Yabancı Para Pozisyonu = Kambiyo Karları-Kambiyo Zararları")]
        public string NetYabanciParaPozisyonu { get; set; }
        [BsonElement("Satışların İçerisindeki İhracat Payı = Yurtdışı Satışlar / Net Satışlar")]
        public string Satıslarinİcerisindekiİhracat { get; set; }
        [BsonElement("Net işletme Sermayesi = Dönen Varlıklar - K.V. Borçlar")]
        public string NetisletmeSermayesi { get; set; }
        [BsonElement("Likit Hızlı Aktifler = Dönen Varlıklar - Stoklar - Diğer Dönen Varlıklar")]
        public string LikitHizliAktifler { get; set; }
        [BsonElement("Net Finansal Borç (NFB)= ((-1)*(Hazır Değerler+Menkul Kıymetler)+(U.V Mali Borçlar + K.V Mali Borçlar))")]
        public string NetFinansalBorc_NFB { get; set; }
        [BsonElement("Brüt Finansal Borç = U.V Mali Borçlar + K.V Mali Borçlar")]
        public string BrutFinansalBorc { get; set; }
        [BsonElement("FAVÖK (EBITDA) = Faaliyet Karı veya Zararı + (Birikmiş Amortismanlar(-) Önceki Yıl - Cari Yıl Birikmiş Amortismanlar(-) )")]
        public string FAVÖK_EBITDA { get; set; }
        [BsonElement("Toplam Varlıklar = Aktifler Toplamı")]
        public string ToplamVarliklar { get; set; }
        [BsonElement("Özkaynak = Özkaynak")]
        public string Ozkaynak_Ozkaynak { get; set; }
        [BsonElement("Net Satislar = Net Satislar")]
        public string NetSatislar_NetSatislar { get; set; }
        [BsonElement("Net Faaliyet Karı = Net Faaliyet Karı")]
        public string NetFaaliyetKari_NetFaaliyetKari { get; set; }
        [BsonElement("Devamlı Sermaye = Uzun Vadeli Borçlar + Öz Sermaye")]
        public string DevamliSermaye { get; set; }
        [BsonElement("Faiz ve Vergi Öncesi Kar = Dönem Karı + Finansman Giderleri")]
        public string FaizveVergiOncesiKar { get; set; }
        [BsonElement("Hisse Başı Defter Değeri = Öz Sermaye / Ödenmiş Sermaye")]
        public string HisseBasiDefterDegeri { get; set; }
        [BsonElement("Taahhüt Faaliyetlerinden Geçici Kar/Zarar = Yıllara Yaygın İnşaat ve Onarım Hakedişleri - Yıllara Yaygın İnşaat ve Onarım Maaliyetleri")]
        public string TaahhutFaaliyetlerindenGeciciKarZarar { get; set; }
        [BsonElement("Net Kar Marjı = EBITDA marjı= EBITDA/Net satışlar")]
        public string EBITDA_Marji { get; set; }
        [BsonElement("Net işletme Sermayesi - Aktifler Oranı = ( Net işletme Sermayesi /Toplam Aktifler ) * 100")]
        public string NetIslSer_AO { get; set; }
        [BsonElement("Likit Aktifler - Aktifler Oranı = (Dönen varlıklar-Diğer dönen varlıklar-Stoklar) / Aktifler toplamı")]
        public string LikAkt_AktOr { get; set; }


    }
}
