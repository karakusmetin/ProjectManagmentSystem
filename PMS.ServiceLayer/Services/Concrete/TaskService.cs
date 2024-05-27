using AutoMapper;
using Microsoft.AspNetCore.Http;
using PMS.DataLayer.UnitOfWorks;
using PMS.EntityLayer.Concrete;
using PMS.ServiceLayer.Extensions;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.DTOs.Tasks;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Concrete
{
    public class TaskService :  ITaskService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly object httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public TaskService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<TaskDto>> GetAllTasksNonDeletedAsync()
        {
            var tasks = await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().GetAllAsync(x=>x.IsActive==true,x=>x.AppUser);
            var map = mapper.Map<List<TaskDto>>(tasks);

            return map;
        }

        public async Task CreateTaskAsync(TaskAddDto taskAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            var task = new PMS_EntityLayer.Concrete.Task
            {
                TaskName = taskAddDto.TaskName,
                Description =taskAddDto.TaskDescription,
                StartDate = taskAddDto.StartDate,
                EndDate = taskAddDto.EndDate,
                Priority = taskAddDto.Priority,
                InsertedBy=userEmail,
                InsertDate=DateTime.Now,
                UserId = taskAddDto.AppUserId,
                ProjectId = taskAddDto.ProjectId

            };
            await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().AddAsync(task);
            await unitOfWork.SaveAsnyc();

        }

        public async Task<TaskUpdateDto> GetTaskByGuidAsync(Guid id)
        {
            var task = await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().GetByGuidAsync(id);
             var map = mapper.Map<TaskUpdateDto>(task);
            return map;
        }

        public async Task<string> UpdateTaskAsync(TaskUpdateDto taskUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            var task = await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().GetAsync(x => x.IsActive == true && x.Id == taskUpdateDto.Id);
            task.UpdateDate = DateTime.Now;
            task.UpdatedBy = userEmail;

            mapper.Map<TaskUpdateDto, PMS_EntityLayer.Concrete.Task>(taskUpdateDto, task);

            await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().UpdateAsnyc(task);
            await unitOfWork.SaveAsnyc();

            return task.TaskName;
        }

        public async Task<string> SafeDeleteTaskAsync(Guid id)
        {
            var userEmail = _user.GetLoggedInEmail();

            var task = await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().GetAsync(x => x.IsActive == true && x.Id == id);
            task.IsActive = false;
            task.UpdateDate = DateTime.Now;
            task.UpdatedBy= userEmail;

            await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().UpdateAsnyc(task);
            await unitOfWork.SaveAsnyc();

            return task.TaskName;
        }

        public async Task<List<TaskDto>> GetAllTasksDeletedAsync()
        {
            var tasks = await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().GetAllAsync(x => x.IsActive == false);
            var map = mapper.Map<List<TaskDto>>(tasks);

            return map;
        }

        public async Task<string> UndoDeleteTaskAsync(Guid id)
        {
            var userEmail = _user.GetLoggedInEmail();

            var task = await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().GetAsync(x => x.IsActive == false && x.Id == id);
            task.IsActive = true;
            task.UpdateDate = null;
            task.UpdatedBy = null;

            await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().UpdateAsnyc(task);
            await unitOfWork.SaveAsnyc();

            return task.TaskName;
        }
    }
}
