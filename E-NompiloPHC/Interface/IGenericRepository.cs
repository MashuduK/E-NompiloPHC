using System.Linq.Expressions;
using System;
using E_NompiloPHC.Models;

namespace E_NompiloPHC.Interface
{
    public interface IGenericRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        void Add(T entity);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        Task<T> UpdateAsync(T entity);
        void Delete(T entity);
        Task<T> DeleteAsync(T entity);
        
    }
}
