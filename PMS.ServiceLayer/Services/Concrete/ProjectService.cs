using AutoMapper;
using PMS.DataLayer.UnitOfWorks;
using PMS.EntityLayer.Concrete;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.DTOs.Projects;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Concrete
{
	public class ProjectService : IProjectService
	{
		private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProjectService(IUnitOfWork unitOfWork,IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateProjectAsync(ProjectAddDto projectAddDto)
        {
            var userId = Guid.Parse("B175418C-CF5A-4AE9-8DDD-F7629CC555A3");


            var project = new Project
            {
                ProjectName = projectAddDto.ProjectName,
                Description = projectAddDto.Description,
                Budget = projectAddDto.Budget,
                StartDate = projectAddDto.StartDate,
                EndDate = projectAddDto.EndDate,
                Priority = projectAddDto.Priority,
                ProjectManagerId = userId,
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

        public async Task UpdateProjectAsync(ProjectUpdateDto projectUpdateDto)
        {
            var project = await unitOfWork.GetRepository<Project>().GetAsync(x => x.IsActive == true && x.Id == projectUpdateDto.Id, x => x.ProjectUpdates);
            projectUpdateDto.UpdateDate = DateTime.Now;
            mapper.Map<ProjectUpdateDto, Project>(projectUpdateDto, project);

            await unitOfWork.GetRepository<Project>().UpdateAsnyc(project);
            await unitOfWork.SaveAsnyc();
        }

	}
}
