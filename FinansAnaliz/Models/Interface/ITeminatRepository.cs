using FinansAnaliz.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.Interface
{
    public interface ITeminatRepository : IRepository<Teminat>
    {
        List<Teminat> GetAll(bool IsAlinanTeminat);
    }
}
