using PMS.EntityLayer.Enums;
using System;

namespace PMS_EntityLayer.DTOs.Tasks
{
    public class TaskAddDto
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PriorityLevel Priority { get; set; }

    }
}
