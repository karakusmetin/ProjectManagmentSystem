using PMS.CoreLayer.Entities;
using PMS.DataLayer.Repositories.Abstracts;
using System;
using System.Threading.Tasks;

namespace PMS.DataLayer.UnitOfWorks
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		IRepository<T> GetRepository<T>() where T : class,IBaseEntityWithId,new();
		Task<int> SaveAsnyc();
		int Save();
	}
}
