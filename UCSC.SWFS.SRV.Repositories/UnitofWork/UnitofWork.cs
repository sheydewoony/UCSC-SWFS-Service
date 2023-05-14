using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Repositories;
using UCSC.SWFS.SRV.Utilities.RequestHeader;

namespace UCSC.SWFS.SRV.Repositories.UnitofWork
{
    public class UnitofWork<TContext> :  IUnitofWork where TContext : DbContext
    {
        private readonly TContext _context;
        private Dictionary<Type, object> repositories;
        private readonly IRequestHeader _requestHeader;
        private bool disposed = false;
        public UnitofWork(TContext context, IRequestHeader requestHeader)
        {
            _context = context;
            _requestHeader = requestHeader;
        }

        public void Begin()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // clear repositories
                    if (repositories != null)
                    {
                        repositories.Clear();
                    }

                    // dispose the db context.
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<TEntity>(_context, _requestHeader);
            }

            return (IRepository<TEntity>)repositories[type];
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }

        public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false, bool ignoreReporting = false)
        {
            return await _context.SaveChangesAsync();
        }
    }
}
