using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMS.DataLayer.Migrations
{
    public partial class UserCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectManagers_Users_UserId",
                table: "ProjectManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUpdates_Users_UserId",
                table: "ProjectUpdates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ProjectManagers_UserId",
                table: "ProjectManagers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ProjectUpdates",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectUpdates_UserId",
                table: "ProjectUpdates",
                newName: "IX_ProjectUpdates_AppUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "ProjectManagers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("d4321afc-0323-4e31-b4b8-d07ce1efc8ed"), "9359a53e-83ca-46a3-b1ab-7c119cfdc13f", "Superadmin", "SUPERADMIN" },
                    { new Guid("e8eafb80-8fdd-4faa-9395-ece1889d1636"), "a9d580dc-926f-43c5-8b3a-9d6ae74eeded", "Admin", "ADMIN" },
                    { new Guid("fe91ecf3-f094-477e-b956-3d895529ab32"), "193fc61a-3f9e-4ae1-9838-94ec2d6d6533", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1d38a035-d954-4654-9466-25249903c517"), 0, "0618cd73-769d-48d3-af84-9ec9cb6732ff", "admin@gmail.com", false, "Admin", "User", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEKF5VaHfhuMEQ8/SY/FDxBRQUJ/AvmmlQvaa3lAT/8oiMAT4LyNK/I8vk9PtnU6StA==", "+9054399999988", false, "8ca56822-bf22-42c8-a1fb-461aaee7edca", false, "admin@gmail.com" },
                    { new Guid("8d707abb-7379-421d-a35a-500b03f55ac7"), 0, "7f0fcad9-b52e-44eb-ad66-40e9e78a87ff", "superadmin@gmail.com", true, "Metin", "Karakuş", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEJTTOjgNJZdp5s9GKbk7Up84XeklCdfOMSYRB4ix1nPY0WkNxWfELzW4clcWohOcpA==", "+9054399999999", true, "942c6059-f945-4d02-8148-77e1f7946963", false, "superadmin@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "ProjectCategories",
                keyColumn: "Id",
                keyValue: new Guid("b875e803-694c-4902-92ba-73db2337d73b"),
                column: "InsertDate",
                value: new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "ProjectManagers",
                keyColumn: "Id",
                keyValue: new Guid("b175418c-cf5a-4ae9-8ddd-f7629cc555a3"),
                column: "InsertDate",
                value: new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(1752));

            migrationBuilder.UpdateData(
                table: "ProjectUpdates",
                keyColumn: "Id",
                keyValue: new Guid("06ff9a10-025f-4810-9243-77821f74506b"),
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2328), new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "ProjectUpdates",
                keyColumn: "Id",
                keyValue: new Guid("bda1bd0e-26b1-45b9-8f74-351e3bbdda3a"),
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2322), new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2325) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"),
                columns: new[] { "EndDate", "InsertDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2125), new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2124), new DateTime(2024, 5, 3, 17, 4, 2, 466, DateTimeKind.Local).AddTicks(2125) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("e8eafb80-8fdd-4faa-9395-ece1889d1636"), new Guid("1d38a035-d954-4654-9466-25249903c517") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("d4321afc-0323-4e31-b4b8-d07ce1efc8ed"), new Guid("8d707abb-7379-421d-a35a-500b03f55ac7") });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManagers_AppUserId",
                table: "ProjectManagers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectManagers_AspNetUsers_AppUserId",
                table: "ProjectManagers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUpdates_AspNetUsers_AppUserId",
                table: "ProjectUpdates",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectManagers_AspNetUsers_AppUserId",
                table: "ProjectManagers");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUpdates_AspNetUsers_AppUserId",
                table: "ProjectUpdates");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectManagers_AppUserId",
                table: "ProjectManagers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ProjectManagers");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ProjectUpdates",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectUpdates_AppUserId",
                table: "ProjectUpdates",
                newName: "IX_ProjectUpdates_UserId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserLastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ProjectCategories",
                keyColumn: "Id",
                keyValue: new Guid("b875e803-694c-4902-92ba-73db2337d73b"),
                column: "InsertDate",
                value: new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(4999));

            migrationBuilder.UpdateData(
                table: "ProjectManagers",
                keyColumn: "Id",
                keyValue: new Guid("b175418c-cf5a-4ae9-8ddd-f7629cc555a3"),
                column: "InsertDate",
                value: new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5288));

            migrationBuilder.UpdateData(
                table: "ProjectUpdates",
                keyColumn: "Id",
                keyValue: new Guid("06ff9a10-025f-4810-9243-77821f74506b"),
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5785), new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5786) });

            migrationBuilder.UpdateData(
                table: "ProjectUpdates",
                keyColumn: "Id",
                keyValue: new Guid("bda1bd0e-26b1-45b9-8f74-351e3bbdda3a"),
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5778), new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5781) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"),
                columns: new[] { "EndDate", "InsertDate", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5529), new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5528), new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(5529) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeletedBy", "DeletedDate", "InsertDate", "InsertedBy", "IsActive", "UpdateDate", "UpdatedBy", "UserEmail", "UserLastName", "UserName" },
                values: new object[] { new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07"), null, null, new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(6196), "Admin", true, null, null, "admin@gmail.com", "Karakuş", "Metin" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManagers_UserId",
                table: "ProjectManagers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectManagers_Users_UserId",
                table: "ProjectManagers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUpdates_Users_UserId",
                table: "ProjectUpdates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
