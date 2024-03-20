using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMS.DataLayer.Repositories.Abstracts;
using PMS.DataLayer.Repositories.Concretes;

namespace PMS.DataLayer.Extensions
{
	public static class DataLayerExtensions
	{
		public static IServiceCollection LoadDataExtension(this IServiceCollection services,IConfiguration config) 
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			return services;
		}
	}
}
