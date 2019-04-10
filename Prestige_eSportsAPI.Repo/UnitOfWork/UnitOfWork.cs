using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Prestige_eSports.Repo.Interfaces;
using Prestige_eSports.Repo.Repositories;
using PrestigeContext = Prestige_eSports.Repo.Context.PrestigeContext;

namespace Prestige_eSports.Repo.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PrestigeContext _context;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private IDbContextTransaction _transaction;

        public UnitOfWork(PrestigeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// creates new transaction with DbContext
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
            return _transaction;
        }

        /// <summary>
        /// creates new instance of IRepo
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public IRepository<TEntity> GenericRepository<TEntity>() where TEntity : class
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IRepository<TEntity>;
            }
            Repository<TEntity> repo = new Repository<TEntity>(_context);
            repositories.Add(typeof(TEntity), repo);
            return repo;
        }

        /// <summary>
        /// saves changes to DbContext
        /// </summary>
        /// <returns></returns>
        public long SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
