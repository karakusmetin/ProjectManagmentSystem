using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PMS.ServiceLayer.Extensions;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Users;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.ProjectManager.Controllers
{
    [Area("ProjectManager")]
    [Authorize(Roles = "Admin,ProjectManager,Superadmin")]
    public class UserController : Controller
    {
        private readonly IImageService ımageService;
        private readonly IMapper mapper;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IProjectAppUserService projectAppUserService;
        private readonly IToastNotification toastNotification;
        private readonly UserManager<AppUser> userManager;

        public UserController(IImageService ımageService,IMapper mapper,SignInManager<AppUser> signInManager,IProjectAppUserService projectAppUserService, IToastNotification toastNotification, UserManager<AppUser> userManager)
        {
            this.ımageService = ımageService;
            this.mapper = mapper;
            this.signInManager = signInManager;
            this.projectAppUserService = projectAppUserService;
            this.toastNotification = toastNotification;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Add(Guid AppUserId, Guid projectId)
        {
            try
            {
                var message = await projectAppUserService.CreateProjectAppUserAsync(AppUserId, projectId);
                if (message)
                {
                    return Json(new { success = true, message = "Kullanıcı başarıyla eklendi." });
                }
                else
                {
                    return Json(new { success = false, message = "Kullanıcı eklenirken bir hata oluştu." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception (for example, using a logging library)
                return Json(new { success = false, message = ex.Message });
            }

        }
    }
}
