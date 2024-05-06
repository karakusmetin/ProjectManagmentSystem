using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PMS_EntityLayer.Concrete;

namespace PMS.DataLayer.Mapping
{
    public class AppUserProjectMap : IEntityTypeConfiguration<UserProject>
    {
        public void Configure(EntityTypeBuilder<UserProject> builder)
        {
            builder.HasKey(x => new { x.UserId, x.ProjectId });

            builder.HasOne(x => x.AppUser)
                .WithMany()
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Project)
                .WithMany()
                .HasForeignKey(x => x.ProjectId);
        }
    }
}
