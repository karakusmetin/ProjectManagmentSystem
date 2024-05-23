using PMS_EntityLayer.DTOs.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Abstract
{
    public interface ITaskService
    {
        Task<List<TaskDto>> GetAllTasksNonDeletedAsync();
        Task<List<TaskDto>> GetAllTasksDeletedAsync();
        Task CreateTaskAsync(TaskAddDto taskAddDto);
        Task<TaskUpdateDto> GetTaskByGuidAsync(Guid id);
        Task<string> UpdateTaskAsync(TaskUpdateDto taskUpdateDto);
        Task<string> SafeDeleteTaskAsync(Guid id);
        Task<string> UndoDeleteTaskAsync(Guid id);
    }
}
