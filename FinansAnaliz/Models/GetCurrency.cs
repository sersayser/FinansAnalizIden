using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinansAnaliz.Models
{
    
    public class GetCurrency
    {

        public async static Task<CurrencyRate> Rate(IHttpClientFactory httpClientFactory)
        {

            DateTime localDate = DateTime.Now;
            var date = localDate.ToString("dd-MM-yyyy");
            var requestL = new HttpRequestMessage();
            requestL.Method = HttpMethod.Get;
            requestL.RequestUri = new Uri($"https://evds2.tcmb.gov.tr/service/evds/series=TP.DK.USD.A-TP.DK.EUR.A-TP.DK.GBP.A-TP.DK.USD.S-TP.DK.EUR.S-TP.DK.GBP.S&startDate={date}&endDate={date}&type=json&key=Z4jFZClQLD");
            requestL.Headers.Add("Accept", "application/json");
            var clientL = httpClientFactory.CreateClient();
            var responseL = await clientL.SendAsync(requestL);

            var responseStreamL = await responseL.Content.ReadAsStreamAsync();
            StreamReader stream = new StreamReader(responseStreamL);
            string jsonStringL = stream.ReadToEnd();
            var jsonconL = JsonConvert.DeserializeObject<JObject>(jsonStringL);
            var dd = jsonconL.SelectToken("items[0]").Children().ToList();
            CurrencyRate rate = new CurrencyRate();
            if (!String.IsNullOrEmpty(dd[1].First.ToString()))
            {
                rate.Tarih = dd[0].First.ToString();
                rate.TP_DK_USD_A = Math.Round(Convert.ToDouble(dd[1].First), 2);
                rate.TP_DK_EUR_A = Math.Round(Convert.ToDouble(dd[2].First), 2);
                rate.TP_DK_GBP_A = Math.Round(Convert.ToDouble(dd[3].First), 2);
                rate.TP_DK_USD_S = Math.Round(Convert.ToDouble(dd[4].First), 2);
                rate.TP_DK_EUR_S = Math.Round(Convert.ToDouble(dd[5].First), 2);
                rate.TP_DK_GBP_S = Math.Round(Convert.ToDouble(dd[6].First), 2);
            }
           

            return rate;
        }
    }
}
