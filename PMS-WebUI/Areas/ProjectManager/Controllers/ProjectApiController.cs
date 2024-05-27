using Microsoft.AspNetCore.Mvc;
using PMS.ServiceLayer.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.ProjectManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectApiController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectApiController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        [HttpGet("search-projects")]
        public async Task<IActionResult> SearchProjects(string projectName)
        {
            var project = await projectService.GetAllProjectWithNameAsync(projectName);

            var projectDtos = project.Select(u => new
            {
                Id = u.Id,
                ProjectName = $"{u.ProjectName}",
            }).ToList();

            return Ok(projectDtos);
        }
    }
}
