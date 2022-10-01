using FinansAnaliz.Data;
using FinansAnaliz.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.UoW
{
    
    public class UoW : BaseRepository, IUoW
    {
        private readonly AppDbContext _appDbContext;
        public UoW(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
