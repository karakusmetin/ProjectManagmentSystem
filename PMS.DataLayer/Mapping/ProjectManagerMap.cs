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
				InsertedBy = "Data Seed",
				InsertDate = DateTime.Now,
				IsActive = true,
				AppUserId = Guid.Parse("10B0EB46-8482-415C-B5AC-BD6762D966FD")
            },
            new ProjectManager
            {
                Id = Guid.Parse("3544C5AD-48B8-43E7-AE9B-5702CF28F72C"),
                InsertedBy = "Data Seed",
                InsertDate = DateTime.Now,
                IsActive = true,
                AppUserId = Guid.Parse("70F07528-20C1-46EB-A9B2-C5CD7007C0F2")
            });
		}
	}
}

