using Microsoft.AspNetCore.Http;
using PMS.EntityLayer.Enums;
using System;
using System.Collections.Generic;

namespace PMS_EntityLayer.DTOs.Projects
{
    public class ProjectAddDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public float Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PriorityLevel Priority { get; set; }
        public Guid ProjectManagerId { get; set; }

        public IFormFile? File { get; set; }

        public List<Guid> AppUserIds { get; set; } = new List<Guid>();
    }
}
