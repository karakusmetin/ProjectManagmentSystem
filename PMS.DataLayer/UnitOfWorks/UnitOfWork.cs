using PMS.DataLayer.Context;
using PMS.DataLayer.Repositories.Abstracts;
using PMS.DataLayer.Repositories.Concretes;
using System.Threading.Tasks;

namespace PMS.DataLayer.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly PMSDbContext dbContext;

		public UnitOfWork(PMSDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async ValueTask DisposeAsync()
		{
			await dbContext.DisposeAsync();
		}

		public int Save()
		{
			return dbContext.SaveChanges();
		}

		public async Task<int> SaveAsnyc()
		{
			return await dbContext.SaveChangesAsync();
		}

		IRepository<T> IUnitOfWork.GetRepository<T>()
		{
			return new Repository<T>(dbContext);
		}
	}
}
