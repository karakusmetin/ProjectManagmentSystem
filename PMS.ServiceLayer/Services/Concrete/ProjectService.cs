using AutoMapper;
using PMS.DataLayer.UnitOfWorks;
using PMS.EntityLayer.Concrete;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.DTOs.Projects;
using System;
using System.Collections.Generic;
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

	}
}
