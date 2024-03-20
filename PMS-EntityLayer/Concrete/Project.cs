using PMS_EntityLayer.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PMS.EntityLayer.Concrete
{
	public class Project
	{
		[Key]
		public Guid Id { get; set; }
		public string ProjectName { get; set; }
		public string Description { get; set; }
        public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
        public float Budget { get; set; }
        public bool IsActive { get; set; }
		public PriorityLevel Priority {  get; set; }

    }
}
