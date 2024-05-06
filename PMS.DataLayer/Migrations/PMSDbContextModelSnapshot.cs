﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PMS.DataLayer.Context;

#nullable disable

namespace PMS.DataLayer.Migrations
{
    [DbContext(typeof(PMSDbContext))]
    partial class PMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppUserProject", b =>
                {
                    b.Property<Guid>("ManagedProjectsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectMembersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ManagedProjectsId", "ProjectMembersId");

                    b.HasIndex("ProjectMembersId");

                    b.ToTable("AppUserProject");
                });

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
                            ConcurrencyStamp = "c168ed48-3eb4-4521-977e-cb27fc79f952",
                            Name = "Superadmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = new Guid("e8eafb80-8fdd-4faa-9395-ece1889d1636"),
                            ConcurrencyStamp = "e3858054-5110-4eda-955e-7a714a37e3aa",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("fe91ecf3-f094-477e-b956-3d895529ab32"),
                            ConcurrencyStamp = "65171b01-4761-4256-a5af-66fa1884a1b0",
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

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

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

                    b.HasIndex("ImageId");

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
                            ConcurrencyStamp = "a98db96d-1525-4671-8090-11f3287987a6",
                            Email = "superadmin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Metin",
                            ImageId = new Guid("e8cda3ac-b6b3-48f7-8ee1-9ef2ca415ad5"),
                            LastName = "Karakuş",
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                            NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMLqYwUZJW7TfLytWoxQ9CZgH9oQiMzLdae8l8KDkmY3yqSgc5L2Buyb9jVRdQtBzQ==",
                            PhoneNumber = "+9054399999999",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "180a1625-0980-4d0b-81a5-2006c9aff144",
                            TwoFactorEnabled = false,
                            UserName = "superadmin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("1d38a035-d954-4654-9466-25249903c517"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2f504e24-ed57-4572-a991-28b5a16da27b",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            ImageId = new Guid("e8cda3ac-b6b3-48f7-8ee1-9ef2ca415ad5"),
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEN6XTdr3H9ggJG50xfWt53AGNzoDAMJsBtf5YS2GTHSqJGJSE17BXA7zJMh42vKCyw==",
                            PhoneNumber = "+9054399999988",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2aed90bf-f8bb-4bea-a28a-1397adb8b55c",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("10b0eb46-8482-415c-b5ac-bd6762d966fd"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "25519361-e0d2-4ddc-bd13-a3f79a341e85",
                            Email = "yasin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Yasin",
                            ImageId = new Guid("e8cda3ac-b6b3-48f7-8ee1-9ef2ca415ad5"),
                            LastName = "Ceyhun",
                            LockoutEnabled = false,
                            NormalizedEmail = "YASIN@GMAIL.COM",
                            NormalizedUserName = "YASIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMS7okb5uxUvV8yQ202zInX5b5tVVcYSrtSWENMAVVOYl2wGvPUo+NQecZVMQuoEug==",
                            PhoneNumber = "+905435555588",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b3e5b7ab-d67f-4ccb-827c-d124b567696e",
                            TwoFactorEnabled = false,
                            UserName = "yasin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("70f07528-20c1-46eb-a9b2-c5cd7007c0f2"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "eddf08ca-2b93-4eca-9a02-ee93eb64ff66",
                            Email = "samet@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Samet",
                            ImageId = new Guid("e8cda3ac-b6b3-48f7-8ee1-9ef2ca415ad5"),
                            LastName = "Yılmaz",
                            LockoutEnabled = false,
                            NormalizedEmail = "SAMET@GMAIL.COM",
                            NormalizedUserName = "SAMET@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEADiiwhfZMwXE0H68HIPi5JmsOevt1357oDUqZpqceVNCRigPpgkdRJfhWnvTsrN3w==",
                            PhoneNumber = "+905438888888",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f8da825f-4c08-4971-8c6e-1215a8aaf762",
                            TwoFactorEnabled = false,
                            UserName = "samet@gmail.com"
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

            modelBuilder.Entity("PMS_EntityLayer.Concrete.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FileType")
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("28e1ffaf-70df-4f04-964a-d1c27fedef70"),
                            FileName = "images/testimage",
                            FileType = "jpg",
                            InsertDate = new DateTime(2024, 5, 6, 18, 38, 22, 650, DateTimeKind.Local).AddTicks(4076),
                            InsertedBy = "Admin Test",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("e8cda3ac-b6b3-48f7-8ee1-9ef2ca415ad5"),
                            FileName = "images/VStestimage",
                            FileType = "png",
                            InsertDate = new DateTime(2024, 5, 6, 18, 38, 22, 650, DateTimeKind.Local).AddTicks(4082),
                            InsertedBy = "Admin Test",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssignedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

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

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("AssignedUserId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8078703d-1398-4833-8bcd-80b5efde8b21"),
                            AssignedUserId = new Guid("1d38a035-d954-4654-9466-25249903c517"),
                            Description = "Description",
                            EndDate = new DateTime(2024, 6, 6, 18, 38, 22, 651, DateTimeKind.Local).AddTicks(7731),
                            InsertDate = new DateTime(2024, 5, 6, 18, 38, 22, 651, DateTimeKind.Local).AddTicks(7720),
                            IsActive = false,
                            Priority = 1,
                            ProjectId = new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"),
                            StartDate = new DateTime(2024, 5, 6, 18, 38, 22, 651, DateTimeKind.Local).AddTicks(7731),
                            TaskName = "Görev1"
                        });
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.UserProject", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("UserProjects");
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

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InsertDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InsertedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid>("ProjectManagerId")
                        .HasColumnType("uniqueidentifier");

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

                    b.HasIndex("ImageId");

                    b.HasIndex("ProjectManagerId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"),
                            Budget = 5000f,
                            Description = "Description",
                            EndDate = new DateTime(2024, 5, 6, 18, 38, 22, 650, DateTimeKind.Local).AddTicks(5657),
                            ImageId = new Guid("28e1ffaf-70df-4f04-964a-d1c27fedef70"),
                            InsertDate = new DateTime(2024, 5, 6, 18, 38, 22, 650, DateTimeKind.Local).AddTicks(5656),
                            InsertedBy = "Admin",
                            IsActive = true,
                            Priority = 1,
                            ProjectManagerId = new Guid("b175418c-cf5a-4ae9-8ddd-f7629cc555a3"),
                            ProjectName = "Project1",
                            StartDate = new DateTime(2024, 5, 6, 18, 38, 22, 650, DateTimeKind.Local).AddTicks(5657)
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
                            InsertDate = new DateTime(2024, 5, 6, 18, 38, 22, 650, DateTimeKind.Local).AddTicks(4543),
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
                            InsertDate = new DateTime(2024, 5, 6, 18, 38, 22, 650, DateTimeKind.Local).AddTicks(4684),
                            InsertedBy = "Admin",
                            IsActive = true,
                            UserId = new Guid("8d707abb-7379-421d-a35a-500b03f55ac7")
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
                            InsertDate = new DateTime(2024, 5, 6, 18, 38, 22, 650, DateTimeKind.Local).AddTicks(5962),
                            InsertedBy = "Admin",
                            IsActive = true,
                            ProjectId = new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"),
                            Status = 1,
                            Type = 0,
                            UpdateDate = new DateTime(2024, 5, 6, 18, 38, 22, 650, DateTimeKind.Local).AddTicks(5964),
                            UpdatedUserId = new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07")
                        },
                        new
                        {
                            Id = new Guid("06ff9a10-025f-4810-9243-77821f74506b"),
                            Content = "ExampleString2",
                            InsertDate = new DateTime(2024, 5, 6, 18, 38, 22, 650, DateTimeKind.Local).AddTicks(5968),
                            InsertedBy = "Admin",
                            IsActive = true,
                            ProjectId = new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"),
                            Status = 1,
                            Type = 0,
                            UpdateDate = new DateTime(2024, 5, 6, 18, 38, 22, 650, DateTimeKind.Local).AddTicks(5969),
                            UpdatedUserId = new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07")
                        });
                });

            modelBuilder.Entity("AppUserProject", b =>
                {
                    b.HasOne("PMS.EntityLayer.Concrete.Project", null)
                        .WithMany()
                        .HasForeignKey("ManagedProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PMS_EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("ProjectMembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppRoleClaim", b =>
                {
                    b.HasOne("PMS_EntityLayer.Concrete.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppUser", b =>
                {
                    b.HasOne("PMS_EntityLayer.Concrete.Image", "Image")
                        .WithMany("Users")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
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

            modelBuilder.Entity("PMS_EntityLayer.Concrete.Task", b =>
                {
                    b.HasOne("PMS_EntityLayer.Concrete.AppUser", null)
                        .WithMany("Tasks")
                        .HasForeignKey("AppUserId");

                    b.HasOne("PMS_EntityLayer.Concrete.AppUser", "AssignedUser")
                        .WithMany()
                        .HasForeignKey("AssignedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PMS.EntityLayer.Concrete.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignedUser");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.UserProject", b =>
                {
                    b.HasOne("PMS.EntityLayer.Concrete.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PMS_EntityLayer.Concrete.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.Project", b =>
                {
                    b.HasOne("PMS_EntityLayer.Concrete.Image", "Image")
                        .WithMany("Projects")
                        .HasForeignKey("ImageId");

                    b.HasOne("PMS.EntityLayer.Concrete.ProjectManager", "ProjectManager")
                        .WithMany()
                        .HasForeignKey("ProjectManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("ProjectManager");
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

            modelBuilder.Entity("PMS_EntityLayer.Concrete.AppUser", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("PMS_EntityLayer.Concrete.Image", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.Project", b =>
                {
                    b.Navigation("ProjectUpdates");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
