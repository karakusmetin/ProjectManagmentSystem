using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMS.ServiceLayer.Services.Abstract;
using System;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.ProjectManager.Controllers
{
    [Area("ProjectManager")]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        public async Task<IActionResult> Detail(Guid projectId)
        {
            var project = await projectService.GetProjectWithNonDeletedWithUsersWithTasksAsync(projectId);
            return View(project);
        }
    }
}
