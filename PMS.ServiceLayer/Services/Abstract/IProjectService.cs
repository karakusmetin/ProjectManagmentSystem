using PMS_EntityLayer.DTOs.Projects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Abstract
{
	public interface IProjectService
	{
		Task<List<ProjectDto>> GetListProjectsWithNonDeletedAsync();

		Task CreateProjectAsync(ProjectAddDto projectAddDto);
	}
}
