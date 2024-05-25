using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS_EntityLayer.Concrete;
using System;
using System.IO;

namespace PMS.DataLayer.Mapping
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(x => x.FileName).HasMaxLength(25);

            builder.HasData(new Image
            {
                Id = Guid.Parse("BA09FD97-7832-4EBF-A065-B195D0900340"),
                FileName = "images/testimage1",
                ImageData = GetImageData("image1.png"),
                InsertedBy = "Data Seed",
                InsertDate = DateTime.Now,
                IsActive = true
            },
            new Image
            {
                Id = Guid.Parse("28E1FFAF-70DF-4F04-964A-D1C27FEDEF70"),
                FileName = "images/testimage1",
                ImageData = GetImageData("image1.png"),
                InsertedBy = "Data Seed",
                InsertDate = DateTime.Now,
                IsActive = true
            });
        }

        public byte[] GetImageData(string imageName)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageName);
            return File.Exists(imagePath) ? File.ReadAllBytes(imagePath) : null;
        }
    }
}
