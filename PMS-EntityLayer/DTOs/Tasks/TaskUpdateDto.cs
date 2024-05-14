
using PMS.EntityLayer.Enums;
using System;

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
    }
}
