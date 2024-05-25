using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Projects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.ProjectManager.Controllers
{
    [Area("ProjectManager")]
    public class HomeController : Controller
    {
        private readonly IProjectService projectService;

        public HomeController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        public async Task<IActionResult> Index()
        {
            var projects = await projectService.GetAllProjectWithUserIdAsync();
            return View(projects);
        }
    }
}
