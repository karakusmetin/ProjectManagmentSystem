using PMS.ServiceLayer.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PMS.DataLayer.UnitOfWorks;
using PMS.EntityLayer.Concrete;
using System.Linq;
using PMS_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using PMS_EntityLayer.DTOs.Dashboard;


namespace PMS.ServiceLayer.Services.Concrete
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<AppUser> userManager;

        public DashboardService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        public async Task<TotalNumbersDto> GetTotalNumbersAsync()
        {
            var totalProjects = await unitOfWork.GetRepository<Project>().CountAsync(x => true && x.IsActive==true);
            var ongoingProjects = await unitOfWork.GetRepository<Project>().CountAsync(x => x.EndDate >= DateTime.Now && x.IsActive == true);
            var completedProjects = await unitOfWork.GetRepository<Project>().CountAsync(x => x.EndDate <= DateTime.Now);

            var totalTasks = await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().CountAsync(x => true && x.IsActive == true);
            var ongoingTasks = await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().CountAsync(x => x.EndDate >= DateTime.Now && x.IsActive == true);
            var completedTasks = await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().CountAsync(x => x.EndDate <= DateTime.Now);

            var totalUsers = userManager.Users.Count();
            var totalProjectManagers = await unitOfWork.GetRepository<ProjectManager>().CountAsync(x => true);

            var totalNumbers = new TotalNumbersDto
            {
                TotalProjects = totalProjects,
                CompletedProjects = completedProjects,
                OngoingProjects = ongoingProjects,
                TotalTasks = totalTasks,
                CompletedTasks = completedTasks,
                OngoingTasks = ongoingTasks,
                TotalUsers = totalUsers,
                TotalProjectManagers = totalProjectManagers,
            };

            return totalNumbers;

        }
        public async Task<DashboardPageDto> GetAllNumbersForGraphicsAsync()
        {
            var totalProjects = await unitOfWork.GetRepository<Project>().CountAsync(x => true);
            var ongoingProjects = await unitOfWork.GetRepository<Project>().CountAsync(x => x.EndDate >= DateTime.Now);
            var completedProjects = await unitOfWork.GetRepository<Project>().CountAsync(x => x.EndDate <= DateTime.Now);

            var totalTasks = await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().CountAsync(x => true);
            var ongoingTasks = await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().CountAsync(x => x.EndDate >= DateTime.Now);
            var completedTasks = await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().CountAsync(x => x.EndDate <= DateTime.Now);

            var projectTimeline = await unitOfWork.GetRepository<Project>().GetAllAsync();
            var groupedProjectDates = projectTimeline
                   .GroupBy(p => p.InsertDate.Date)
                   .Select(g => new
                   {
                       Date = g.Key,
                       Count = g.Count()
                   })
                   .OrderBy(g => g.Date)
                   .ToList();

            var projectDates = groupedProjectDates.Select(g => g.Date.ToString("yyyy-MM-dd")).ToList();
            var projectCounts = groupedProjectDates.Select(g => g.Count).ToList();

            var totalNumbers = new DashboardPageDto
            {
                TotalProjects = totalProjects,
                CompletedProjects = completedProjects,
                OngoingProjects = ongoingProjects,
                TotalTasks = totalTasks,
                CompletedTasks = completedTasks,
                OngoingTasks = ongoingTasks,
                ProjectDates = projectDates,
                ProjectCounts = projectCounts
            };

            return totalNumbers;
        }
        public async Task<List<ActivityDto>> GetRecentActivitiesAsync()
        {


            var threeDaysAgo = DateTime.Now.AddDays(-3);

            var projectActivities = await unitOfWork.GetRepository<Project>().GetAllAsync(
                p => p.InsertDate >= threeDaysAgo || (p.UpdateDate.HasValue && p.UpdateDate.Value >= threeDaysAgo) || (p.DeletedDate.HasValue && p.DeletedDate.Value >= threeDaysAgo)
            );

            var taskActivities = await unitOfWork.GetRepository<PMS_EntityLayer.Concrete.Task>().GetAllAsync(
                t => t.InsertDate >= threeDaysAgo || (t.UpdateDate.HasValue && t.UpdateDate.Value >= threeDaysAgo) || (t.DeletedDate.HasValue && t.DeletedDate.Value >= threeDaysAgo)
            );

            var activities = new List<ActivityDto>();

            activities.AddRange(projectActivities.SelectMany(p => new List<ActivityDto>
            {
                new ActivityDto
                {
                    ActivityType = "Proje",
                    Description = p.Description,
                    ByPerson = p.InsertedBy,
                    Date = p.InsertDate,
                    EventType = "Oluşturuldu"
                },
                new ActivityDto
                {
                    ActivityType = "Proje",
                    Description = p.Description,
                    ByPerson = p.UpdatedBy,
                    Date = p.UpdateDate ?? DateTime.MinValue,
                    EventType = "Güncellendi"
                },
                new ActivityDto
                {
                    ActivityType = "Proje",
                    Description = p.Description,
                    ByPerson = p.DeletedBy,
                    Date = p.DeletedDate ?? DateTime.MinValue,
                    EventType = "Silindi"
                }
            }).Where(a => a.Date >= threeDaysAgo));

            activities.AddRange(taskActivities.SelectMany(t => new List<ActivityDto>
            {
                new ActivityDto
                {
                    ActivityType = "Görev",
                    Description = t.Description,
                    ByPerson = t.InsertedBy,
                    Date = t.InsertDate,
                    EventType = "Oluşturuldu"
                },
                new ActivityDto
                {
                    ActivityType = "Görev",
                    Description = t.Description,
                    ByPerson = t.UpdatedBy,
                    Date = t.UpdateDate ?? DateTime.MinValue,
                    EventType = "Güncellendi"
                },
                new ActivityDto
                {
                    ActivityType = "Görev",
                    Description = t.Description,
                    ByPerson = t.DeletedBy,
                    Date = t.DeletedDate ?? DateTime.MinValue,
                    EventType = "Silindi"
                }
            }).Where(a => a.Date >= threeDaysAgo));

           
            return activities.OrderByDescending(a => a.Date).Take(15).ToList();
        }


    }
}
