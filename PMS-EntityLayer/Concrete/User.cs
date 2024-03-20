using PMS.CoreLayer.Entities;
namespace PMS.EntityLayer.Concrete
{
	public class User : BaseEntityWithId
	{
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }

    }
}
