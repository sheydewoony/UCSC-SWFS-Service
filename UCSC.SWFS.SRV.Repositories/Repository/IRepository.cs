using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UCSC.SWFS.SRV.Repositories.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<IEnumerable<TEntity>> InsertBulkAsync(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateBulk(IEnumerable<TEntity> entity);
        void Delete(TEntity entity);
        void DeleteBulk(IEnumerable<TEntity> entities);
    }
}