using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS_EntityLayer.Concrete;
using System;

namespace PMS.DataLayer.Mapping
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            builder.ToTable("AspNetUsers");

            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();
            builder.Property(u => u.UserName).HasMaxLength(100);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            var superadmin = new AppUser
            {
                Id = Guid.Parse("8D707ABB-7379-421D-A35A-500B03F55AC7"),
                UserName = "superadmin@gmail.com",
                NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                Email = "superadmin@gmail.com",
                NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                PhoneNumber = "+9054399999999",
                FirstName = "Metin",
                LastName = "Karakuş",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                ImageId = Guid.Parse("BA09FD97-7832-4EBF-A065-B195D0900340"),
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            superadmin.PasswordHash = CreatePasswordHash(superadmin, "123456");

            var admin = new AppUser
            {
                Id = Guid.Parse("1D38A035-D954-4654-9466-25249903C517"),
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "+9054399999988",
                FirstName = "Admin",
                LastName = "User",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                ImageId = Guid.Parse("28E1FFAF-70DF-4F04-964A-D1C27FEDEF70"),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            admin.PasswordHash = CreatePasswordHash(admin, "123456");

            var user1 = new AppUser
            {
                Id = Guid.Parse("10B0EB46-8482-415C-B5AC-BD6762D966FD"),
                UserName = "yasin@gmail.com",
                NormalizedUserName = "YASIN@GMAIL.COM",
                Email = "yasin@gmail.com",
                NormalizedEmail = "YASIN@GMAIL.COM",
                PhoneNumber = "+905435555588",
                FirstName = "Yasin",
                LastName = "Ceyhun",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                ImageId = Guid.Parse("28E1FFAF-70DF-4F04-964A-D1C27FEDEF70"),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            user1.PasswordHash = CreatePasswordHash(user1, "123456");

            var user2 = new AppUser
            {
                Id = Guid.Parse("70F07528-20C1-46EB-A9B2-C5CD7007C0F2"),
                UserName = "samet@gmail.com",
                NormalizedUserName = "SAMET@GMAIL.COM",
                Email = "samet@gmail.com",
                NormalizedEmail = "SAMET@GMAIL.COM",
                PhoneNumber = "+905438888888",
                FirstName = "Samet",
                LastName = "Yılmaz",
                PhoneNumberConfirmed = false,
                ImageId = Guid.Parse("28E1FFAF-70DF-4F04-964A-D1C27FEDEF70"),
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            user2.PasswordHash = CreatePasswordHash(user2, "123456");

            builder.HasData(superadmin, admin, user1, user2);
        }

        private string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
