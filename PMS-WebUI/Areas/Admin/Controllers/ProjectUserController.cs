using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.DTOs.ProjectAppUsers;
using PMS_EntityLayer.DTOs.Tasks;
using PMS_WebUI.ResultMessages;
using System;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,ProjectManager,Superadmin")]
    public class ProjectUserController : Controller
    {
        private readonly IProjectAppUserService projectAppUserService;
        private readonly IToastNotification toastNotification;

        public ProjectUserController(IProjectAppUserService projectAppUserService, IToastNotification toastNotification)
        {
            this.projectAppUserService = projectAppUserService;
            this.toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            var projectAppUsers = projectAppUserService.GetAllListProjectAppUserNonDeletedAsync();
            return View(projectAppUsers);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProjectAppUserAddDto projectAppUserAddDto)
        {
            var message = await projectAppUserService.CreateProjectAppUserAsync(projectAppUserAddDto);
            if (message)
            {
                toastNotification.AddSuccessToastMessage(Messages.ProjectUser.Add(), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "ProjectUser", new { Area = "Admin" });
            }
            else
            {
                toastNotification.AddErrorToastMessage(Messages.ProjectUser.Error(), new ToastrOptions { Title = "Başarısız" });
                return View();
            }
            
        }

        public IActionResult Delete(Guid projectId, Guid appUserId)
        {
            projectAppUserService.DeleteProjectAppUser(projectId, appUserId);

            toastNotification.AddWarningToastMessage(Messages.ProjectUser.Delete(), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "ProjectUser", new { Area = "Admin" });

        }
    }
}
