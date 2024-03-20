using PMS_EntityLayer.Enums;
using System;

namespace PMS.EntityLayer.Concrete
{
	public class ProjectUpdate
	{
		public int Id { get; set; }
        public Project ProjectId { get; set; }
        public User UpdatedUserId { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string Content { get; set; }
        public UpdateType Type { get; set; }
        public ProjectUpdateStatus Status { get; set; }
    }
}
