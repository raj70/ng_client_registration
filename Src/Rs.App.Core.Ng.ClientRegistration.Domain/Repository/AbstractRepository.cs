/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* [4.0.30319.42000]
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 6/4/2020 8:02:21 PM
*/
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.ClientRegistration.Repository
{
    public class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        public AbstractRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async virtual Task<T> AddAsync(T model)
        {
            await Set().AddAsync(model);
            return model;
        }

        public async virtual Task DeleteAsync(Guid id)
        {
            var model = await GetAsync(id);
            Set().Remove(model);
        }

        public async virtual Task<T> GetAsync(Guid id)
        {
            var model = await Set().FindAsync(id);
            return model;
        }

        public async virtual Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.Run(() => Set().AsQueryable());
        }

        public async virtual Task<T> UpdateAsync(T model)
        {
            return await Task.Run(() => Set().Update(model).Entity);
        }

        public virtual async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        protected virtual DbSet<T> Set()
        {
            return _dbContext.Set<T>();
        }

        public virtual T Add(T model)
        {
            Set().Add(model);
            return model;
        }

        public virtual T Update(T model)
        {
            return Set().Update(model).Entity;
        }

        public virtual void Delete(Guid id)
        {
            var model = Get(id);
            Set().Remove(model);
        }

        public virtual IQueryable<T> GetAll()
        {
            return Set().AsQueryable();
        }

        public virtual T Get(Guid id)
        {
            return Set().Find(id);
        }

        public virtual void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Set().Where(predicate);
        }

        public virtual async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => Find(predicate));
        }

        public virtual void DeleteRange(IEnumerable<T> models)
        {
            Set().RemoveRange(models);
        }
        public async virtual Task DeleteRangeAsync(IEnumerable<T> models)
        {
            await Task.Run(() => Set().RemoveRange(models));
        }

        public virtual IQueryable<T> GetForPage(int numberPage = 1, int numberOfItems = 10)
        {
            // for first page: 1-1 = 0; 0 * 10 = 0 (no skip); and take ten;
            return Set().Skip((numberPage - 1) * numberOfItems).Take(numberOfItems);
        }

        public virtual async Task<IQueryable<T>> GetForPageAsync(int numberPage = 1, int numberOfItems = 10)
        {
            return await Task.Run(() => GetForPage(numberPage, numberOfItems));
        }
    }
}

