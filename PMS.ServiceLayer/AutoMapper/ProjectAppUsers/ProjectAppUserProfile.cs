using AutoMapper;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.ProjectAppUsers;

namespace PMS.ServiceLayer.AutoMapper.ProjectAppUsers
{
    public class ProjectAppUserProfile :Profile
    {
        public ProjectAppUserProfile()
        {
            CreateMap<ProjectAppUser, ProjectAppUserDto>().ReverseMap();
            CreateMap<ProjectAppUser, ProjectAppUserAddDto>().ReverseMap();
        }
    }
}
