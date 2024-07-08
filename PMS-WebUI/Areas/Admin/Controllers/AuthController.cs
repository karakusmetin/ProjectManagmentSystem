using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Users;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper mapper;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLoginDto.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır");
                    return View();
                }
                var map = mapper.Map<UserDto>(user);
                var role = string.Join("", await userManager.GetRolesAsync(user));
                map.Role = role;
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
                    if (result.Succeeded)
                    {
                        if (map.Role == "Admin" || map.Role == "Superadmin")
                            return RedirectToAction("Index", "Home", new { Area = "Admin" });

                        if (map.Role == "ProjectManager")
                            return RedirectToAction("Index", "Home", new { Area = "ProjectManager" });

                        else
                            return RedirectToAction("Index", "UserTask", new { Area = "" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır");
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
