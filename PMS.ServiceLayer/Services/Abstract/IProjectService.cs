using PMS.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Abstract
{
	public interface IProjectService
	{
		Task<List<Project>> GetListArticleAsync();
	}
}
