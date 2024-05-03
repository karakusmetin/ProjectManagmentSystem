using PMS.CoreLayer.Entities;
using PMS_EntityLayer.Concrete;
using System;

namespace PMS.EntityLayer.Concrete
{
	public class ProjectManager : BaseEntityWithId
	{
		public bool EditerOrNot { get; set; }
		public Guid UserId { get; set; }
		public AppUser AppUser { get; set; }

       
    }
}
