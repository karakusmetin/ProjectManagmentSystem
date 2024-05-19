using AutoMapper;
using Microsoft.AspNetCore.Http;
using PMS.DataLayer.UnitOfWorks;
using PMS.EntityLayer.Concrete;
using PMS.ServiceLayer.Extensions;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.DTOs.Projects;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Concrete
{
	public class ProjectService : IProjectService
	{
		private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public ProjectService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor httpContextAccessor)
		{
			this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateProjectAsync(ProjectAddDto projectAddDto)
        {
            //var userId = Guid.Parse("B175418C-CF5A-4AE9-8DDD-F7629CC555A3");
            
            //var userrId = httpContextAccessor.HttpContext.User.GetLoggedInUserId();

            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var manager = await unitOfWork.GetRepository<ProjectManager>().GetAsync(x=>x.UserId == userId);

            var project = new Project
            {
                ProjectName = projectAddDto.ProjectName,
                Description = projectAddDto.Description,
                Budget = projectAddDto.Budget,
                StartDate = projectAddDto.StartDate,
                EndDate = projectAddDto.EndDate,
                Priority = projectAddDto.Priority,
                ProjectManagerId = manager.Id,
                InsertedBy = userEmail
                
            };

            await unitOfWork.GetRepository<Project>().AddAsync(project);
            await unitOfWork.SaveAsnyc();
        }

        public async Task<List<ProjectDto>> GetListProjectsWithNonDeletedAsync()
		{			
            var projects = await unitOfWork.GetRepository<Project>().GetAllAsync(x=>x.IsActive == true,x=>x.ProjectUpdates);
			var map = mapper.Map<List<ProjectDto>>(projects);


			return map;
		}

        public async Task<ProjectDto> GetProjectWithNonDeletedAsync(Guid projectId)
        {
            var project = await unitOfWork.GetRepository<Project>().GetAsync(x => x.IsActive == true && x.Id == projectId, x => x.ProjectUpdates);
            var map = mapper.Map<ProjectDto>(project);


            return map;
        } 

        public async Task<string> UpdateProjectAsync(ProjectUpdateDto projectUpdateDto)
        {
            var userEmail= _user.GetLoggedInEmail();

            var project = await unitOfWork.GetRepository<Project>().GetAsync(x => x.IsActive == true && x.Id == projectUpdateDto.Id, x => x.ProjectUpdates);
            projectUpdateDto.UpdateDate = DateTime.Now;
            project.UpdatedBy = userEmail;
            
            mapper.Map<ProjectUpdateDto, Project>(projectUpdateDto, project);

            await unitOfWork.GetRepository<Project>().UpdateAsnyc(project);
            await unitOfWork.SaveAsnyc();

            return project.ProjectName;
        }

        public async Task<string> SafeDeleteProjectAsync(Guid projectId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var project = await unitOfWork.GetRepository<Project>().GetByGuidAsync(projectId);

            project.IsActive = false;
            project.DeletedDate = DateTime.Now;
            project.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Project>().UpdateAsnyc(project);
            await unitOfWork.SaveAsnyc();

            return project.ProjectName; 
        }
	}
}
