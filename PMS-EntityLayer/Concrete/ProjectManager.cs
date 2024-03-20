using PMS.CoreLayer.Entities;

namespace PMS.EntityLayer.Concrete
{
	public class ProjectManager : IBaseEntityWithId
	{
		public User UserId { get; set; }
        public bool EditerOrNot { get; set; }
    }
}
