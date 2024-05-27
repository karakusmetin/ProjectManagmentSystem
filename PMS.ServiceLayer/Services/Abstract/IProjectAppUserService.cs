using PMS_EntityLayer.DTOs.ProjectAppUsers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Abstract
{
    public interface IProjectAppUserService
    {
        List<ProjectAppUserDto> GetAllListProjectAppUserNonDeletedAsync();
        Task<bool> CreateProjectAppUserAsync(ProjectAppUserAddDto projectAppUserAddDto);
        void DeleteProjectAppUser(Guid projectId, Guid appUserId);
    }
}
