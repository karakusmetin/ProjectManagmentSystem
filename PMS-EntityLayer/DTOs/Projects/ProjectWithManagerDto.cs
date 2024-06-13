using PMS.EntityLayer.Concrete;
using PMS.EntityLayer.Enums;
using PMS_EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace PMS_EntityLayer.DTOs.Projects
{
    public class ProjectWithManagerDto
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ProjectManagerId { get; set; }
        public ProjectManager ProjectManager { get; set; }


    }
}
