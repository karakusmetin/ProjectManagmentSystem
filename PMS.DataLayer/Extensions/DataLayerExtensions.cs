using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMS.DataLayer.Context;
using PMS.DataLayer.Repositories.Abstracts;
using PMS.DataLayer.Repositories.Concretes;
using PMS.DataLayer.UnitOfWorks;

namespace PMS.DataLayer.Extensions
{
	public static class DataLayerExtensions
	{
		public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services,IConfiguration config) 
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddDbContext<PMSDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			return services;
		}
	}
}
	