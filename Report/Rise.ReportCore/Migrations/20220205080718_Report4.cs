using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise.ReportCore.Migrations
{
    public partial class Report4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Consts",
                columns: new[] { "Id", "CDate", "ConstDesc", "ConstID", "ConstOrder", "ConstValue", "Deleted", "MDate" },
                values: new object[,]
                {
                    { new Guid("10ce7569-424b-4c8a-aaaa-e4d6862ed1bc"), new DateTimeOffset(new DateTime(2022, 2, 5, 11, 7, 18, 220, DateTimeKind.Unspecified).AddTicks(7337), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ReportInfoTypes", 0, "0", false, null },
                    { new Guid("ceb5d0ce-384e-4b6b-8daa-56164c33718a"), new DateTimeOffset(new DateTime(2022, 2, 5, 11, 7, 18, 220, DateTimeKind.Unspecified).AddTicks(8312), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ReportInfoTypes", 1, "1", false, null },
                    { new Guid("324ade75-b9cf-474f-96aa-de3b0ad37953"), new DateTimeOffset(new DateTime(2022, 2, 5, 11, 7, 18, 220, DateTimeKind.Unspecified).AddTicks(8326), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ReportInfoTypes", 2, "2", false, null },
                    { new Guid("cda80de6-12da-4a2f-abe6-8cad6954e8c6"), new DateTimeOffset(new DateTime(2022, 2, 5, 11, 7, 18, 220, DateTimeKind.Unspecified).AddTicks(8329), new TimeSpan(0, 3, 0, 0, 0)), "Preparing", "ReportStatus", 0, "0", false, null },
                    { new Guid("376f608d-97e2-4bfd-9271-69267bc277e9"), new DateTimeOffset(new DateTime(2022, 2, 5, 11, 7, 18, 220, DateTimeKind.Unspecified).AddTicks(8331), new TimeSpan(0, 3, 0, 0, 0)), "Completed", "ReportStatus", 1, "1", false, null }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CDate", "Deleted", "MDate", "ReportID", "ReportName" },
                values: new object[] { new Guid("3dc186b5-750f-4085-abd0-eb4ec385eebe"), new DateTimeOffset(new DateTime(2022, 2, 5, 11, 7, 18, 216, DateTimeKind.Unspecified).AddTicks(6617), new TimeSpan(0, 3, 0, 0, 0)), false, null, "00001", "Statistics of Contact by Location" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("10ce7569-424b-4c8a-aaaa-e4d6862ed1bc"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("324ade75-b9cf-474f-96aa-de3b0ad37953"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("376f608d-97e2-4bfd-9271-69267bc277e9"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("cda80de6-12da-4a2f-abe6-8cad6954e8c6"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("ceb5d0ce-384e-4b6b-8daa-56164c33718a"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("3dc186b5-750f-4085-abd0-eb4ec385eebe"));

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
    }
}
