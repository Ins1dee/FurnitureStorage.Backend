﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStorage.Data.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<int> SaveChangesAsync();

        ValueTask<TEntity> GetByIdAsync(params object[] keys);

        public void Delete(TEntity entity);
    }
}
