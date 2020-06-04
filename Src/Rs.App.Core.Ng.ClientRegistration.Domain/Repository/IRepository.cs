/** 
* Copyright 2020 rajen shrestha
* All right are reserved. Reproduction or transmission in whole or in
* part, in any form or by any means, electronic, mechanical or otherwise
* is published without the prior written consent of the copyright owner.
* 
* Author: rajen.shrestha 
* Machine: RAJDEVMAC
* Time: 6/4/2020 8:01:27 PM
* 
* [4.0.30319.42000]
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rs.App.Core.ClientRegistration.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T model);
        Task<T> UpdateAsync(T model);
        Task DeleteAsync(Guid id);
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task DeleteRangeAsync(IEnumerable<T> models);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        T Add(T model);
        T Update(T model);
        void Delete(Guid id);
        IQueryable<T> GetAll();
        T Get(Guid id);
        void DeleteRange(IEnumerable<T> models);

        /// <summary>
        /// If required filter on your implemantation,
        /// </summary>
        /// <param name="numberPage"></param>
        /// <param name="numberOfPage"></param>
        /// <returns></returns>
        IQueryable<T> GetForPage(int numberPage = 1, int numberOfPage = 10);
        Task<IQueryable<T>> GetForPageAsync(int numberPage = 1, int numberOfPage = 10);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
