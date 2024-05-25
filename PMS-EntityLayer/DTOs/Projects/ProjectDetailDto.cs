using PMS.EntityLayer.Enums;
using PMS_EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace PMS_EntityLayer.DTOs.Projects
{
    public class ProjectDetailDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Budget { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public IList<AppUser> ProjectMembers { get; set; }
        public IList<Document> Documents { get; set; }
        public IList<Task> Tasks { get; set; }

    }
}
