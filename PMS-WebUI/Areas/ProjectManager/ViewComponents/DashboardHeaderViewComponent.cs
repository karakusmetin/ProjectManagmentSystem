using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS_EntityLayer.Concrete;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.ProjectManager.ViewComponents
{
    [ViewComponent(Name = "DashboardHeader")]
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;

        public DashboardHeaderViewComponent(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            var userWithImage = await userManager.Users
                .Include(u => u.Image)
                .FirstOrDefaultAsync(u => u.Id == loggedInUser.Id);
            return View(loggedInUser);
        }
    }
}
