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
        public TaskUpdateStatus UpdateStatus { get; set; }


        public Guid UserId { get; set; } 
        public AppUser AppUser { get; set; } 

        public Guid ProjectId { get; set; } 
        public Project Project { get; set; } 
    }
}
