using PMS.EntityLayer.Enums;
using PMS_EntityLayer.DTOs.Users;
using System;
using System.Collections.Generic;

namespace PMS_EntityLayer.DTOs.Tasks
{
    public class TaskAddDto
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PriorityLevel Priority { get; set; }

        public Guid AppUserId { get; set; } 
        public Guid ProjectId { get; set; }
        public IList<UserDto> AppUsers { get; set; }

    }
}
