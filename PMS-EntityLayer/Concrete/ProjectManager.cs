using PMS.CoreLayer.Entities;
using PMS_EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace PMS.EntityLayer.Concrete
{
	public class ProjectManager : BaseEntityWithId
	{
		
		public Guid AppUserId { get; set; }
		public AppUser AppUser { get; set; }
       
    }
}
