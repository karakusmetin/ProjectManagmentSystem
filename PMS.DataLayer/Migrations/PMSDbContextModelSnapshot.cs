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
                            EndDate = new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5529),
                            InsertDate = new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5528),
                            InsertedBy = "Admin",
                            IsActive = true,
                            Priority = 1,
                            ProjectName = "Project1",
                            StartDate = new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5529)
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
                            InsertDate = new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(4999),
                            InsertedBy = "Admin",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.ProjectManager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.HasIndex("UserId");

                    b.ToTable("ProjectManagers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b175418c-cf5a-4ae9-8ddd-f7629cc555a3"),
                            EditerOrNot = false,
                            InsertDate = new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5288),
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

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectUpdates");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bda1bd0e-26b1-45b9-8f74-351e3bbdda3a"),
                            Content = "ExampleString",
                            InsertDate = new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5778),
                            InsertedBy = "Admin",
                            IsActive = true,
                            ProjectId = new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"),
                            Status = 1,
                            Type = 0,
                            UpdateDate = new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5781),
                            UpdatedUserId = new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07")
                        },
                        new
                        {
                            Id = new Guid("06ff9a10-025f-4810-9243-77821f74506b"),
                            Content = "ExampleString2",
                            InsertDate = new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5785),
                            InsertedBy = "Admin",
                            IsActive = true,
                            ProjectId = new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"),
                            Status = 1,
                            Type = 0,
                            UpdateDate = new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5786),
                            UpdatedUserId = new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07")
                        });
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserLastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07"),
                            InsertDate = new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(6196),
                            InsertedBy = "Admin",
                            IsActive = true,
                            UserEmail = "admin@gmail.com",
                            UserLastName = "Karakuş",
                            UserName = "Metin"
                        });
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.ProjectManager", b =>
                {
                    b.HasOne("PMS.EntityLayer.Concrete.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.ProjectUpdate", b =>
                {
                    b.HasOne("PMS.EntityLayer.Concrete.Project", "Project")
                        .WithMany("ProjectUpdates")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PMS.EntityLayer.Concrete.User", "User")
                        .WithMany("ProjectUpdates")
                        .HasForeignKey("UserId");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.Project", b =>
                {
                    b.Navigation("ProjectUpdates");
                });

            modelBuilder.Entity("PMS.EntityLayer.Concrete.User", b =>
                {
                    b.Navigation("ProjectUpdates");
                });
#pragma warning restore 612, 618
        }
    }
}
