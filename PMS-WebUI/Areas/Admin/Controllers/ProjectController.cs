using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PMS.EntityLayer.Concrete;
using PMS.ServiceLayer.Extensions;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Projects;
using PMS_WebUI.ResultMessages;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace PMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IMapper mapper;
        private readonly IValidator<Project> validator;
        private readonly IToastNotification toast;
        private readonly IDocumentService documentService;

        public ProjectController(IProjectService projectService,IMapper mapper,IValidator<Project> validator,IToastNotification toast,IDocumentService documentService)
        {
            this.projectService = projectService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
            this.documentService = documentService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var project = await projectService.GetListProjectsWithNonDeletedAsync();
            return View(project);
        }

        [HttpGet]
        public async Task<IActionResult> DeletedProject()
        {
            var project = await projectService.GetAllDeletedProjectAsync();
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
            var map = mapper.Map<Project>(projectAddDto);
            var document = new Document {};

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
                await projectService.CreateProjectAsync(projectAddDto,document);
                
                toast.AddSuccessToastMessage(Messages.Project.Add(projectAddDto.ProjectName), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Project", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return View();
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] ProjectAddDto projectAddDto)
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
                await projectService.CreateProjectAsync(projectAddDto, document);
                toast.AddSuccessToastMessage(Messages.Project.Add(projectAddDto.ProjectName), new ToastrOptions { Title = "Başarılı" });
                return Json(Messages.Project.Add(projectAddDto.ProjectName));
            }
            else
            {
                toast.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "Başarısız" });
                return Json(result.Errors.First().ErrorMessage);
            }

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
            var map = mapper.Map<Project>(projectUpdateDto);
            
            var document = new Document { };

            if (projectUpdateDto.File != null && projectUpdateDto.File.Length > 0)
            {
                if (projectUpdateDto.File.ContentType != "application/pdf")
                {
                    ModelState.AddModelError(string.Empty, "Only PDF files are allowed.");
                    return View(projectUpdateDto);
                }

                using var memoryStream = new MemoryStream();
                await projectUpdateDto.File.CopyToAsync(memoryStream);

                document.FileName = projectUpdateDto.File.FileName;
                document.ContentType = projectUpdateDto.File.ContentType;
                document.Content = memoryStream.ToArray();
                document.ProjectId = projectUpdateDto.Id;
            }

            var result = await validator.ValidateAsync(map);
            
            if (result.IsValid)
            {
                var projectName = await projectService.UpdateProjectAsync(projectUpdateDto,document);
                toast.AddSuccessToastMessage(Messages.Project.Update(projectName), new ToastrOptions() { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Project", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return View();
            }            

        }
        public async Task<IActionResult> Delete(Guid projectId)
        {
            var projectName = await projectService.SafeDeleteProjectAsync(projectId);
            toast.AddWarningToastMessage(Messages.Project.Delete(projectName), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Index", "Project", new { Area = "Admin" });
        }

        public async Task<IActionResult> UndoDelete(Guid projectId)
        {
            var projectName = await projectService.UndoDeleteProjectAsync(projectId);
            toast.AddWarningToastMessage(Messages.Project.UndoDelete(projectName), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Index", "Project", new { Area = "Admin" });
        }
    }
}
