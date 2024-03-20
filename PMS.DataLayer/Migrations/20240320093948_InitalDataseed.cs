using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMS.DataLayer.Migrations
{
    public partial class InitalDataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsertedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Budget = table.Column<float>(type: "real", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    InsertedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserLastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InsertedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectManagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EditerOrNot = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsertedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectManagers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUpdates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    InsertedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUpdates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectUpdates_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUpdates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ProjectCategories",
                columns: new[] { "Id", "CategoryName", "DeletedBy", "DeletedDate", "InsertDate", "InsertedBy", "IsActive", "UpdateDate", "UpdatedBy" },
                values: new object[] { new Guid("b875e803-694c-4902-92ba-73db2337d73b"), "Category1", null, null, new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(4123), "Admin", true, null, null });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Budget", "DeletedBy", "DeletedDate", "Description", "EndDate", "InsertDate", "InsertedBy", "IsActive", "Priority", "ProjectName", "StartDate", "UpdateDate", "UpdatedBy" },
                values: new object[] { new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"), 5000f, null, null, "Description", new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(4816), new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(4814), "Admin", true, 1, "Project1", new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(4816), null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeletedBy", "DeletedDate", "InsertDate", "InsertedBy", "IsActive", "UpdateDate", "UpdatedBy", "UserEmail", "UserLastName", "UserName" },
                values: new object[] { new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07"), null, null, new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(5657), "Admin", true, null, null, "admin@gmail.com", "Karakuş", "Metin" });

            migrationBuilder.InsertData(
                table: "ProjectManagers",
                columns: new[] { "Id", "DeletedBy", "DeletedDate", "EditerOrNot", "InsertDate", "InsertedBy", "IsActive", "UpdateDate", "UpdatedBy", "UserId" },
                values: new object[] { new Guid("b175418c-cf5a-4ae9-8ddd-f7629cc555a3"), null, null, false, new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(4530), "Admin", true, null, null, new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07") });

            migrationBuilder.InsertData(
                table: "ProjectUpdates",
                columns: new[] { "Id", "Content", "DeletedBy", "DeletedDate", "InsertDate", "InsertedBy", "IsActive", "ProjectId", "Status", "Type", "UpdateDate", "UpdatedBy", "UpdatedUserId", "UserId" },
                values: new object[] { new Guid("06ff9a10-025f-4810-9243-77821f74506b"), "ExampleString2", null, null, new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(5019), "Admin", true, new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"), 1, 0, new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(5021), null, new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07"), null });

            migrationBuilder.InsertData(
                table: "ProjectUpdates",
                columns: new[] { "Id", "Content", "DeletedBy", "DeletedDate", "InsertDate", "InsertedBy", "IsActive", "ProjectId", "Status", "Type", "UpdateDate", "UpdatedBy", "UpdatedUserId", "UserId" },
                values: new object[] { new Guid("bda1bd0e-26b1-45b9-8f74-351e3bbdda3a"), "ExampleString", null, null, new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(5013), "Admin", true, new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"), 1, 0, new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(5016), null, new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07"), null });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManagers_UserId",
                table: "ProjectManagers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUpdates_ProjectId",
                table: "ProjectUpdates",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUpdates_UserId",
                table: "ProjectUpdates",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectCategories");

            migrationBuilder.DropTable(
                name: "ProjectManagers");

            migrationBuilder.DropTable(
                name: "ProjectUpdates");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
