using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PMS.DataLayer.UnitOfWorks;
using PMS.EntityLayer.Concrete;
using PMS.ServiceLayer.Extensions;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace PMS.ServiceLayer.Services.Concrete
{
	public class ProjectService : IProjectService
	{
		private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDocumentService documentService;
        private readonly ClaimsPrincipal _user;

        public ProjectService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor httpContextAccessor,IDocumentService documentService)
		{
			this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.documentService = documentService;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateProjectAsync(ProjectAddDto projectAddDto,Document document)
        {
            var userEmail = _user.GetLoggedInEmail();
           

            var project = new Project
            {
                ProjectName = projectAddDto.ProjectName,
                Description = projectAddDto.Description,
                Budget = projectAddDto.Budget,
                StartDate = projectAddDto.StartDate,
                EndDate = projectAddDto.EndDate,
                Priority = projectAddDto.Priority,
                ProjectManagerId = projectAddDto.ProjectManagerId,
                InsertedBy = userEmail
            };
           

            await unitOfWork.GetRepository<Project>().AddAsync(project);
            await unitOfWork.SaveAsnyc();
            
            if(document.Content != null)
            {
                document.ProjectId = project.Id;
                await documentService.CreateDocumentAsync(document);
                project.Documents.Add(document);
                await unitOfWork.SaveAsnyc();
            }
        }

        public async Task<List<ProjectDto>> GetListProjectsWithNonDeletedAsync()
		{			
            var projects = await unitOfWork.GetRepository<Project>().GetAllWithIncludesAsync(x=>x.Where(x=>x.IsActive == true),x=>x.Include(x=>x.ProjectManager).ThenInclude(x=>x.AppUser));
			var map = mapper.Map<List<ProjectDto>>(projects);

			return map;
		}

        public async Task<ProjectDto> GetProjectWithNonDeletedAsync(Guid projectId)
        {
            var project = await unitOfWork.GetRepository<Project>().GetAsync(x => x.IsActive == true && x.Id == projectId);
            var map = mapper.Map<ProjectDto>(project);


            return map;
        }
        public async Task<ProjectDetailDto> GetProjectWithNonDeletedWithUsersWithTasksAsync(Guid projectId)
        {
            var project = await unitOfWork.GetRepository<Project>().GetWithIncludesAsync(x => x.IsActive == true && x.Id == projectId,
                                                                                         x=>x.Include(x=>x.ProjectAppUsers),
                                                                                         x=>x.Include(x=>x.Tasks));
            var map = mapper.Map<ProjectDetailDto>(project);


            return map;
        }
        public async Task<List<ProjectDto>> GetAllProjectWithUserIdAsync()
        {
            var userId = _user.GetLoggedInUserId();
            var projects = await unitOfWork.GetRepository<Project>().GetAllAsync(x => x.IsActive == true && x.ProjectManager.AppUserId == userId);
            
            var map = mapper.Map<List<ProjectDto>>(projects);


            return map;
        }

        public async Task<string> UpdateProjectAsync(ProjectUpdateDto projectUpdateDto,Document document)
        {
            var userEmail= _user.GetLoggedInEmail();

            var project = await unitOfWork.GetRepository<Project>().GetAsync(x => x.IsActive == true && x.Id == projectUpdateDto.Id);
            projectUpdateDto.UpdateDate = DateTime.Now;
            project.UpdatedBy = userEmail;
            
            if (document.Content != null)
            {
                document.ProjectId = project.Id;
                await documentService.CreateDocumentAsync(document);
                project.Documents.Add(document);
                await unitOfWork.SaveAsnyc();
            }
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

        public async Task<List<ProjectDto>> GetAllDeletedProjectAsync()
        {
            var projects = await unitOfWork.GetRepository<Project>().GetAllAsync(x => x.IsActive == false);
            var map = mapper.Map<List<ProjectDto>>(projects);

            return map;
        }

        public async Task<string> UndoDeleteProjectAsync(Guid projectId)
        {
            var userEmail = _user.GetLoggedInEmail();
            var project = await unitOfWork.GetRepository<Project>().GetByGuidAsync(projectId);

            project.IsActive = true;
            project.DeletedDate = null;
            project.DeletedBy = null;

            await unitOfWork.GetRepository<Project>().UpdateAsnyc(project);
            await unitOfWork.SaveAsnyc();

            return project.ProjectName;
        }
    }
}
