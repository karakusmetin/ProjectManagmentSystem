
using System;
using System.Collections.Generic;

namespace PMS_EntityLayer.DTOs.Dashboard
{
    public class DashboardPageDto
    {
        public int TotalProjects { get; set; }
        public int CompletedProjects { get; set; }
        public int OngoingProjects { get; set; }
        public int TotalTasks { get; set; }
        public int OngoingTasks { get; set; }
        public int CompletedTasks { get; set; }
        public List<string> ProjectDates { get; set; }
        public List<int> ProjectCounts { get; set; }

    }
}
