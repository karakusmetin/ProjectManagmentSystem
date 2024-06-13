using Microsoft.AspNetCore.Mvc;
using PMS.ServiceLayer.Services.Abstract;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.ProjectManager.ViewComponents
{
    [ViewComponent(Name = "TotalNumbers")]
    public class TotalNumbersViewComponent : ViewComponent
    {
        private readonly IDashboardService dashboardService;

        public TotalNumbersViewComponent(IDashboardService dashboardService) 
        {
            this.dashboardService = dashboardService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var numbers = await dashboardService.GetTotalNumbersAsync();
            return View(numbers);
        }
    }
}
