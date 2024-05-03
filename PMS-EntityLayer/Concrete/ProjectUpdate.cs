using PMS.CoreLayer.Entities;
using PMS.EntityLayer.Enums;
using PMS_EntityLayer.Concrete;
using System;

namespace PMS.EntityLayer.Concrete
{
	public class ProjectUpdate : BaseEntityWithId
	{
		public string Content { get; set; }
		public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        
        public Guid UpdatedUserId { get; set; }
        public AppUser AppUser { get; set; }
        
        public DateTime UpdateDate { get; set; } = DateTime.Now;
       
        public UpdateType Type { get; set; }
        public ProjectUpdateStatus Status { get; set; }
    }
}
