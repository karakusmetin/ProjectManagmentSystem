using Microsoft.AspNetCore.Identity;
using PMS.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace PMS_EntityLayer.Concrete
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid ImageId { get; set; } = Guid.Parse("BA09FD97-7832-4EBF-A065-B195D0900340");
        public Image Image { get; set; }


        public ICollection<ProjectAppUser> ProjectAppUsers { get; set; } = new List<ProjectAppUser>();
        public ICollection<Task> Tasks { get; set; } = new List<Task>();

    }
}
