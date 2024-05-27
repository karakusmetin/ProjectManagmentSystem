using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS.ServiceLayer.Services.Abstract;
using PMS.ServiceLayer.Services.Concrete;
using PMS_EntityLayer.Concrete;
using PMS_EntityLayer.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IProjectManagerService projectManagerService;
    private readonly IMapper mapper;
    private readonly IProjectService projectService;

    public UsersController(UserManager<AppUser> userManager,IProjectManagerService projectManagerService,IMapper mapper,IProjectService projectService)
    {
        _userManager = userManager;
        this.projectManagerService = projectManagerService;
        this.mapper = mapper;
        this.projectService = projectService;
    }

    [HttpGet("search-users")]
    public async Task<IActionResult> SearchUsers(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return BadRequest("Email parameter is required.");
        }

        var users = await _userManager.Users
            .Where(u => u.Email.Contains(email)) 
            .ToListAsync();

        var userDtos = users.Select(u => new
        {
            u.Id,
            FullName = $"{u.FirstName} {u.LastName}",
            u.Email
        }).ToList();

        return Ok(userDtos);
    }
    [HttpGet("search-manager")]
    public async Task<IActionResult> SearchManager(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return BadRequest("Email parameter is required.");
        }

        var users = await projectManagerService.GetAllProjectManagersAsync(email);

        var userDtos = users.Select(u => new
        {
            AppUserId = u.Id,
            FullName = $"{u.AppUser.FirstName} {u.AppUser.LastName}",
            Email = u.AppUser.Email 
        }).ToList();

        return Ok(userDtos);
    }
    
    [HttpGet("search-project-users")]
    public async Task<IActionResult> SearchProjectUsers(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return BadRequest("Email parameter is required.");
        }

        // Kullanıcıları email'e göre filtreleme
        var users = await _userManager.Users
            .Where(u => u.Email.Contains(email))
            .ToListAsync();

        var map = mapper.Map<List<UserDto>>(users);

        // Sadece "User" rolünde olan kullanıcıları filtreleme
        var userDtos = new List<object>();

        foreach (var user in map)
        {
            var findUser = await _userManager.FindByIdAsync(user.Id.ToString());
            var roles = await _userManager.GetRolesAsync(findUser);

            // Kullanıcının sadece "User" rolünde olup olmadığını kontrol et
            if (roles.Contains("User"))
            {
                userDtos.Add(new
                {
                    Id = user.Id,
                    FullName = $"{user.FirstName} {user.LastName}",
                    Email = user.Email,
                });
            }
        }
        return Ok(userDtos);
    }
    [HttpGet("search-project-users/{projectId}")]
    public async Task<IActionResult> SearchProjectUsersInProject(Guid projectId, string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return BadRequest("Email parameter is required.");
        }

        // Proje ID'sine ve e-posta adresine göre kullanıcıları getir
        var usersInProject = await projectService.GetProjectWithNonDeletedWithUsersWithTasksAsync(projectId);
        var users = usersInProject.ProjectAppUsers;

        var userDtos = users.Select(u => new
        {
            AppUserId = u.AppUser.Id,
            FullName = $"{u.AppUser.FirstName} {u.AppUser.LastName}",
            Email = u.AppUser.Email
        }).ToList();

        return Ok(userDtos);
    }

}
