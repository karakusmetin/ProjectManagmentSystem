using PMS_EntityLayer.DTOs.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Abstract
{
    public interface ITaskService
    {
        Task<List<TaskDto>> GetAllTasksNonDeleted();
        Task CreateTaskAsync(TaskAddDto taskAddDto);
        Task<TaskUpdateDto> GetTaskByGuid(Guid id);
        Task<string> UpdateTaskAsync(TaskUpdateDto taskUpdateDto);
        Task<string> SafeDeleteTaskAsync(Guid id);
    }
}
