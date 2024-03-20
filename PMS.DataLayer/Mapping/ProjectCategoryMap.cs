using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.EntityLayer.Concrete;
using System;

namespace PMS.DataLayer.Mapping
{
	public class ProjectCategoryMap : IEntityTypeConfiguration<ProjectCategory>
	{
		public void Configure(EntityTypeBuilder<ProjectCategory> builder)
		{
			builder.Property(x=>x.CategoryName).IsRequired().HasMaxLength(50);

			builder.HasData(new ProjectCategory
			{
				Id = Guid.Parse("B875E803-694C-4902-92BA-73DB2337D73B"),
				InsertedBy = "Admin",
				InsertDate = DateTime.Now,
				IsActive = true,
				CategoryName = "Category1",

			});
		}
	}
}
