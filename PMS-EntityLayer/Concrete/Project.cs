using PMS.CoreLayer.Entities;
using PMS_EntityLayer.Enums;
using System;

namespace PMS.EntityLayer.Concrete
{
	public class Project : IBaseEntityWithId
	{
		public string ProjectName { get; set; }
		public string Description { get; set; }
        public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
        public float Budget { get; set; }
		public PriorityLevel Priority {  get; set; }

    }
}
