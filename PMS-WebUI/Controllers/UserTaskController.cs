using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Projects;
using System;
using System.Threading.Tasks;

namespace PMS_WebUI.Controllers
{
    
    public class UserTaskController : Controller
    {
        private readonly IProjectService projectService;
        private readonly ITaskService taskService;
        private readonly UserManager<AppUser> userManager;

        public UserTaskController(IProjectService projectService, ITaskService taskService, UserManager<AppUser> userManager)
        {
            this.projectService = projectService;
            this.taskService = taskService;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var projects = await projectService.GetAllProjectWithUserIdAsync();
            return View(projects);
        }

        public async Task<IActionResult> Detail(Guid projectId)
        {
            var project = await projectService.GetProjectWithNonDeletedAsync(projectId);
            if (project == null) return NotFound();

            var user = await userManager.GetUserAsync(User);
            var userTasks = await taskService.GetTasksByUserIdAndProjectIdAsync(user.Id, projectId);

            var model = new ProjectTaskDto
            {
                Project = project,
                UserTasks = userTasks
            };

            return View(model);
        }
    }
}
