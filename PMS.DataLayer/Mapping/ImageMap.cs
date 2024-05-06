using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS_EntityLayer.Concrete;
using System;

namespace PMS.DataLayer.Mapping
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.FileName).HasMaxLength(50);

            builder.HasData(new Image
            {
                Id = Guid.Parse("28E1FFAF-70DF-4F04-964A-D1C27FEDEF70"),
                FileName = "images/testimage",
                FileType = "jpg",
                InsertedBy = "Admin Test",
                InsertDate = DateTime.Now,
                IsActive = true,
            },
            new Image
            {
                Id = Guid.Parse("E8CDA3AC-B6B3-48F7-8EE1-9EF2CA415AD5"),
                FileName = "images/VStestimage",
                FileType = "png",
                InsertedBy = "Admin Test",
                InsertDate = DateTime.Now,
                IsActive = true,
            });
        }
    }
}
