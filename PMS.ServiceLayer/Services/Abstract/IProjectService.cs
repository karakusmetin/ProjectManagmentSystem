using PMS_EntityLayer.DTOs.Projects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Abstract
{
	public interface IProjectService
	{
		Task<List<ProjectDto>> GetListProjectsWithNonDeletedAsync();

        Task<List<ProjectDto>> GetAllDeletedProjectAsync();

        Task CreateProjectAsync(ProjectAddDto projectAddDto);

		Task<ProjectDto> GetProjectWithNonDeletedAsync(Guid projectId);

		Task<string> UpdateProjectAsync(ProjectUpdateDto projectUpdateDto);

        Task<string> SafeDeleteProjectAsync(Guid projectId);
        
        Task<string> UndoDeleteProjectAsync(Guid projectId);

    }
}
