﻿using FurnitureStorage.Data.Context;
using FurnitureStorage.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStorage.Data.Infrastructure
{
    public sealed class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly FurnitureStorageContext context;
        private readonly DbSet<TEntity> dbEntities;

        public Repository(FurnitureStorageContext context)
        {
            this.context = context;
            dbEntities = this.context.Set<TEntity>();
        }
        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = context.Set<TEntity>();
            var query = includes
                .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(dbSet, (current, include) => current.Include(include));

            return query ?? dbSet;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            CheckEntityForNull(entity);

            return (await dbEntities.AddAsync(entity)).Entity;
        }

        public void Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }

        public ValueTask<TEntity> GetByIdAsync(params object[] keys)
        {
            return dbEntities.FindAsync(keys);
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch
            {
                if (context.Database.CurrentTransaction != null)
                {
                    context.Database.CurrentTransaction.Rollback();
                }

                throw;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await Task.Run(() => dbEntities.Update(entity).Entity);
        }

        private static void CheckEntityForNull(TEntity? entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity to add cannot be null.");
            }
        }
    }
}