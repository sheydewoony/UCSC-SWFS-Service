using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using UCSC.SWFS.SRV.Utilities.RequestHeader;
using System.Reflection;
using UCSC.SWFS.SRV.Utilities.Helpers;

namespace UCSC.SWFS.SRV.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        private readonly IRequestHeader _requestHeader;

        public Repository(DbContext dbContext, IRequestHeader requestHeader)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
            _requestHeader = requestHeader;
        }
        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = await Task.FromResult(_dbSet.AsQueryable());
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            Helper.SetBasePropertiesOnInsert(entity, _requestHeader);
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> InsertBulkAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Helper.SetBasePropertiesOnInsert(entity, _requestHeader);
            }
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public TEntity Update(TEntity entity)
        {
            Helper.SetBasePropertiesOnUpdate(entity, _requestHeader);
            _dbSet.Update(entity);
            return entity;
        }

        public IEnumerable<TEntity> UpdateBulk(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Helper.SetBasePropertiesOnUpdate(entity, _requestHeader);
            }
            _dbSet.UpdateRange(entities);
            return entities;
        }
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public void DeleteBulk(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
