using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using NToastNotify;
using PMS.EntityLayer.Concrete;
using PMS.ServiceLayer.Extensions;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.ProjectAppUsers;
using PMS_EntityLayer.DTOs.Projects;
using PMS_WebUI.ResultMessages;
using System;
using System.IO;
using System.Threading.Tasks;
using static PMS_WebUI.ResultMessages.Messages;
using Project = PMS.EntityLayer.Concrete.Project;

namespace PMS_WebUI.Areas.ProjectManager.Controllers
{
    [Area("ProjectManager")]
    [Authorize(Roles = "Admin,ProjectManager,Superadmin")]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IDocumentService documentService;
        private readonly IMapper mapper;
        private readonly IValidator<Project> validator;
        private readonly IToastNotification toastNotification;
        private readonly IProjectAppUserService projectAppUserService;

        public ProjectController(IProjectService projectService, IDocumentService documentService, IMapper mapper, IValidator<Project> validator, IToastNotification toastNotification, IProjectAppUserService projectAppUserService)
        {
            this.projectService = projectService;
            this.documentService = documentService;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
            this.projectAppUserService = projectAppUserService;
        }
        public async Task<IActionResult> Detail(Guid projectId)
        {
            var project = await projectService.GetProjectWithNonDeletedWithUsersWithTasksAsync(projectId);
            return View(project);
        }
        [HttpGet]
        public async Task<IActionResult> GetDocument(Guid documentId)
        {
            var document = await documentService.GetDocumentWithIdAsync(documentId);
            if (document == null)
            {
                return NotFound();
            }

            var base64String = Convert.ToBase64String(document.Content);
            var response = new
            {
                fileName = document.FileName,
                contentType = document.ContentType,
                base64String = base64String
            };

            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> Add(Guid projectManagerId)
        {
            return View(new ProjectAddDto { ProjectManagerId = projectManagerId });
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProjectAddDto projectAddDto)
        {

            var map = mapper.Map<Project>(projectAddDto);
            var document = new Document { };

            if (projectAddDto.File != null && projectAddDto.File.Length > 0)
            {
                if (projectAddDto.File.ContentType != "application/pdf")
                {
                    ModelState.AddModelError(string.Empty, "Only PDF files are allowed.");
                    return View(projectAddDto);
                }

                using var memoryStream = new MemoryStream();
                await projectAddDto.File.CopyToAsync(memoryStream);

                document.FileName = projectAddDto.File.FileName;
                document.ContentType = projectAddDto.File.ContentType;
                document.Content = memoryStream.ToArray();
                document.ProjectId = projectAddDto.Id;
            }
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var projectId = await projectService.CreateProjectAsync(projectAddDto, document);
                foreach (var userId in projectAddDto.AppUserIds)
                {
                    var projectAppUsers = new ProjectAppUserAddDto
                    {
                        ProjectId = projectId,
                        AppUserId = userId
                    };
                    await projectAppUserService.CreateProjectAppUserAsync(projectAppUsers);
                }
                toastNotification.AddSuccessToastMessage(Messages.Project.Add(projectAddDto.ProjectName), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Home", new { Area = "ProjectManager" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Update(ProjectUpdateDto projectUpdateDto)
        {
            var map = mapper.Map<Project>(projectUpdateDto);

            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var projectName = await projectService.UpdateProjectAsync(projectUpdateDto);
                toastNotification.AddSuccessToastMessage(Messages.Project.Update(projectName), new ToastrOptions() { Title = "İşlem Başarılı" });
                return RedirectToAction("Detail", "Project", new { Area = "ProjectManager", projectId = projectUpdateDto.Id });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return RedirectToAction("Detail", "Project", new { Area = "ProjectManager", projectId = projectUpdateDto.Id });
            }

        }

        public async Task<IActionResult> Delete(Guid projectId)
        {
            try
            {
                var projectName = await projectService.SafeDeleteProjectAsync(projectId);
                toastNotification.AddSuccessToastMessage(Messages.Project.Delete(projectName), new ToastrOptions() { Title = "İşlem Başarılı" });
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                toastNotification.AddErrorToastMessage("Proje silinirken bir hata oluştu. Hata detayı: " + ex.Message, new ToastrOptions() { Title = "Hata" });
                return Json(new { success = false, message = "Proje silinirken bir hata oluştu. Hata detayı: " + ex.Message });
            }
        }


        public async Task<IActionResult> DeletedProjects()
        {
            var projects = await projectService.GetAllDeletedProjectAsync();
            return View(projects);
        }

    }
}
