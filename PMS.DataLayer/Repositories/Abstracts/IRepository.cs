using PMS.CoreLayer.Entities;
using System;
using System.Collections.Generic;
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
	}
}
