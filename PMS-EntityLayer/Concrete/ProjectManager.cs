using PMS.CoreLayer.Entities;
using System;

namespace PMS.EntityLayer.Concrete
{
	public class ProjectManager : BaseEntityWithId
	{
		public bool EditerOrNot { get; set; }
		public Guid UserId { get; set; }
		public User User { get; set; }

       
    }
}
