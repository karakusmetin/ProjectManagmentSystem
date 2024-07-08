using PMS_EntityLayer.DTOs.ProjectAppUsers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Abstract
{
    public interface IProjectAppUserService
    {
        bool CheckUserInProjectAsync(Guid projectId, Guid appUserId);
        List<ProjectAppUserDto> GetAllListProjectAppUserNonDeletedAsync();
        Task<bool> CreateProjectAppUserAsync(ProjectAppUserAddDto projectAppUserAddDto);
        Task<bool> CreateProjectAppUserAsync(Guid userId, Guid projectId);
        void DeleteProjectAppUser(Guid projectId, Guid appUserId);
    }
}
