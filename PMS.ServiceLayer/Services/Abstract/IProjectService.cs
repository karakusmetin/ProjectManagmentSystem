﻿using PMS_EntityLayer.Concrete;
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
        Task<List<ProjectDto>> GetAllProjectWithUserIdAsync();       
        Task<ProjectDetailDto> GetProjectWithNonDeletedWithUsersWithTasksAsync(Guid projectId);
        Task<ProjectWithManagerDto> GetProjectWithNonDeletedWithUsersWithTasksWithManagerAsync(Guid projectId);
        Task<Guid> CreateProjectAsync(ProjectAddDto projectAddDto, Document document);
        Task<bool> AnyProjectWithProjectManagerId(Guid projectManagerId);
        Task<bool> AnyProjectUserGuidAsync(Guid userId);
        Task<List<ProjectDto>> GetAllProjectWithManagerIdAsync();
        Task<List<ProjectDto>> GetAllDeletedProjectWithManagerIdAsync();
        Task<ProjectDto> GetProjectWithNonDeletedAsync(Guid projectId);
        Task<List<ProjectDto>> GetAllProjectWithNameAsync(string projectName);
        Task<string> UpdateProjectAsync(ProjectUpdateDto projectUpdateDto, Document document);       
        Task<string> UpdateProjectAsync(ProjectUpdateDto projectUpdateDto);
        Task<string> SafeDeleteProjectAsync(Guid projectId);       
        Task<string> UndoDeleteProjectAsync(Guid projectId);

    }
}
