using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS.EntityLayer.Enums;
using PMS.ServiceLayer.Services.Abstract;
using PMS.ServiceLayer.Services.Concrete;
using PMS_EntityLayer.DTOs.Tasks;
using System;
using System.Threading.Tasks;

namespace PMS_WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskApiController : ControllerBase
    {
        private readonly ITaskService taskservice;

        public TaskApiController(ITaskService taskservice)
        {
            this.taskservice = taskservice;
        }

        [HttpPost("UpdateTaskStatus")]
        public async Task<IActionResult> UpdateTaskStatus([FromBody] UpdateTaskStatusDto request)
        {  
            if (request == null || request.TaskId == Guid.Empty || !Enum.IsDefined(typeof(TaskUpdateStatus), request.NewStatus))
            {
                var errorDetails = new
                {
                    request = request,
                    message = "Invalid request data",
                    TaskIdValid = request?.TaskId != Guid.Empty,
                    NewStatusValid = Enum.IsDefined(typeof(TaskUpdateStatus), request?.NewStatus)
                };
                return BadRequest(errorDetails);
            }

            var result = await taskservice.UpdateTaskStatusAsync(request);
            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update task status");
            }

            return Ok(new { message = "Task status updated successfully" });
        }

        [HttpGet("get-task-detail")]
        public async Task<IActionResult> GetTaskDetail(Guid taskId)
        {
            var task = await taskservice.GetTaskByGuidAsync(taskId);
            if (task == null)
            {
                return NotFound(new { error = "Task not found" });
            }

            var taskDetailDto = new TaskDto
            {
                TaskName = task.TaskName,
                Priority = task.Priority,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Description = task.Description,
                UpdateStatus = task.UpdateStatus
                
            };

            return Ok(taskDetailDto);
        }

    }
}
