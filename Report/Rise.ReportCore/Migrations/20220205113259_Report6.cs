using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise.ReportCore.Migrations
{
    public partial class Report6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("537446cb-e43d-4061-b7f7-41d9e7078827"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("5dd8a6fa-1ba1-45fa-8742-03781512def4"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("ae9e9ec1-8cce-4e30-9700-67adbdbedeff"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("d119a2d4-d07d-4c3e-9e33-74725a962d4a"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("efd279aa-2dad-474d-b376-c000fc7d31f4"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("30d03483-9f8a-4cad-b2d1-5665652103b2"));

            migrationBuilder.InsertData(
                table: "Consts",
                columns: new[] { "Id", "CDate", "ConstDesc", "ConstID", "ConstOrder", "ConstValue", "Deleted", "MDate" },
                values: new object[,]
                {
                    { new Guid("d253ae3c-b753-48e2-adc3-d0e2900b104c"), new DateTimeOffset(new DateTime(2022, 2, 5, 14, 32, 59, 547, DateTimeKind.Unspecified).AddTicks(818), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ReportInfoTypes", 0, "0", false, null },
                    { new Guid("5cd23e23-4f6b-41e8-bdb9-d7d80da97427"), new DateTimeOffset(new DateTime(2022, 2, 5, 14, 32, 59, 547, DateTimeKind.Unspecified).AddTicks(1854), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ReportInfoTypes", 1, "1", false, null },
                    { new Guid("30a64bb5-0979-481c-b019-47a0e3c20ac6"), new DateTimeOffset(new DateTime(2022, 2, 5, 14, 32, 59, 547, DateTimeKind.Unspecified).AddTicks(1868), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ReportInfoTypes", 2, "2", false, null },
                    { new Guid("371dd2fb-2381-4855-9aee-ec62a9a4a489"), new DateTimeOffset(new DateTime(2022, 2, 5, 14, 32, 59, 547, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 3, 0, 0, 0)), "Preparing", "ReportStatus", 0, "0", false, null },
                    { new Guid("0382e2dc-240d-4b9e-b7ca-89f417ac7a89"), new DateTimeOffset(new DateTime(2022, 2, 5, 14, 32, 59, 547, DateTimeKind.Unspecified).AddTicks(1873), new TimeSpan(0, 3, 0, 0, 0)), "Completed", "ReportStatus", 1, "1", false, null }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CDate", "Deleted", "MDate", "ReportID", "ReportName" },
                values: new object[] { new Guid("c583d2e3-e479-4eed-b9b2-a539180a8ae2"), new DateTimeOffset(new DateTime(2022, 2, 5, 14, 32, 59, 533, DateTimeKind.Unspecified).AddTicks(6500), new TimeSpan(0, 3, 0, 0, 0)), false, null, "00001", "Statistics of Contact by Location" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("0382e2dc-240d-4b9e-b7ca-89f417ac7a89"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("30a64bb5-0979-481c-b019-47a0e3c20ac6"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("371dd2fb-2381-4855-9aee-ec62a9a4a489"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("5cd23e23-4f6b-41e8-bdb9-d7d80da97427"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("d253ae3c-b753-48e2-adc3-d0e2900b104c"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("c583d2e3-e479-4eed-b9b2-a539180a8ae2"));

            migrationBuilder.InsertData(
                table: "Consts",
                columns: new[] { "Id", "CDate", "ConstDesc", "ConstID", "ConstOrder", "ConstValue", "Deleted", "MDate" },
                values: new object[,]
                {
                    { new Guid("ae9e9ec1-8cce-4e30-9700-67adbdbedeff"), new DateTimeOffset(new DateTime(2022, 2, 5, 14, 29, 21, 444, DateTimeKind.Unspecified).AddTicks(7558), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ReportInfoTypes", 0, "0", false, null },
                    { new Guid("5dd8a6fa-1ba1-45fa-8742-03781512def4"), new DateTimeOffset(new DateTime(2022, 2, 5, 14, 29, 21, 444, DateTimeKind.Unspecified).AddTicks(8591), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ReportInfoTypes", 1, "1", false, null },
                    { new Guid("efd279aa-2dad-474d-b376-c000fc7d31f4"), new DateTimeOffset(new DateTime(2022, 2, 5, 14, 29, 21, 444, DateTimeKind.Unspecified).AddTicks(8605), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ReportInfoTypes", 2, "2", false, null },
                    { new Guid("537446cb-e43d-4061-b7f7-41d9e7078827"), new DateTimeOffset(new DateTime(2022, 2, 5, 14, 29, 21, 444, DateTimeKind.Unspecified).AddTicks(8607), new TimeSpan(0, 3, 0, 0, 0)), "Preparing", "ReportStatus", 0, "0", false, null },
                    { new Guid("d119a2d4-d07d-4c3e-9e33-74725a962d4a"), new DateTimeOffset(new DateTime(2022, 2, 5, 14, 29, 21, 444, DateTimeKind.Unspecified).AddTicks(8609), new TimeSpan(0, 3, 0, 0, 0)), "Completed", "ReportStatus", 1, "1", false, null }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CDate", "Deleted", "MDate", "ReportID", "ReportName" },
                values: new object[] { new Guid("30d03483-9f8a-4cad-b2d1-5665652103b2"), new DateTimeOffset(new DateTime(2022, 2, 5, 14, 29, 21, 431, DateTimeKind.Unspecified).AddTicks(1038), new TimeSpan(0, 3, 0, 0, 0)), false, null, "00001", "Statistics of Contact by Location" });
        }
    }
}
