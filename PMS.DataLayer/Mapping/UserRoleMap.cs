﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS_EntityLayer.Concrete;
using System;

namespace PMS.DataLayer.Mapping
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("8D707ABB-7379-421D-A35A-500B03F55AC7"),
                RoleId = Guid.Parse("D4321AFC-0323-4E31-B4B8-D07CE1EFC8ED")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("1D38A035-D954-4654-9466-25249903C517"),
                RoleId = Guid.Parse("492F344E-4BA6-485B-A3F1-73219B3E61C9")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("10B0EB46-8482-415C-B5AC-BD6762D966FD"),
                RoleId = Guid.Parse("E8EAFB80-8FDD-4FAA-9395-ECE1889D1636")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("70F07528-20C1-46EB-A9B2-C5CD7007C0F2"),
                RoleId = Guid.Parse("FE91ECF3-F094-477E-B956-3D895529AB32")
            });

        }
    }
}
