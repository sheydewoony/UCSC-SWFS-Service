using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCSC.SWFS.SRV.Repositories.Repository;

namespace UCSC.SWFS.SRV.Repositories.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
        void Begin();
        void Commit();
        void Rollback();
        Task<int> SaveChangesAsync(bool ensureAutoHistory = false, bool ignoreReporting = false);
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

    }
}
