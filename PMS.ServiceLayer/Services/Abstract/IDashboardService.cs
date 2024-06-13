using PMS_EntityLayer.DTOs.Dashboard;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Abstract
{
    public interface IDashboardService
    {
        Task<TotalNumbersDto> GetTotalNumbersAsync();
        Task<DashboardPageDto> GetAllNumbersForGraphicsAsync();
        Task<List<ActivityDto>> GetRecentActivitiesAsync();
    }
}
