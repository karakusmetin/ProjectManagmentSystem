using AutoMapper;
using PMS.EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Projects;

namespace PMS.ServiceLayer.AutoMapper.Projects
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectDto, Project>().ReverseMap();
            CreateMap<ProjectUpdateDto, Project>().ReverseMap();
            CreateMap<ProjectUpdateDto, ProjectDto>().ReverseMap();
            CreateMap<ProjectAddDto, Project>().ReverseMap();
        }
    }
}
