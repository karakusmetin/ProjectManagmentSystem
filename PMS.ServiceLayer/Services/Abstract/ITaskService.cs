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
        Task<bool> GetTaskByUserGuidAsync(Guid userId);
        Task<string> UpdateTaskAsync(TaskUpdateDto taskUpdateDto);
        Task<bool> UpdateTaskStatusAsync(UpdateTaskStatusDto updateTaskStatusDto);
        Task<List<TaskDto>> GetTasksByUserIdAndProjectIdAsync(Guid userId, Guid projectId);
        Task<bool> AnyTasksByUserIdAndProjectIdAsync(Guid userId, Guid projectId);
        Task<string> SafeDeleteTaskAsync(Guid id);
        Task<string> UndoDeleteTaskAsync(Guid id);
    }
}
