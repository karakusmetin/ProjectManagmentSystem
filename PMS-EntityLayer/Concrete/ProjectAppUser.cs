using PMS.EntityLayer.Concrete;
using System;

namespace PMS_EntityLayer.Concrete
{
    public class ProjectAppUser
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
