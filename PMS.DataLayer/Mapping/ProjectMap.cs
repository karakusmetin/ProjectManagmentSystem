using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.EntityLayer.Concrete;
using PMS_EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace PMS.DataLayer.Mapping
{
	public class ProjectMap : IEntityTypeConfiguration<Project>
	{
		public void Configure(EntityTypeBuilder<Project> builder)
		{
			builder.Property(x => x.ProjectName).HasMaxLength(30);
			builder.Property(x => x.Description).HasMaxLength(150);

            builder.HasOne(p => p.ProjectManager)
               .WithMany()
               .HasForeignKey(p => p.ProjectManagerId)
               .IsRequired();

            

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
				Priority=EntityLayer.Enums.PriorityLevel.Medium,
                ImageId = Guid.Parse("28E1FFAF-70DF-4F04-964A-D1C27FEDEF70"),
                ProjectManagerId = Guid.Parse("B175418C-CF5A-4AE9-8DDD-F7629CC555A3"),

            });

            var appUserProjects = new List<UserProject>
            {
                new UserProject { UserId = Guid.Parse("8D707ABB-7379-421D-A35A-500B03F55AC7"),
                               ProjectId = Guid.Parse("321599BD-3833-400A-A939-8B53DD7BD57A") },
                
                new UserProject { UserId = Guid.Parse("10B0EB46-8482-415C-B5AC-BD6762D966FD"), 
                               ProjectId = Guid.Parse("321599BD-3833-400A-A939-8B53DD7BD57A") }
            };

        }
        private string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
