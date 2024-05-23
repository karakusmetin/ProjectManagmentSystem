using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PMS.ServiceLayer.Extensions;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.DTOs.Tasks;
using PMS_WebUI.ResultMessages;
using System;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IValidator<PMS_EntityLayer.Concrete.Task> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;

        public TaskController(ITaskService taskService,IValidator<PMS_EntityLayer.Concrete.Task> validator,IMapper mapper,IToastNotification toastNotification)
        {
            this.taskService = taskService;
            this.validator = validator;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tasks = await taskService.GetAllTasksNonDeletedAsync();
            return View(tasks);
        }
        [HttpGet]
        public async Task<IActionResult> DeletedTask()
        {
            var tasks = await taskService.GetAllTasksDeletedAsync();
            return View(tasks);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(TaskAddDto taskAddDto)
        {   
            var map = mapper.Map<PMS_EntityLayer.Concrete.Task>(taskAddDto);
            var result = await validator.ValidateAsync(map);

            if(result.IsValid)
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
            var result =await validator.ValidateAsync(map);
            
            if(result.IsValid)
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

        public async Task<IActionResult> UndoDelete(Guid taskId)
        {
            var taskName = await taskService.UndoDeleteTaskAsync(taskId);
            toastNotification.AddWarningToastMessage(Messages.Task.UndoDelete(taskName), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Index", "Task", new { Area = "Admin" });
        }
    }
}
