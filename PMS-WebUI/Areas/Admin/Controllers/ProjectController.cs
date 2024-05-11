using Microsoft.AspNetCore.Mvc;
using PMS.EntityLayer.Enums;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.DTOs.Projects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public async Task<IActionResult> Index()
        {
            var project = await projectService.GetListProjectsWithNonDeletedAsync();
            return View(project);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.MyEnumValues = Enum.GetValues(typeof(PriorityLevel)).Cast<PriorityLevel>().ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProjectAddDto projectAddDto)
        {

            await projectService.CreateProjectAsync(projectAddDto);
            RedirectToAction("Index", "Project", new { Area = "Admin" });

            return View();
        }

    }
}
