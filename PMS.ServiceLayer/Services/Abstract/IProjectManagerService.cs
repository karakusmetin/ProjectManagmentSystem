
using PMS.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Abstract
{
    public interface IProjectManagerService
    {
        Task<List<ProjectManager>> GetAllProjectManagersAsync(string email);
        Task CerateProjectManagerAsync(Guid appUserId);
        Task DeleteProjectManagerAsync(Guid appUserId);
    }
}
