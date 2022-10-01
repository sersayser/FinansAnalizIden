using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models
{
    public static class FintechScore
    {
        public static string Check(int _score)
        {
            int score = _score;
            string note = String.Empty;
            if (score >= 0 && score < 400)
            {
                note = "D";
            }
            else if (score >= 400 && score < 800)
            {
                note = "C-";
            }
            else if (score >= 800 && score < 1200)
            {
                note = "C";
            }
            else if (score >= 1200 && score < 1600)
            {
                note = "C+";
            }
            else if (score >= 1600 && score < 2000)
            {
                note = "B-";
            }
            else if (score >= 2000 && score < 2400)
            {
                note = "B";
            }
            else if (score >= 2400 && score < 2800)
            {
                note = "B+";
            }
            else if (score >= 2800 && score < 3200)
            {
                note = "A-";
            }
            else if (score >= 3200 && score < 3600)
            {
                note = "A";
            }
            else if (score >= 3600 && score <= 4000)
            {
                note = "A+";
            }
            else
            {
                note = String.Empty;
            }
            return note;
        }

        public static string ScoreNotes(int _score)
        {
            int score = _score;
            string note = String.Empty;
            if (score >= 0 && score < 400)
            {
                note = "D";
            }
            else if (score >= 400 && score < 800)
            {
                note = "C-";
            }
            else if (score >= 800 && score < 1200)
            {
                note = "C";
            }
            else if (score >= 1200 && score < 1600)
            {
                note = "Bu nota sahip olan şirketler, borç ödemlerini gerçekleştiremede büyük oranda zorlanacaklardır.";
            }
            else if (score >= 1600 && score < 2000)
            {
                note = "Bu nota sahip olan şirketler, yüksek oranda risk gurubundadır. Ancak anlık olarak geri ödemelerini gerçekleştirebilecek düzeyde görünmektedirler.";
            }
            else if (score >= 2000 && score < 2400)
            {
                note = "Bu nota sahip olan şirketler, finansal belirsizlikler içerisindedir. Bu belirsizlikler, borç ödeme dengelerini etkileyebilecek karakteristiktedir. Ayrıca bu not gurubu spekülatif seviyesinin de başlangıcıdır.";
            }
            else if (score >= 2400 && score < 2800)
            {
                note = "Bu nota sahip olan şirketler, borcunu ödemesinde yeterli kapasiteye sahiptir ancak ortaya çıkabilecek küçük bir olumsuzlukta çok hızlı bir şekilde ve daha fazla etkilenirler. Ayrıca yatırım yapılabilir seviyenin de en alt sınırındadırlar.";
            }
            else if (score >= 2800 && score < 3200)
            {
                note = "A-";
            }
            else if (score >= 3200 && score < 3600)
            {
                note = "Bu nota sahip olan şirketler, en iyi not gurubu ile arasında az bir fark olmasına rağmen finans kuruluşları tarafından yüksek borç geri ödeme kapasitesine sahip olarak kabul edilir.";
            }
            else if (score >= 3600 && score <= 4000)
            {
                note = "Bu nota sahip olan şirketler, finans kuruluşları tarafından borcunun ana parası ve faizini ödemede yüksek borç geri ödeme kapasitesine sahip olarak kabul edilir.";
            }
            else
            {
                note = String.Empty;
            }
            return note;
        }
    }
}
