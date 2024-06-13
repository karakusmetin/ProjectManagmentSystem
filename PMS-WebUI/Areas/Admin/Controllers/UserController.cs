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
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Users;
using PMS_WebUI.ResultMessages;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Superadmin")]
    public class UserController : Controller
    {
        private readonly IProjectManagerService projectManagerService;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;
        private readonly IValidator<AppUser> validator;
        private readonly IImageService ımageService;
        private readonly SignInManager<AppUser> signInManager;

        public UserController(IProjectManagerService projectManagerService,UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IToastNotification toastNotification,IValidator<AppUser> validator,IImageService ımageService, SignInManager<AppUser> signInManager)
        {
            this.projectManagerService = projectManagerService;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
            this.validator = validator;
            this.ımageService = ımageService;
            this.signInManager = signInManager;
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
                    var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
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
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await userManager.UpdateAsync(user);
                        if (result.Succeeded)
                        {
                            await userManager.RemoveFromRoleAsync(user, userRole);
                            var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                            await userManager.AddToRoleAsync(user, findRole.Name);
                            
                            if(userRole == "ProjectManager")
                            {
                                await projectManagerService.DeleteProjectManagerAsync(user.Id);
                            }
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

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            user = await userManager.Users.Include(u => u.Image).FirstOrDefaultAsync(u => u.Id == user.Id);
            var map = mapper.Map<UserProfileDto>(user);

            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto, IFormFile upload)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            user = await userManager.Users
                .Include(u => u.Image)
                .FirstOrDefaultAsync(u => u.Id == user.Id);
            var map = mapper.Map<UserProfileDto>(user);

            if (ModelState.IsValid)
            {
                var isVerified = await userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
                if (isVerified)
                {
                    if (upload != null && upload.Length > 0)
                    {

                        using (var memoryStream = new MemoryStream())
                        {
                            await upload.CopyToAsync(memoryStream);
                            user.Image.ImageData = memoryStream.ToArray();
                            userProfileDto.ImageData = memoryStream.ToArray();
                        }
                        user.ImageId = await ımageService.CreateImageAsync(userProfileDto.ImageData, upload.FileName);
                        if (user.Image.FileName != "images/testimage1")
                            await ımageService.DeleteImageAsync(user.Image.Id);
                    }

                    if (userProfileDto.NewPassword != null)
                    {
                        var result = await userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
                        if (result.Succeeded)
                        {
                            await userManager.UpdateSecurityStampAsync(user);
                            await signInManager.SignOutAsync();
                            await signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);
                        }
                        else
                        {
                            result.AddToIdentityModelState(ModelState);
                            return View(map);
                        }
                    }

                    user.FirstName = userProfileDto.FirstName;
                    user.LastName = userProfileDto.LastName;
                    user.PhoneNumber = userProfileDto.PhoneNumber;

                    await userManager.UpdateAsync(user);
                    toastNotification.AddSuccessToastMessage("Bilgileriniz başarı ile değiştirilmiştir");
                    return View(map);
                }
                else
                {
                    toastNotification.AddErrorToastMessage("Güncellenirken bir hata oluştu");
                }
            }
            return View(map);
        }
    }
}
