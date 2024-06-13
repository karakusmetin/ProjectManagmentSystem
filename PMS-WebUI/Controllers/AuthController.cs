using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PMS.ServiceLayer.Extensions;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Users;
using PMS_WebUI.ResultMessages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PMS_WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMapper mapper;
        private readonly RoleManager<AppRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IToastNotification toastNotification;
        private readonly IValidator<AppUser> validator;

        public AuthController(RoleManager<AppRole> roleManager,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IToastNotification toastNotification, IValidator<AppUser> validator, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.toastNotification = toastNotification;
            this.validator = validator;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                TempData["ErrorMessage"] = "E-posta adresiniz veya şifreniz yanlıştır";
                return RedirectToAction("Index", "Home");
            }
            var map = mapper.Map<UserDto>(user);

            var role = string.Join("", await userManager.GetRolesAsync(user));
            map.Role = role;

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, password, rememberMe, false);
                if (result.Succeeded)
                {
                    if (map.Role == "Admin" || map.Role == "Superadmin")
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });

                    if (map.Role == "ProjectManager")
                        return RedirectToAction("Index", "Home", new { Area = "ProjectManager" });

                    else
                        return RedirectToAction("Index", "UserTask");
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır");
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır");
                return RedirectToAction("Index", "Home");
            }

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            if (userRegisterDto.Password != userRegisterDto.ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match");
                return View(userRegisterDto);
            }

            var map = mapper.Map<AppUser>(userRegisterDto);
            var validation = await validator.ValidateAsync(map);

            if (!validation.IsValid)
            {
                toastNotification.AddErrorToastMessage($@"{validation.Errors}");
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                map.UserName = userRegisterDto.Email;
                var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userRegisterDto.Password) ? "" : userRegisterDto.Password);

                if (result.Succeeded)
                {
                    var findRole = await roleManager.FindByIdAsync(Guid.Parse("492F344E-4BA6-485B-A3F1-73219B3E61C9").ToString());
                    await userManager.AddToRoleAsync(map, findRole.ToString());
                    toastNotification.AddSuccessToastMessage(Messages.User.Add(userRegisterDto.Email), new ToastrOptions { Title = "Başarılı" });
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        TempData["ErrorMessage"] = $@"{error.Description}";
                    }
                }
            };
            return RedirectToAction("Index","Home");
        }

    }
}

