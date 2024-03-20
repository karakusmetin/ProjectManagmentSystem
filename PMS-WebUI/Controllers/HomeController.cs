using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMS.ServiceLayer.Services.Abstract;
using PMS_WebUI.Models;
using System.Diagnostics;
using System.Threading.Tasks;


namespace PMS_WebUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IProjectService projectService;

		public HomeController(ILogger<HomeController> logger, IProjectService projectService)
		{
			_logger = logger;
			this.projectService = projectService;
		}

		public async Task<IActionResult> Index()
		{
			var projects = await projectService.GetListArticleAsync();
			return View(projects);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
