using PMS.EntityLayer.Enums;
using PMS_EntityLayer.DTOs.Users;
using System;
using System.Collections.Generic;

namespace PMS_EntityLayer.DTOs.Tasks
{
    public class TaskUpdateDto
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PriorityLevel Priority { get; set; }
        public TaskUpdateStatus UpdateStatus { get; set; }
        public Guid ProjectId { get; set; }

        public Guid AppUserId { get; set; }

        public IList<UserDto> AppUsers { get; set; }
    }
}
