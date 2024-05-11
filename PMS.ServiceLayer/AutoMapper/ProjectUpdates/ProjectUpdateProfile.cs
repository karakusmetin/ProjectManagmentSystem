using AutoMapper;
using PMS.EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.ProjectUpdate;

namespace PMS.ServiceLayer.AutoMapper.ProjectUpdates
{
    public class ProjectUpdateProfile : Profile
    {
        public ProjectUpdateProfile() 
        { 
            CreateMap<ProjectUpdateDto,ProjectUpdate>().ReverseMap();
        }
    }
}
