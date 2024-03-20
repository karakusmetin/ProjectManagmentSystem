using Microsoft.EntityFrameworkCore;
using PMS.EntityLayer.Concrete;


namespace PMS.DataLayer.Context
{
	public class PMSDbContext : DbContext
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
		public DbSet<User> Users { get; set; }

	}
}
