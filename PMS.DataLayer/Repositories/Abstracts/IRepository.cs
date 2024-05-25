using PMS.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PMS.DataLayer.Repositories.Abstracts
{
	public interface IRepository<T> where T : class,IBaseEntityWithId ,new()
	{
		Task AddAsync(T entity);
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
		Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
		Task<T> GetByGuidAsync(Guid id);
		Task<T> UpdateAsnyc(T entity);
		Task<T> DeleteAsync(T entity);
		Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
		Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetWithIncludesAsync(Expression<Func<T, bool>> predicate, params Func<IQueryable<T>, IQueryable<T>>[] includeProperties);
		Task<List<T>> GetAllWithIncludesAsync(params Func<IQueryable<T>, IQueryable<T>>[] includeProperties);
    }
}
