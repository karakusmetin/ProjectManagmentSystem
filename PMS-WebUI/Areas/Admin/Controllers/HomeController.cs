using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMS.ServiceLayer.Services.Abstract;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,ProjectManager,Superadmin")]
    public class HomeController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IDashboardService dashboardService;

        public HomeController(IProjectService projectService,IDashboardService dashboardService)
        {
            this.projectService = projectService;
            this.dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var recentActivities = await dashboardService.GetRecentActivitiesAsync();
            return View(recentActivities);
        }
        public async  Task<IActionResult> Dashboard() 
        {
            var dashboardGraphics = await dashboardService.GetAllNumbersForGraphicsAsync();
            return View(dashboardGraphics);
        }
    }
}
