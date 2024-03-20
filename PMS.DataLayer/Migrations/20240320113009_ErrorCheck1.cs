using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMS.DataLayer.Migrations
{
    public partial class ErrorCheck1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07"),
                column: "InsertDate",
                value: new DateTime(2024, 3, 20, 14, 30, 9, 349, DateTimeKind.Local).AddTicks(6196));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProjectCategories",
                keyColumn: "Id",
                keyValue: new Guid("b875e803-694c-4902-92ba-73db2337d73b"),
                column: "InsertDate",
                value: new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "ProjectManagers",
                keyColumn: "Id",
                keyValue: new Guid("b175418c-cf5a-4ae9-8ddd-f7629cc555a3"),
                column: "InsertDate",
                value: new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "ProjectUpdates",
                keyColumn: "Id",
                keyValue: new Guid("06ff9a10-025f-4810-9243-77821f74506b"),
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(5019), new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(5021) });

            migrationBuilder.UpdateData(
                table: "ProjectUpdates",
                keyColumn: "Id",
                keyValue: new Guid("bda1bd0e-26b1-45b9-8f74-351e3bbdda3a"),
                columns: new[] { "InsertDate", "UpdateDate" },
                values: new object[] { new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(5013), new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(5016) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("321599bd-3833-400a-a939-8b53dd7bd57a"),
                columns: new[] { "EndDate", "InsertDate", "StartDate" },
                values: new object[] { new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(4816), new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(4814), new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(4816) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9b9217bb-ba94-4c2f-b57e-2a4450c60f07"),
                column: "InsertDate",
                value: new DateTime(2024, 3, 20, 12, 39, 48, 27, DateTimeKind.Local).AddTicks(5657));
        }
    }
}
