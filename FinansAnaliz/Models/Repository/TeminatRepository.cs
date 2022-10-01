using FinansAnaliz.Data;
using FinansAnaliz.Models.Interface;
using FinansAnaliz.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.Repository
{
    public class TeminatRepository : GenericRepository<Teminat>, ITeminatRepository
    {
        private readonly AppDbContext _appDbContext;
        public TeminatRepository(AppDbContext appDbContext):base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Teminat> GetAll(bool IsAlinanTeminat)
        {

            return _appDbContext.Teminats.Where(x => x.IsAlinanTeminat == IsAlinanTeminat).ToList();
        }
    }
}
