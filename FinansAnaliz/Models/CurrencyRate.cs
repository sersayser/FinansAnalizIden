using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FinansAnaliz.Models
{
    public class CurrencyRate
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public int Id { get; set; }
        public string Tarih { get; set; }
        public double TP_DK_USD_A { get; set; }
        public double TP_DK_EUR_A { get; set; }
        public double TP_DK_GBP_A { get; set; }
        public double TP_DK_USD_S { get; set; }
        public double TP_DK_EUR_S { get; set; }
        public double TP_DK_GBP_S { get; set; }

    }

}
