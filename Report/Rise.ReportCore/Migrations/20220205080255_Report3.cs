using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise.ReportCore.Migrations
{
    public partial class Report3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("2687f90f-d768-488f-a949-7f32d8b13dcb"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("6b294bdc-bf6c-422d-8904-a1ee96bd9e2b"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("71011eb1-7341-44e5-899b-14ceba3bfa06"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("82cbc07a-4f0c-4ab5-ab5e-30dfa9e21a91"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("93495646-be1d-43c7-86fc-f3714e6e9e44"));

            migrationBuilder.AddColumn<string>(
                name: "ReportID",
                table: "Reports",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Consts",
                columns: new[] { "Id", "CDate", "ConstDesc", "ConstID", "ConstOrder", "ConstValue", "Deleted", "MDate" },
                values: new object[,]
                {
                    { new Guid("c6a72885-ac7b-4f42-a839-2b994aff5d8e"), new DateTimeOffset(new DateTime(2022, 2, 5, 11, 2, 55, 534, DateTimeKind.Unspecified).AddTicks(4973), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ReportInfoTypes", 0, "0", false, null },
                    { new Guid("2dfc02ca-c19a-4a7d-93b0-611fdf7fb79e"), new DateTimeOffset(new DateTime(2022, 2, 5, 11, 2, 55, 537, DateTimeKind.Unspecified).AddTicks(6454), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ReportInfoTypes", 1, "1", false, null },
                    { new Guid("2adeecf4-c899-48bd-b856-7dbf725f396c"), new DateTimeOffset(new DateTime(2022, 2, 5, 11, 2, 55, 537, DateTimeKind.Unspecified).AddTicks(6480), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ReportInfoTypes", 2, "2", false, null },
                    { new Guid("9da71206-335d-440d-8ed9-3263ad8009b9"), new DateTimeOffset(new DateTime(2022, 2, 5, 11, 2, 55, 537, DateTimeKind.Unspecified).AddTicks(6484), new TimeSpan(0, 3, 0, 0, 0)), "Preparing", "ReportStatus", 0, "0", false, null },
                    { new Guid("673e0cd0-d484-411b-802b-eb66d5222fb4"), new DateTimeOffset(new DateTime(2022, 2, 5, 11, 2, 55, 537, DateTimeKind.Unspecified).AddTicks(6487), new TimeSpan(0, 3, 0, 0, 0)), "Completed", "ReportStatus", 1, "1", false, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("2adeecf4-c899-48bd-b856-7dbf725f396c"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("2dfc02ca-c19a-4a7d-93b0-611fdf7fb79e"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("673e0cd0-d484-411b-802b-eb66d5222fb4"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("9da71206-335d-440d-8ed9-3263ad8009b9"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("c6a72885-ac7b-4f42-a839-2b994aff5d8e"));

            migrationBuilder.DropColumn(
                name: "ReportID",
                table: "Reports");

            migrationBuilder.InsertData(
                table: "Consts",
                columns: new[] { "Id", "CDate", "ConstDesc", "ConstID", "ConstOrder", "ConstValue", "Deleted", "MDate" },
                values: new object[,]
                {
                    { new Guid("82cbc07a-4f0c-4ab5-ab5e-30dfa9e21a91"), new DateTimeOffset(new DateTime(2022, 2, 5, 10, 29, 59, 658, DateTimeKind.Unspecified).AddTicks(1195), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ReportInfoTypes", 0, "0", false, null },
                    { new Guid("93495646-be1d-43c7-86fc-f3714e6e9e44"), new DateTimeOffset(new DateTime(2022, 2, 5, 10, 29, 59, 661, DateTimeKind.Unspecified).AddTicks(963), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ReportInfoTypes", 1, "1", false, null },
                    { new Guid("71011eb1-7341-44e5-899b-14ceba3bfa06"), new DateTimeOffset(new DateTime(2022, 2, 5, 10, 29, 59, 661, DateTimeKind.Unspecified).AddTicks(988), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ReportInfoTypes", 2, "2", false, null },
                    { new Guid("6b294bdc-bf6c-422d-8904-a1ee96bd9e2b"), new DateTimeOffset(new DateTime(2022, 2, 5, 10, 29, 59, 661, DateTimeKind.Unspecified).AddTicks(992), new TimeSpan(0, 3, 0, 0, 0)), "Preparing", "ReportStatus", 0, "0", false, null },
                    { new Guid("2687f90f-d768-488f-a949-7f32d8b13dcb"), new DateTimeOffset(new DateTime(2022, 2, 5, 10, 29, 59, 661, DateTimeKind.Unspecified).AddTicks(994), new TimeSpan(0, 3, 0, 0, 0)), "Completed", "ReportStatus", 1, "1", false, null }
                });
        }
    }
}
