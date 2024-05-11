using PMS.EntityLayer.Enums;
using System;

namespace PMS_EntityLayer.DTOs.Projects
{
    public class ProjectAddDto
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public float Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PriorityLevel Priority { get; set; }
        public Guid ProjectManagerId { get; set; } = Guid.Empty;
    }
}
