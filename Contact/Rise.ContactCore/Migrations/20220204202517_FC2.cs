using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise.ContactCore.Migrations
{
    public partial class FC2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactCompany",
                table: "Contacts",
                column: "ContactCompany");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_ContactRID",
                table: "ContactInfos",
                column: "ContactRID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_InfoTypeRID",
                table: "ContactInfos",
                column: "InfoTypeRID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactCompany",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfos_ContactRID",
                table: "ContactInfos");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfos_InfoTypeRID",
                table: "ContactInfos");

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
                    { new Guid("c5cfe4db-dc64-4f93-8eb6-48ec82a6d195"), new DateTimeOffset(new DateTime(2022, 2, 4, 23, 12, 32, 515, DateTimeKind.Unspecified).AddTicks(5254), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ContactInfoTypes", 0, "0", false, null },
                    { new Guid("66ba54e7-a1d4-4f3f-8a4c-696fbf25b263"), new DateTimeOffset(new DateTime(2022, 2, 4, 23, 12, 32, 518, DateTimeKind.Unspecified).AddTicks(6314), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ContactInfoTypes", 1, "1", false, null },
                    { new Guid("8367d787-d14a-4ef3-a350-900d4ae58d9b"), new DateTimeOffset(new DateTime(2022, 2, 4, 23, 12, 32, 518, DateTimeKind.Unspecified).AddTicks(6339), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ContactInfoTypes", 2, "2", false, null }
                });
        }
    }
}
