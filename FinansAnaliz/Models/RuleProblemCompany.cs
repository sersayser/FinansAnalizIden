using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models
{
    public class RuleProblemCompany
    {
        public int Id { get; set; }
        public int RuleId { get; set; }
        public string RegisterCompany { get; set; }
        public string ProblemCompanyName { get; set; }
        public string Donem { get; set; }
        public string RuleName { get; set; }
        public string RuleProperty { get; set; }
        public string Value { get; set; }
        public string referanceValue { get; set; }
        public string Operant { get; set; }
        public bool IsActive { get; set; }
        public bool IsMailSent { get; set; }

    }
}
