using PMS.EntityLayer.Enums;
using System;

namespace PMS_EntityLayer.DTOs.Tasks
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PriorityLevel Priority { get; set; }
        public string InsertedBy { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
