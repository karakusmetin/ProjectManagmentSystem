﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PMS.DataLayer.Context;

#nullable disable

namespace PMS.DataLayer.Migrations
{
    [DbContext(typeof(PMSDbContext))]
    [Migration("20240503140403_UserCreated")]
    partial class UserCreated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d4321afc-0323-4e31-b4b8-d07ce1efc8ed"),
                            ConcurrencyStamp = "9359a53e-83ca-46a3-b1ab-7c119cfdc13f",
                            Name = "Superadmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = new Guid("e8eafb80-8fdd-4faa-9395-ece1889d1636"),
                            ConcurrencyStamp = "a9d580dc-926f-43c5-8b3a-9d6ae74eeded",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("fe91ecf3-f094-477e-b956-3d895529ab32"),
                            ConcurrencyStamp = "193fc61a-3f9e-4ae1-9838-94ec2d6d6533",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d707abb-7379-421d-a35a-500b03f55ac7"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7f0fcad9-b52e-44eb-ad66-40e9e78a87ff",
                            Email = "superadmin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Metin",
                            LastName = "Karakuş",
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                            NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJTTOjgNJZdp5s9GKbk7Up84XeklCdfOMSYRB4ix1nPY0WkNxWfELzW4clcWohOcpA==",
                            PhoneNumber = "+9054399999999",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "942c6059-f945-4d02-8148-77e1f7946963",
                            TwoFactorEnabled = false,
                            UserName = "superadmin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("1d38a035-d954-4654-9466-25249903c517"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0618cd73-769d-48d3-af84-9ec9cb6732ff",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKF5VaHfhuMEQ8/SY/FDxBRQUJ/AvmmlQvaa3lAT/8oiMAT4LyNK/I8vk9PtnU6StA==",
                            PhoneNumber = "+9054399999988",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8ca56822-bf22-42c8-a1fb-461aaee7edca",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        });
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("8d707abb-7379-421d-a35a-500b03f55ac7"),
                            RoleId = new Guid("d4321afc-0323-4e31-b4b8-d07ce1efc8ed")
                        },
                        new
                        {
                            UserId = new Guid("1d38a035-d954-4654-9466-25249903c517"),
                            RoleId = new Guid("e8eafb80-8fdd-4faa-9395-ece1889d1636")
                        });
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Budget")
                        .HasColumnType("real");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InsertedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"),
                            Budget = 5000f,
                            Description = "Description",
                            EndDate = new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2125),
                            InsertDate = new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2124),
                            InsertedBy = "Admin",
                            IsActive = true,
                            Priority = 1,
                            ProjectName = "Project1",
                            StartDate = new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2125)
                        });
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.ProjectCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InsertedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b875e803-694c-4902-92ba-73db2337d73b"),
                            CategoryName = "Category1",
                            InsertDate = new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(1548),
                            InsertedBy = "Admin",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.ProjectManager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("EditerOrNot")
                        .HasColumnType("bit");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InsertedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("ProjectManagers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b175418c-cf5a-4ae9-8ddd-f7629cc555a3"),
                            EditerOrNot = false,
                            InsertDate = new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(1752),
                            InsertedBy = "Admin",
                            IsActive = true,
                            UserId = new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07")
                        });
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.ProjectUpdate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InsertedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdatedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectUpdates");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bda1bd0e-26b1-45b9-8f74-351e3bbdda3a"),
                            Content = "ExampleString",
                            InsertDate = new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2322),
                            InsertedBy = "Admin",
                            IsActive = true,
                            ProjectId = new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"),
                            Status = 1,
                            Type = 0,
                            UpdateDate = new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2325),
                            UpdatedUserId = new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07")
                        },
                        new
                        {
                            Id = new Guid("06ff9a10-025f-4810-9243-77821f74506b"),
                            Content = "ExampleString2",
                            InsertDate = new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2328),
                            InsertedBy = "Admin",
                            IsActive = true,
                            ProjectId = new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"),
                            Status = 1,
                            Type = 0,
                            UpdateDate = new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2330),
                            UpdatedUserId = new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07")
                        });
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppRoleClaim", b =>
                {
                    b.HasOne("PMS_EntityLayer.Concrete.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppUserClaim", b =>
                {
                    b.HasOne("PMS_EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppUserLogin", b =>
                {
                    b.HasOne("PMS_EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppUserRole", b =>
                {
                    b.HasOne("PMS_EntityLayer.Concrete.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PMS_EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppUserToken", b =>
                {
                    b.HasOne("PMS_EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.ProjectManager", b =>
                {
                    b.HasOne("PMS_EntityLayer.Concrete.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.ProjectUpdate", b =>
                {
                    b.HasOne("PMS_EntityLayer.Concrete.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("PMS.EntityLayer.Concrete.Project", "Project")
                        .WithMany("ProjectUpdates")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.Project", b =>
                {
                    b.Navigation("ProjectUpdates");
                });
#pragma warning restore 612, 618
        }
    }
}
