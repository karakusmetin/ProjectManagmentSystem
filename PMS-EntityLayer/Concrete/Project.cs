using PMS.CoreLayer.Entities;
using PMS.EntityLayer.Enums;
using PMS_EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace PMS.EntityLayer.Concrete
{
	public class Project : BaseEntityWithId
	{
		public string ProjectName { get; set; }
		public string Description { get; set; }
        public float Budget { get; set; }
        public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		
		public PriorityLevel Priority { get; set; }
        
		public Guid ProjectManagerId { get; set; }
        public ProjectManager ProjectManager { get; set; }

        public Guid? ImageId { get; set; }
        public Image Image { get; set; }

        public ICollection<AppUser> ProjectMembers { get; set; }
        public ICollection<ProjectUpdate> ProjectUpdates { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
