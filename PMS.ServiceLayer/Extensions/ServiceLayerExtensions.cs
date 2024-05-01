using Microsoft.Extensions.DependencyInjection;
using PMS.ServiceLayer.Services.Abstract;
using PMS.ServiceLayer.Services.Concrete;
using System.Reflection;

namespace PMS.ServiceLayer.Extensions
{
    public static class ServiceLayerExtensions 
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IProjectService, ProjectService>();

            services.AddAutoMapper(assembly);
            return services;
        }
    }
}
