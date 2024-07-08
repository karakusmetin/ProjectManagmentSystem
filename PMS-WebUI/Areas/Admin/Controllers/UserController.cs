using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PMS.ServiceLayer.Extensions;
using PMS.ServiceLayer.Services.Abstract;
using PMS.ServiceLayer.Services.Concrete;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Tasks;
using PMS_EntityLayer.DTOs.Users;
using PMS_WebUI.ResultMessages;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using static PMS_WebUI.ResultMessages.Messages;

namespace PMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Superadmin")]
    public class UserController : Controller
    {
        private readonly IProjectManagerService projectManagerService;
        private readonly IProjectService projectService;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;
        private readonly IValidator<AppUser> validator;
        private readonly IImageService ımageService;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITaskService taskService;

        public UserController(IProjectManagerService projectManagerService,IProjectService projectService,UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IToastNotification toastNotification,IValidator<AppUser> validator,IImageService ımageService, SignInManager<AppUser> signInManager,ITaskService taskService)
        {
            this.projectManagerService = projectManagerService;
            this.projectService = projectService;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
            this.validator = validator;
            this.ımageService = ımageService;
            this.signInManager = signInManager;
            this.taskService = taskService;
        }
        public async Task<IActionResult> Index()
        {

            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var user in map)
            {
                var findUser = await userManager.FindByIdAsync(user.Id.ToString());
                var role = string.Join("", await userManager.GetRolesAsync(findUser)); //Userın tanımı gereği birden fazla rolü olabileceği için tek bir strgine çevirmek için gerekli

                user.Role = role;
            }

            return View(map);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(new UserAddDto { Roles = roles });
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            var validation = await validator.ValidateAsync(map);
            var roles = await roleManager.Roles.ToListAsync();


            if (ModelState.IsValid)
            {
                map.UserName = userAddDto.Email;
                var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(userAddDto.Email.ToString());
                    var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                    
                    if (findRole.Name == "ProjectManager")
                    {
                        await projectManagerService.CerateProjectManagerAsync(user.Id);
                    }
                    
                    await userManager.AddToRoleAsync(map, findRole.ToString());
                    toastNotification.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Başarılı" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddDto { Roles = roles });
                }
            }
            return View(new UserAddDto { Roles = roles });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            var roles = await roleManager.Roles.ToListAsync();

            var map = mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;

            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await userManager.FindByIdAsync(userUpdateDto.Id.ToString());
            if (user != null)
            {
                var userRole = string.Join("", await userManager.GetRolesAsync(user));
                var roles = await roleManager.Roles.ToListAsync();
                if (ModelState.IsValid)
                {
                    var map = mapper.Map(userUpdateDto, user);
                    var validation = await validator.ValidateAsync(map);
                    if(validation.IsValid)
                    {
                        var findCurrentRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                        if (findCurrentRole != null && userRole == findCurrentRole.Name)
                        {
                            user.FirstName = userUpdateDto.FirstName;
                            user.LastName = userUpdateDto.LastName;
                            user.Email = userUpdateDto.Email;
                            user.PhoneNumber = userUpdateDto.PhoneNumber;
                            
                            var firstResult = await userManager.UpdateAsync(user);
                            if (firstResult.Succeeded)
                            {
                                toastNotification.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Başarılı" });
                                return RedirectToAction("Index", "User", new { Area = "Admin" });
                            }
                            else
                            {
                                firstResult.AddToIdentityModelState(this.ModelState);
                                validation.AddToModelState(this.ModelState);
                                return View(new UserUpdateDto { Roles = roles });
                            }
                        }
                        if (userRole == "ProjectManager")
                        {
                            var anyManagerProjects = await projectService.AnyProjectWithProjectManagerId(userUpdateDto.Id);
                            if (anyManagerProjects)
                            {
                                toastNotification.AddErrorToastMessage("Bu proje Yöneticisinin bağlı olduğu projeler var.Lütfen önce onları düzenleyin");
                                return View(new UserUpdateDto { Roles = roles });
                            }
                            await projectManagerService.DeleteProjectManagerAsync(user.Id);
                        }
                        
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        
                        user.FirstName = userUpdateDto.FirstName;
                        user.LastName = userUpdateDto.LastName;
                        user.Email = userUpdateDto.Email;
                        user.PhoneNumber = userUpdateDto.PhoneNumber;

                        var result = await userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            await userManager.RemoveFromRoleAsync(user, userRole);
                            var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                            await userManager.AddToRoleAsync(user, findRole.Name);
                           
                            if(findRole.Name == "ProjectManager")
                            {
                                await projectManagerService.CerateProjectManagerAsync(user.Id);
                            }
                            toastNotification.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Başarılı" });
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            validation.AddToModelState(this.ModelState);
                            return View(new UserUpdateDto { Roles = roles });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto { Roles = roles });

                    }

                }
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            var userInProject = await projectService.AnyProjectUserGuidAsync(userId);
            var userInTask = await taskService.GetTaskByUserGuidAsync(userId);
            if (userInTask)
            {
                toastNotification.AddErrorToastMessage("Bu kullanıcı belirli bir göreve atanmış lütfen önce o görevi düzenleyin!!!");
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            if (userInProject)
            {
                toastNotification.AddErrorToastMessage("Bu kullanıcı belirli bir projeye yönetici olarak atanmış lütfen önce o projeyi düzenleyin!!!");
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }

            var result = await userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                toastNotification.AddSuccessToastMessage(Messages.User.Delete(user.Email), new ToastrOptions { Title = "Başarılı" });
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError("", errors.Description);
                }
                return NotFound();
            }
        }
    }
}
