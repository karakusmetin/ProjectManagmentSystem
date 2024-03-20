using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.EntityLayer.Concrete;
using System;

namespace PMS.DataLayer.Mapping
{
	public class ProjectManagerMap : IEntityTypeConfiguration<ProjectManager>
	{
		public void Configure(EntityTypeBuilder<ProjectManager> builder)
		{
			builder.HasData(new ProjectManager
			{
				Id = Guid.Parse("B175418C-CF5A-4AE9-8DDD-F7629CC555A3"),
				InsertedBy = "Admin",
				InsertDate = DateTime.Now,
				IsActive = true,
				UserId = Guid.Parse("9B9217BB-BA94-4C2F-B57E-2A4450C60F07")

			});
		}
	}
}

