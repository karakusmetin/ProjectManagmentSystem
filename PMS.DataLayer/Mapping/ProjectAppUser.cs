using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PMS_EntityLayer.Concrete;
using System.Reflection.Emit;

namespace PMS.DataLayer.Mapping
{
    public class ProjectAppUserMap : IEntityTypeConfiguration<ProjectAppUser>
    {
        public void Configure(EntityTypeBuilder<ProjectAppUser> builder)
        {
            builder.HasKey(pau => new { pau.ProjectId, pau.AppUserId });

            builder.HasOne(pau => pau.Project)
                .WithMany(p => p.ProjectAppUsers)
                .HasForeignKey(pau => pau.ProjectId);

            builder.HasOne(pau => pau.AppUser)
                .WithMany(au => au.ProjectAppUsers)
                .HasForeignKey(pau => pau.AppUserId);

        }
    }
}
