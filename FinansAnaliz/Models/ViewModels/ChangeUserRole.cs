using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.ViewModels
{
    public class ChangeUserRole
    {
        public string UserEmail { get; set; }
        public string CurrentRole { get; set; }
        public string NewRole { get; set; }

    }
}
