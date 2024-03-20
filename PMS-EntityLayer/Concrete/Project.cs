using PMS.CoreLayer.Entities;
using PMS.EntityLayer.Enums;
using System;
using System.Collections.Generic;

namespace PMS.EntityLayer.Concrete
{
	public class Project : BaseEntityWithId
	{
		public string ProjectName { get; set; }
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public float Budget { get; set; }
		public PriorityLevel Priority { get; set; }
		public ICollection<ProjectUpdate> ProjectUpdates{get;set;}
    }
}
