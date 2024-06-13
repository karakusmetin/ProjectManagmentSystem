
using System;

namespace PMS_EntityLayer.DTOs.Dashboard
{
    public class ActivityDto
    {
        public string ActivityType { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string ByPerson { get; set; }
        public string EventType { get; set; }
    }
}
