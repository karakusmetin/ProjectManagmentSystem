﻿using Microsoft.AspNetCore.Identity;
using PMS.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace PMS_EntityLayer.Concrete
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }

        // Bir kullanıcının birden fazla projeye dahil olabilmesi için koleksiyon tanımlıyoruz
        public ICollection<Project> ManagedProjects { get; set; }

        public ICollection<Task> Tasks { get; set; }

    }
}
