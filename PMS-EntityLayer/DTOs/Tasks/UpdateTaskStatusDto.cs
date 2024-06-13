using PMS.EntityLayer.Enums;
using System;

namespace PMS_EntityLayer.DTOs.Tasks
{
    public class UpdateTaskStatusDto
    {
        public Guid TaskId { get; set; }
        public string NewStatus { get; set; }
    }
}
