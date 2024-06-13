using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NToastNotify;
using PMS.DataLayer.Context;
using PMS.DataLayer.Extensions;
using PMS.ServiceLayer.Describers;
using PMS.ServiceLayer.Extensions;
using PMS_EntityLayer.Concrete;
using System;
using System.Net;
using System.Text.Json;

namespace PMS_WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddNToastNotifyToastr(new ToastrOptions()
                {
                    PositionClass = ToastPositions.TopRight,
                    TimeOut = 3000
                })
                .AddRazorRuntimeCompilation();


            services.LoadDataLayerExtension(Configuration);
            services.LoadServiceLayerExtension();

            services.AddSession();//Cookie

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
            })
                .AddRoleManager<RoleManager<AppRole>>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddEntityFrameworkStores<PMSDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config => //Cookie
            {
                config.LoginPath = new PathString("/Admin/Auth/Login");
                config.LogoutPath = new PathString("/Admin/Auth/Logout");
                config.Cookie = new CookieBuilder
                {
                    Name = "ProjectMenagmentSystem",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest // Can be Always on any Server Site
                };

                config.SlidingExpiration = true;
                config.ExpireTimeSpan = TimeSpan.FromDays(7);//Login Time
                config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
            });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            


            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
            app.UseNToastNotify();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();//Cookie
            app.UseRouting();

            app.UseAuthentication();//UseAuthorization her zaman daha altta kalmalýdýr.

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "ProjectManager",
                    areaName: "ProjectManager",
                    pattern: "ProjectManager/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapDefaultControllerRoute();
            });



        }
    }
}
