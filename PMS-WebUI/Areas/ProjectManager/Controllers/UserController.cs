using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS.ServiceLayer.Services.Abstract;
using PMS.ServiceLayer.Services.Concrete;
using PMS_EntityLayer.Concrete;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IProjectManagerService projectManagerService;

    public UsersController(UserManager<AppUser> userManager,IProjectManagerService projectManagerService)
    {
        _userManager = userManager;
        this.projectManagerService = projectManagerService;
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
}
