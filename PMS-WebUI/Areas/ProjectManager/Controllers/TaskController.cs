using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PMS.ServiceLayer.Extensions;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Tasks;
using PMS_EntityLayer.DTOs.Users;
using PMS_WebUI.ResultMessages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.ProjectManager.Controllers
{
    [Area("ProjectManager")]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IValidator<PMS_EntityLayer.Concrete.Task> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;
        private readonly UserManager<AppUser> userManager;

        public TaskController(ITaskService taskService, IValidator<PMS_EntityLayer.Concrete.Task> validator, IMapper mapper, IToastNotification toastNotification, UserManager<AppUser> userManager)
        {
            this.taskService = taskService;
            this.validator = validator;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Add(Guid projectId)
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            return View(new TaskAddDto { AppUsers = map ,ProjectId = projectId});
        }
        [HttpPost]
        public async Task<IActionResult> Add(TaskAddDto taskAddDto)
        {
            var map = mapper.Map<PMS_EntityLayer.Concrete.Task>(taskAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await taskService.CreateTaskAsync(taskAddDto);
                toastNotification.AddSuccessToastMessage(Messages.Task.Add(taskAddDto.TaskName), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Task", new { Area = "Admin" });

            }
            else
            {
                result.AddToModelState(this.ModelState);
                return View();
            }
        }



        [HttpGet]
        public async Task<IActionResult> Update(Guid taskId)
        {
            var task = await taskService.GetTaskByGuidAsync(taskId);
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TaskUpdateDto taskUpdateDto)
        {
            var map = mapper.Map<PMS_EntityLayer.Concrete.Task>(taskUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await taskService.UpdateTaskAsync(taskUpdateDto);
                toastNotification.AddSuccessToastMessage(Messages.Task.Update(taskUpdateDto.TaskName), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "Task", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return View();
            }
        }

        public async Task<IActionResult> Delete(Guid taskId)
        {
            var taskName = await taskService.SafeDeleteTaskAsync(taskId);
            toastNotification.AddWarningToastMessage(Messages.Task.Delete(taskName), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Index", "Task", new { Area = "Admin" });
        }
    }
}
