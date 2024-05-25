using Microsoft.EntityFrameworkCore;
using PMS.DataLayer.UnitOfWorks;
using PMS.EntityLayer.Concrete;
using PMS.ServiceLayer.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Concrete
{
    public class ProjectManagerService : IProjectManagerService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProjectManagerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<ProjectManager>> GetAllProjectManagersAsync(string email)
        {
            var projectManagers = await unitOfWork.GetRepository<ProjectManager>().GetAllAsync(x=>x.AppUser.Email.Contains(email),x=>x.AppUser);

            return projectManagers;
        }
    }
}
