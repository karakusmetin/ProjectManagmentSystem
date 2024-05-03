using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMS.EntityLayer.Concrete;
using PMS_EntityLayer.Concrete;
using System;
using System.Reflection;


namespace PMS.DataLayer.Context
{
	public class PMSDbContext : IdentityDbContext<AppUser,AppRole,Guid,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>
	{
		protected PMSDbContext()
		{
		}
		public PMSDbContext(DbContextOptions<PMSDbContext> options) : base(options)
		{
		}

		public DbSet<Project> Projects { get; set; }
		public DbSet<ProjectCategory> ProjectCategories { get; set; }
		public DbSet<ProjectManager> ProjectManagers { get; set; }
		public DbSet<ProjectUpdate> ProjectUpdates { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
