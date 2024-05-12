
using PMS.EntityLayer.Enums;
using System;

namespace PMS_EntityLayer.DTOs.Projects
{
    public class ProjectUpdateDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public float Budget { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime EndDate { get; set; }
        public PriorityLevel Priority { get; set; }
        
    }
}
