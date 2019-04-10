using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Prestige_eSports.Repo.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity> GetById(object id);
        List<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> InsertAysnc(TEntity entity);
        Task<TEntity> UpdateAysnc(TEntity entity);
        Task<TEntity> DeleteAysnc(TEntity entity);
    }
}
