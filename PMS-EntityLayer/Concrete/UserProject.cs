using PMS.EntityLayer.Concrete;
using System;

namespace PMS_EntityLayer.Concrete
{
    public class UserProject 
    {
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
