using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.EntityLayer.Concrete;
using System;
using System.Reflection.Metadata;

namespace PMS.DataLayer.Mapping
{
	public class ProjectUpdateMap : IEntityTypeConfiguration<ProjectUpdate>
	{
		public void Configure(EntityTypeBuilder<ProjectUpdate> builder)
		{
			builder.Property(x=>x.Content).HasMaxLength(100);

			builder.HasData(new ProjectUpdate
			{
				Id = Guid.Parse("BDA1BD0E-26B1-45B9-8F74-351E3BBDDA3A"),
				InsertedBy = "Admin",
				InsertDate = DateTime.Now,
				IsActive = true,
				ProjectId= Guid.Parse("321599BD-3833-400A-A939-8B53DD7BD57A"),
				UpdatedUserId=Guid.Parse("9B9217BB-BA94-4C2F-B57E-2A4450C60F07"),
				UpdateDate=DateTime.Now,
				Content="ExampleString",
				Type= EntityLayer.Enums.UpdateType.Progress,
				Status= EntityLayer.Enums.TaskUpdateStatus.InProgress


			},new ProjectUpdate
			{
				Id = Guid.Parse("06FF9A10-025F-4810-9243-77821F74506B"),
				InsertedBy = "Admin",
				InsertDate = DateTime.Now,
				IsActive = true,
				ProjectId = Guid.Parse("321599BD-3833-400A-A939-8B53DD7BD57A"),
				UpdatedUserId = Guid.Parse("9B9217BB-BA94-4C2F-B57E-2A4450C60F07"),
				UpdateDate = DateTime.Now,
				Content = "ExampleString2",
				Type = EntityLayer.Enums.UpdateType.Progress,
				Status = EntityLayer.Enums.TaskUpdateStatus.InProgress


			});
		}
	}
}
