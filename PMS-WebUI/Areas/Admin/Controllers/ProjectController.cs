using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PMS.EntityLayer.Concrete;
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
        private readonly IMapper mapper;

        public ProjectController(IProjectService projectService,IMapper mapper)
        {
            this.projectService = projectService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var project = await projectService.GetListProjectsWithNonDeletedAsync();
            return View(project);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProjectAddDto projectAddDto)
        {

            await projectService.CreateProjectAsync(projectAddDto);
            RedirectToAction("Index", "Project", new { Area = "Admin" });

            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Update(Guid projectId)
        {

            var project = await projectService.GetProjectWithNonDeletedAsync(projectId);
            var projectUpdateDto = mapper.Map<ProjectUpdateDto>(project);


            return View(projectUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProjectUpdateDto projectUpdateDto)
        {
            await projectService.UpdateProjectAsync(projectUpdateDto);
            RedirectToAction("Index", "Project", new { Area = "Admin" });

            return View();

        }
    }
}
