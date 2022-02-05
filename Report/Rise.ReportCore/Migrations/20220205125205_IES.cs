using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise.ReportCore.Migrations
{
    public partial class IES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Consts",
                columns: new[] { "Id", "CDate", "ConstDesc", "ConstID", "ConstOrder", "ConstValue", "Deleted", "MDate" },
                values: new object[,]
                {
                    { new Guid("40ba53bd-d70c-42af-9840-00270e22fa36"), new DateTimeOffset(new DateTime(2022, 2, 5, 15, 52, 4, 809, DateTimeKind.Unspecified).AddTicks(4648), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ReportInfoTypes", 0, "0", false, null },
                    { new Guid("f6ffa81f-bb81-4e8c-95df-1a1a8e1f1824"), new DateTimeOffset(new DateTime(2022, 2, 5, 15, 52, 4, 809, DateTimeKind.Unspecified).AddTicks(5677), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ReportInfoTypes", 1, "1", false, null },
                    { new Guid("caf28f04-1f16-4893-a477-08d92812a8e8"), new DateTimeOffset(new DateTime(2022, 2, 5, 15, 52, 4, 809, DateTimeKind.Unspecified).AddTicks(5691), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ReportInfoTypes", 2, "2", false, null },
                    { new Guid("5e8baeef-4d07-4354-8560-27f36cc8f82a"), new DateTimeOffset(new DateTime(2022, 2, 5, 15, 52, 4, 809, DateTimeKind.Unspecified).AddTicks(5694), new TimeSpan(0, 3, 0, 0, 0)), "Preparing", "ReportStatus", 0, "0", false, null },
                    { new Guid("387fbbf2-8d4c-4f7f-a7f8-e13359f86ff4"), new DateTimeOffset(new DateTime(2022, 2, 5, 15, 52, 4, 809, DateTimeKind.Unspecified).AddTicks(5696), new TimeSpan(0, 3, 0, 0, 0)), "Completed", "ReportStatus", 1, "1", false, null }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CDate", "Deleted", "MDate", "ReportID", "ReportName" },
                values: new object[] { new Guid("8476ef19-bf02-430d-a6cf-8ffb3d1612a8"), new DateTimeOffset(new DateTime(2022, 2, 5, 15, 52, 4, 795, DateTimeKind.Unspecified).AddTicks(5121), new TimeSpan(0, 3, 0, 0, 0)), false, null, "00001", "Statistics of Contact by Location" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("387fbbf2-8d4c-4f7f-a7f8-e13359f86ff4"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("40ba53bd-d70c-42af-9840-00270e22fa36"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("5e8baeef-4d07-4354-8560-27f36cc8f82a"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("caf28f04-1f16-4893-a477-08d92812a8e8"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("f6ffa81f-bb81-4e8c-95df-1a1a8e1f1824"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("8476ef19-bf02-430d-a6cf-8ffb3d1612a8"));

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
    }
}
