using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models
{
    public class EntryDate
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateEntry { get; set; }
        public int? MainCompanyCode { get; set; }
    }
}
