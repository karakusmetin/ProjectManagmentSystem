using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PMS.EntityLayer.Concrete;
using PMS.ServiceLayer.Extensions;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.DTOs.Projects;
using PMS_WebUI.ResultMessages;
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
        private readonly IValidator<Project> validator;
        private readonly IToastNotification toast;

        public ProjectController(IProjectService projectService,IMapper mapper,IValidator<Project> validator,IToastNotification toast)
        {
            this.projectService = projectService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
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
            var map = mapper.Map<Project>(projectAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await projectService.CreateProjectAsync(projectAddDto);
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
            var result = await validator.ValidateAsync(map);
            
            if (result.IsValid)
            {
                await projectService.CreateProjectAsync(projectAddDto);
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
            var result = await validator.ValidateAsync(map);
            
            if (result.IsValid)
            {
                var projectName = await projectService.UpdateProjectAsync(projectUpdateDto);
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
    }
}
