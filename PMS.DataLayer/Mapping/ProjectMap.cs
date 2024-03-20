using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.EntityLayer.Concrete;
using System;

namespace PMS.DataLayer.Mapping
{
	public class ProjectMap : IEntityTypeConfiguration<Project>
	{
		public void Configure(EntityTypeBuilder<Project> builder)
		{
			builder.Property(x => x.ProjectName).HasMaxLength(30);
			builder.Property(x => x.Description).HasMaxLength(150);

			builder.HasData(new Project
			{
				Id = Guid.Parse("321599BD-3833-400A-A939-8B53DD7BD57A"),
				InsertedBy = "Admin",
				InsertDate = DateTime.Now,
				IsActive = true,
				ProjectName = "Project1",
				Description = "Description",
				StartDate = DateTime.Now,
				EndDate = DateTime.Now,
				Budget=5000,
				Priority=EntityLayer.Enums.PriorityLevel.Medium

			});
		}
	}
}
