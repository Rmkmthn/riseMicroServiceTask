using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise.ContactCore.Migrations
{
    public partial class FK111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("5fdae715-c5a3-40cd-8a6d-95521fc017b4"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("6ca9bf49-f38d-4660-b6a3-86445890005f"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("e9769f62-b979-4380-a41e-28906c123852"));

            migrationBuilder.InsertData(
                table: "Consts",
                columns: new[] { "Id", "CDate", "ConstDesc", "ConstID", "ConstOrder", "ConstValue", "Deleted", "MDate" },
                values: new object[,]
                {
                    { new Guid("76d38e88-8c17-48e8-91f3-02e70f2be0ae"), new DateTimeOffset(new DateTime(2022, 2, 4, 23, 29, 58, 148, DateTimeKind.Unspecified).AddTicks(4866), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ContactInfoTypes", 0, "0", false, null },
                    { new Guid("550e991e-7924-41a7-bbee-6c23081ef621"), new DateTimeOffset(new DateTime(2022, 2, 4, 23, 29, 58, 151, DateTimeKind.Unspecified).AddTicks(6164), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ContactInfoTypes", 1, "1", false, null },
                    { new Guid("d05c4f53-b866-43c5-94a2-e8a981ffd1bf"), new DateTimeOffset(new DateTime(2022, 2, 4, 23, 29, 58, 151, DateTimeKind.Unspecified).AddTicks(6190), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ContactInfoTypes", 2, "2", false, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("550e991e-7924-41a7-bbee-6c23081ef621"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("76d38e88-8c17-48e8-91f3-02e70f2be0ae"));

            migrationBuilder.DeleteData(
                table: "Consts",
                keyColumn: "Id",
                keyValue: new Guid("d05c4f53-b866-43c5-94a2-e8a981ffd1bf"));

            migrationBuilder.InsertData(
                table: "Consts",
                columns: new[] { "Id", "CDate", "ConstDesc", "ConstID", "ConstOrder", "ConstValue", "Deleted", "MDate" },
                values: new object[,]
                {
                    { new Guid("6ca9bf49-f38d-4660-b6a3-86445890005f"), new DateTimeOffset(new DateTime(2022, 2, 4, 23, 25, 17, 489, DateTimeKind.Unspecified).AddTicks(3200), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ContactInfoTypes", 0, "0", false, null },
                    { new Guid("e9769f62-b979-4380-a41e-28906c123852"), new DateTimeOffset(new DateTime(2022, 2, 4, 23, 25, 17, 492, DateTimeKind.Unspecified).AddTicks(4204), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ContactInfoTypes", 1, "1", false, null },
                    { new Guid("5fdae715-c5a3-40cd-8a6d-95521fc017b4"), new DateTimeOffset(new DateTime(2022, 2, 4, 23, 25, 17, 492, DateTimeKind.Unspecified).AddTicks(4232), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ContactInfoTypes", 2, "2", false, null }
                });
        }
    }
}
