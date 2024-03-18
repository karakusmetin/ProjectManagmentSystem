using System;
using System.ComponentModel.DataAnnotations;

namespace PMS_EntityLayer.Concrete
{
	public class User
	{
        [Key]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }

    }
}
