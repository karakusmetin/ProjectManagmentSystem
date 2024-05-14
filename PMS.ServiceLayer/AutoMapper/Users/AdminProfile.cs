using AutoMapper;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Users;

namespace PMS.ServiceLayer.AutoMapper.Users
{
    public class AdminProfile :Profile
    {
        public AdminProfile()
        {
            CreateMap<UserDto,AppUser>().ReverseMap();
        }
    }
}
