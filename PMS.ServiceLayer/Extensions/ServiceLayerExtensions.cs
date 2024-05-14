using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PMS.ServiceLayer.FluentValidations;
using PMS.ServiceLayer.Services.Abstract;
using PMS.ServiceLayer.Services.Concrete;
using System.Globalization;
using System.Reflection;

namespace PMS.ServiceLayer.Extensions
{
    public static class ServiceLayerExtensions 
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

           

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(assembly);


            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<ProjectValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });

            return services;
        }
    }
}
