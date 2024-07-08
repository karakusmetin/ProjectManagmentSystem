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
        private readonly ITaskService taskService;

        public ProjectUserController(IProjectAppUserService projectAppUserService, IToastNotification toastNotification,ITaskService taskService)
        {
            this.projectAppUserService = projectAppUserService;
            this.toastNotification = toastNotification;
            this.taskService = taskService;
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

        public async Task<IActionResult> Delete(Guid projectId, Guid appUserId)
        {
            var anyTasks = await taskService.AnyTasksByUserIdAndProjectIdAsync(projectId, appUserId);
            if (anyTasks)
            {
                toastNotification.AddErrorToastMessage("Bu Kullanıcının proje içerisinde henüz bitmemiş görevleri var.Lütfen önce onları silin!!");
                return RedirectToAction("Index", "ProjectUser", new { Area = "Admin" });
            }
            projectAppUserService.DeleteProjectAppUser(projectId, appUserId);

            toastNotification.AddWarningToastMessage(Messages.ProjectUser.Delete(), new ToastrOptions { Title = "Başarılı" });
            return RedirectToAction("Index", "ProjectUser", new { Area = "Admin" });

        }
    }
}
