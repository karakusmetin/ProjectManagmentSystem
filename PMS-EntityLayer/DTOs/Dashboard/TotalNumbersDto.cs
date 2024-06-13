namespace PMS_EntityLayer.DTOs.Dashboard
{
    public class TotalNumbersDto
    {
        public int TotalProjects { get; set; }
        public int CompletedProjects { get; set; }
        public int OngoingProjects { get; set; }
        public int TotalProjectManagers { get; set; }
        public int TotalTasks { get; set; }
        public int OngoingTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int TotalUsers { get; set; }
    }
}
