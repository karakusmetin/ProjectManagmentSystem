using AutoMapper;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Users;

namespace PMS.ServiceLayer.AutoMapper.Users
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto,AppUser>().ReverseMap();
            CreateMap<UserAddDto,AppUser>().ReverseMap();
            CreateMap<UserUpdateDto,AppUser>().ReverseMap();
            CreateMap<UserProfileDto,AppUser>().ReverseMap();
            CreateMap<UserRegisterDto, AppUser>().ReverseMap();
        }
    }
}
