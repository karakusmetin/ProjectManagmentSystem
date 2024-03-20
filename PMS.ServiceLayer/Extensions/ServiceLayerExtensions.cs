using Microsoft.Extensions.DependencyInjection;
using PMS.ServiceLayer.Services.Abstract;
using PMS.ServiceLayer.Services.Concrete;

namespace PMS.ServiceLayer.Extensions
{
    public static class ServiceLayerExtensions 
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            return services;
        }
    }
}
