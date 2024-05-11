using PMS.EntityLayer.Enums;
using System;

namespace PMS_EntityLayer.DTOs.ProjectUpdate
{
    public class ProjectUpdateDto
    {
        public DateTime UpdateDate { get; set; }
        public ProjectUpdateStatus Status { get; set; }
    }
}
