using PMS_EntityLayer.DTOs.Tasks;
using System.Collections.Generic;

namespace PMS_EntityLayer.DTOs.Projects
{
    public class ProjectTaskDto
    {
        public ProjectDto Project { get; set; }
        public IEnumerable<TaskDto> UserTasks { get; set; }
    }
}
