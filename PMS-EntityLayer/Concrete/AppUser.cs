using Microsoft.AspNetCore.Identity;
using System;

namespace PMS_EntityLayer.Concrete
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
