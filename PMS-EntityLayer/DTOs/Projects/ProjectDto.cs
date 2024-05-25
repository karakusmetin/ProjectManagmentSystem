using PMS.EntityLayer.Concrete;
using PMS.EntityLayer.Enums;
using System;

namespace PMS_EntityLayer.DTOs.Projects
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Budget { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertedBy { get; set; }
        public bool IsActive { get; set; }
        public Guid ProjectManagerId { get; set; }
        public ProjectManager ProjectManager { get; set; }

    }
}
