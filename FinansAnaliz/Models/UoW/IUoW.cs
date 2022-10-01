using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.UoW
{
    public interface IUoW
    {
        Task CommitAsync();
        void Commit();
    }
}
