
using AutoMapper;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Tasks;

namespace PMS.ServiceLayer.AutoMapper.Taks
{
    public class TaskProfile :Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskDto,Task>().ReverseMap();
            CreateMap<TaskAddDto, Task>().ReverseMap();
            CreateMap<TaskUpdateDto, Task>().ReverseMap();
        }
    }
}
