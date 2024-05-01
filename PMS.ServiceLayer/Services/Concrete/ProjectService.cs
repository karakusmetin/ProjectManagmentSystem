using AutoMapper;
using PMS.DataLayer.UnitOfWorks;
using PMS.EntityLayer.Concrete;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.DTOs.Projects;
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

		public async Task<List<ProjectDto>> GetListArticleAsync()
		{			
            var projects = await unitOfWork.GetRepository<Project>().GetAllAsync();
			var map = mapper.Map<List<ProjectDto>>(projects);


			return map;
		}
	}
}
