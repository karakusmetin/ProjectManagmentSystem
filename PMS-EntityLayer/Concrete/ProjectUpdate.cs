using PMS.CoreLayer.Entities;
using PMS.EntityLayer.Enums;
using System;

namespace PMS.EntityLayer.Concrete
{
	public class ProjectUpdate : BaseEntityWithId
	{
		public string Content { get; set; }
		public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        
        public Guid UpdatedUserId { get; set; }
        public User User { get; set; }
        
        public DateTime UpdateDate { get; set; } = DateTime.Now;
       
        public UpdateType Type { get; set; }
        public ProjectUpdateStatus Status { get; set; }
    }
}
