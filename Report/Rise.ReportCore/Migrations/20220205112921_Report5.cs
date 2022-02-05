using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise.ReportCore.Migrations
{
    public partial class Report5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "RequestedDate",
                table: "ReportRequests",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "ReportRID",
                table: "ReportRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequests_ReportRID",
                table: "ReportRequests",
                column: "ReportRID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportRequests_Reports_ReportRID",
                table: "ReportRequests",
                column: "ReportRID",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportRequests_Reports_ReportRID",
                table: "ReportRequests");

            migrationBuilder.DropIndex(
                name: "IX_ReportRequests_ReportRID",
                table: "ReportRequests");

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

            migrationBuilder.DropColumn(
                name: "ReportRID",
                table: "ReportRequests");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "RequestedDate",
                table: "ReportRequests",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

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
    }
}
