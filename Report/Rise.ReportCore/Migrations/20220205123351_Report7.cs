using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise.ReportCore.Migrations
{
    public partial class Report7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ReportFilePath",
                table: "ReportRequests",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Consts",
                columns: new[] { "Id", "CDate", "ConstDesc", "ConstID", "ConstOrder", "ConstValue", "Deleted", "MDate" },
                values: new object[,]
                {
                    { new Guid("05405072-76d6-4b7a-bf51-83cb8d000431"), new DateTimeOffset(new DateTime(2022, 2, 5, 15, 33, 50, 636, DateTimeKind.Unspecified).AddTicks(8460), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ReportInfoTypes", 0, "0", false, null },
                    { new Guid("1f07bab5-71d0-4a99-b1f1-8e5d21fe1c65"), new DateTimeOffset(new DateTime(2022, 2, 5, 15, 33, 50, 636, DateTimeKind.Unspecified).AddTicks(9524), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ReportInfoTypes", 1, "1", false, null },
                    { new Guid("7aed047e-1179-4a3f-92dd-5daba1947305"), new DateTimeOffset(new DateTime(2022, 2, 5, 15, 33, 50, 636, DateTimeKind.Unspecified).AddTicks(9539), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ReportInfoTypes", 2, "2", false, null },
                    { new Guid("31805228-b72a-46ad-90de-5f27dd22482d"), new DateTimeOffset(new DateTime(2022, 2, 5, 15, 33, 50, 636, DateTimeKind.Unspecified).AddTicks(9541), new TimeSpan(0, 3, 0, 0, 0)), "Preparing", "ReportStatus", 0, "0", false, null },
                    { new Guid("29d99423-31dd-4627-8d98-7fb95598349d"), new DateTimeOffset(new DateTime(2022, 2, 5, 15, 33, 50, 636, DateTimeKind.Unspecified).AddTicks(9543), new TimeSpan(0, 3, 0, 0, 0)), "Completed", "ReportStatus", 1, "1", false, null }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CDate", "Deleted", "MDate", "ReportID", "ReportName" },
                values: new object[] { new Guid("519ea9ad-d698-4b6f-819c-535ba27e351f"), new DateTimeOffset(new DateTime(2022, 2, 5, 15, 33, 50, 622, DateTimeKind.Unspecified).AddTicks(8107), new TimeSpan(0, 3, 0, 0, 0)), false, null, "00001", "Statistics of Contact by Location" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("05405072-76d6-4b7a-bf51-83cb8d000431"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("1f07bab5-71d0-4a99-b1f1-8e5d21fe1c65"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("29d99423-31dd-4627-8d98-7fb95598349d"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("31805228-b72a-46ad-90de-5f27dd22482d"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("7aed047e-1179-4a3f-92dd-5daba1947305"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("519ea9ad-d698-4b6f-819c-535ba27e351f"));

            migrationBuilder.DropColumn(
                name: "ReportFilePath",
                table: "ReportRequests");

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
    }
}
