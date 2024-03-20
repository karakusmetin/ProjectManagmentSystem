using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.EntityLayer.Concrete;
using System;

namespace PMS.DataLayer.Mapping
{
	public class UserMap : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(x=>x.UserEmail).IsRequired().HasMaxLength(50);
			builder.Property(x=>x.UserLastName).IsRequired().HasMaxLength(30);
			builder.Property(x=>x.UserName).IsRequired().HasMaxLength(40);

			builder.HasData(new User
			{
				Id = Guid.Parse("9B9217BB-BA94-4C2F-B57E-2A4450C60F07"),
				InsertedBy = "Admin",
				InsertDate = DateTime.Now,
				IsActive = true,
				UserName="Metin",
				UserLastName="Karakuş",
				UserEmail="admin@gmail.com"
				
			});
		}
	}
}
