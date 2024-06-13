using AutoMapper;
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
using System.IO;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace PMS_WebUI.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IImageService ımageService;
        private readonly IMapper mapper;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IToastNotification toastNotification;
        private readonly UserManager<AppUser> userManager;

        public UserController(IImageService ımageService, IMapper mapper, SignInManager<AppUser> signInManager, IToastNotification toastNotification, UserManager<AppUser> userManager)
        {
            this.ımageService = ımageService;
            this.mapper = mapper;
            this.signInManager = signInManager;
            this.toastNotification = toastNotification;
            this.userManager = userManager;
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
                if(userProfileDto.CurrentPassword == null)
                {
                    toastNotification.AddErrorToastMessage("Lütfen Mevcut Şifreyi Giriniz");
                    return View(map);
                }
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
