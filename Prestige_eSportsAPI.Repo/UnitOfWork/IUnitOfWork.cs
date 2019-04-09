using Microsoft.EntityFrameworkCore.Storage;
using Prestige_eSports.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestige_eSports.Repo.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GenericRepository<TEntity>() where TEntity : class;
        IDbContextTransaction BeginTransaction();
        Int64 SaveChanges();
    }
}
