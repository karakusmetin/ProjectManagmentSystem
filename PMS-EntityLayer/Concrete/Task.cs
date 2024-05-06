using PMS.CoreLayer.Entities;
using PMS.EntityLayer.Concrete;
using PMS.EntityLayer.Enums;
using System;

namespace PMS_EntityLayer.Concrete
{
    public class Task : BaseEntityWithId
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PriorityLevel Priority { get; set; }

        public Guid AssignedUserId { get; set; } // Tek bir kullanıcıya atanan ID
        public AppUser AssignedUser { get; set; } // Tek bir kullanıcıya referans

        public Guid ProjectId { get; set; } // Görevin ait olduğu proje ID'si
        public Project Project { get; set; } // Görevin ait olduğu proje
    }
}
