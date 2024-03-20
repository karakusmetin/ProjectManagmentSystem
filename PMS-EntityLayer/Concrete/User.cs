using PMS.CoreLayer.Entities;
using System.Collections.Generic;
namespace PMS.EntityLayer.Concrete
{
	public class User : BaseEntityWithId
	{
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
		public ICollection<ProjectUpdate> ProjectUpdates { get; set; }

	}
}
