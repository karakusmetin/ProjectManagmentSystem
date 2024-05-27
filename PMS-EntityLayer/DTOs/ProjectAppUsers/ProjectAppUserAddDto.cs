
using System;

namespace PMS_EntityLayer.DTOs.ProjectAppUsers
{
    public class ProjectAppUserAddDto
    {
        public Guid ProjectId { get; set; }
        public Guid AppUserId { get; set; }
    }
}
