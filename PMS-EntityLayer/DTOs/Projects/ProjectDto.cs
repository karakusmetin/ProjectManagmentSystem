using PMS.EntityLayer.Enums;
using PMS_EntityLayer.DTOs.ProjectUpdate;
using System;

namespace PMS_EntityLayer.DTOs.Projects
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public ProjectUpdateDto ProjectUpdate { get; set; }
        public string Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
