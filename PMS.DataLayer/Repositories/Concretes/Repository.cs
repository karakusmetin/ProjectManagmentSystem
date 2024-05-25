using Microsoft.EntityFrameworkCore;
using PMS.CoreLayer.Entities;
using PMS.DataLayer.Context;
using PMS.DataLayer.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PMS.DataLayer.Repositories.Concretes
{
	public class Repository<T> :IRepository<T> where T : class, IBaseEntityWithId, new()
	{
		private readonly PMSDbContext dbContext;

		public Repository(PMSDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		private DbSet<T> Table { get => dbContext.Set<T>(); }

		public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate = null,params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = Table;
			if(predicate !=null)
				query = query.Where(predicate);


			if (includeProperties.Any())
				foreach(var item in includeProperties)
					query = query.Include(item);
		
			return await query.ToListAsync();
		
		}
		public async Task AddAsync(T entity)
		{
			await Table.AddAsync(entity);
		}

		public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = Table;
			query = query.Where(predicate);

			if (includeProperties.Any())
				foreach (var item in includeProperties)
					query = query.Include(item);

			return await query.SingleAsync();
		}

		public async Task<T> GetByGuidAsync(Guid id)
		{
			return await Table.FindAsync(id);
		}

		public async Task<T> UpdateAsnyc(T entity)
		{
			await Task.Run(() => Table.Update(entity));
			return entity;
		}

		public async Task<T> DeleteAsync(T entity)
		{
			await Task.Run(() => Table.Remove(entity));
			return entity;
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
		{
			return await Table.AnyAsync(predicate);
		}

		public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
		{
			return await Table.CountAsync(predicate);
		}
        public async Task<T> GetWithIncludesAsync(Expression<Func<T, bool>> predicate, params Func<IQueryable<T>, IQueryable<T>>[] includeProperties)
        {
            IQueryable<T> query = Table;

            query = query.Where(predicate);

            foreach (var includeProperty in includeProperties)
            {
                query = includeProperty(query);
            }

            return await query.SingleOrDefaultAsync();
        }

        public async Task<List<T>> GetAllWithIncludesAsync(params Func<IQueryable<T>, IQueryable<T>>[] includeProperties)
        {
            IQueryable<T> query = Table;

            foreach (var includeProperty in includeProperties)
            {
                query = includeProperty(query);
            }

            return await query.ToListAsync();
        }
    }
}
