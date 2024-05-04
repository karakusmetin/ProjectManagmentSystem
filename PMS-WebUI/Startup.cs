using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PMS.DataLayer.Context;
using PMS.DataLayer.Extensions;
using PMS.ServiceLayer.Extensions;
using PMS_EntityLayer.Concrete;
using System;

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
			services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
					SecurePolicy = CookieSecurePolicy.SameAsRequest // Site canl�ya ��k�nca Always olmal�
				};

				config.SlidingExpiration = true;
				config.ExpireTimeSpan = TimeSpan.FromDays(7);//Login kalma s�resi
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
			app.UseHttpsRedirection();
			app.UseStaticFiles();

            app.UseSession();//Cookie
            app.UseRouting();

			app.UseAuthentication();//UseAuthorization her zaman daha altta kalmal�d�r.

            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
			{
				endpoints.MapAreaControllerRoute(
					name: "Admin",
					areaName: "Admin",
					pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

				endpoints.MapDefaultControllerRoute();

			});

            

		}
	}
}
