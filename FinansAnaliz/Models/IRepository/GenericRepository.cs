using FinansAnaliz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.IRepository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public async Task Create(TEntity entity)
        {
            await _appDbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(int id)
        {
            var deletingEntity = _appDbContext.Set<TEntity>().Find(id);
            _appDbContext.Set<TEntity>().Remove(deletingEntity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return  _appDbContext.Set<TEntity>().ToList();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _appDbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Update(int id, TEntity entity)
        {
            var updatingEntity = await _appDbContext.Set<TEntity>().FindAsync(id);
            _appDbContext.Set<TEntity>().Update(entity);
        }
    }
}
