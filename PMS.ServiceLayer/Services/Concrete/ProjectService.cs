using PMS.DataLayer.UnitOfWorks;
using PMS.EntityLayer.Concrete;
using PMS.ServiceLayer.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Concrete
{
	public class ProjectService : IProjectService
	{
		private readonly IUnitOfWork unitOfWork;
		public ProjectService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<List<Project>> GetListArticleAsync()
		{
			return await unitOfWork.GetRepository<Project>().GetAllAsync();
		}
	}
}
