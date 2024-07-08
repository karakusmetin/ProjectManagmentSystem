using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMS.ServiceLayer.Services.Abstract;
using PMS_WebUI.Models;
using System.Diagnostics;
using System.Threading.Tasks;


namespace PMS_WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IProjectService projectService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IProjectService projectService, IHttpContextAccessor httpContextAccessor)
		{
			_logger = logger;
			this.projectService = projectService;
            this.httpContextAccessor = httpContextAccessor;
        }

		public async Task<IActionResult> Index()
		{
			if(HttpContext.User.Identity.IsAuthenticated)
			{
                if (HttpContext.User.IsInRole("Admin"))
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });

                else if (HttpContext.User.IsInRole("ProjectManager"))
                    return RedirectToAction("Index", "Home", new { Area = "ProjectManager" });
               
				else if (HttpContext.User.IsInRole("Superadmin"))
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });

                else
                    return RedirectToAction("Index", "UserTask");
            }
			else
				return View();
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
