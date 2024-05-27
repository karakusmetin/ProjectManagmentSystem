using PMS.EntityLayer.Concrete;
using PMS_EntityLayer.Concrete;
using System;

namespace PMS_EntityLayer.DTOs.ProjectAppUsers
{
    public class ProjectAppUserDto
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
