using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Prestige_eSports.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PrestigeContext = Prestige_eSports.Repo.Context.PrestigeContext;

namespace Prestige_eSports.Repo.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly PrestigeContext _context;
        private DbSet<TEntity> _entities;

        /// <summary>
        /// contructor 
        /// </summary>
        /// <param name="context"></param>
        public Repository(PrestigeContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task DeleteAysnc(TEntity entity)
        {
                _entities.Attach(entity);
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
        }

        /// <summary>
        /// returns list of entity based on query params
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _entities;
            foreach (var include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);
            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        /// <summary>
        /// gets all entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll() => _entities.AsEnumerable<TEntity>();

        /// <summary>
        /// get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> GetById(object id) => _entities.Find(id);

        /// <summary>
        /// inserts entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task InsertAysnc(TEntity entity)
        {
                _entities.Add(entity);
                await _context.SaveChangesAsync();
        }

        /// <summary>
        /// updates entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task UpdateAysnc(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _entities;
            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);
            return query.FirstOrDefault(filter);
        }
    }
}