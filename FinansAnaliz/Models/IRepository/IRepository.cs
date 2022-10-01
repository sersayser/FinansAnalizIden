using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Models.IRepository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task Update(int id, TEntity entity);
        void Delete(int id);
    }
}
