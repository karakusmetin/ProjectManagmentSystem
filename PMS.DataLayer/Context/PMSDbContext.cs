using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMS.DataLayer.Mapping;
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

		public DbSet<Image> Images { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<ProjectAppUser> ProjectAppUsers { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Document> Documents { get; set; }
		public DbSet<ProjectManager> ProjectManagers { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProjectAppUser>()
           .HasKey(pau => new { pau.ProjectId, pau.AppUserId });

            modelBuilder.Entity<ProjectAppUser>()
                .HasOne(pau => pau.Project)
                .WithMany(p => p.ProjectAppUsers)
                .HasForeignKey(pau => pau.ProjectId);

            modelBuilder.Entity<ProjectAppUser>()
                .HasOne(pau => pau.AppUser)
                .WithMany(au => au.ProjectAppUsers)
                .HasForeignKey(pau => pau.AppUserId);

            
            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectManager)
                .WithMany()
                .HasForeignKey(p => p.ProjectManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
