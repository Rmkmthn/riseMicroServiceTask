using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise.ReportCore.Migrations
{
    public partial class report1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConstID = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ConstDesc = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ConstValue = table.Column<string>(type: "text", nullable: true),
                    ConstOrder = table.Column<int>(type: "integer", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    MDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    MDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstLangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LangID = table.Column<string>(type: "text", nullable: true),
                    ConstRID = table.Column<Guid>(type: "uuid", nullable: false),
                    ConstLangDesc = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    MDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstLangs_Consts_ConstRID",
                        column: x => x.ConstRID,
                        principalTable: "Consts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ReportStatusRID = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    MDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportRequests_Consts_ReportStatusRID",
                        column: x => x.ReportStatusRID,
                        principalTable: "Consts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Consts",
                columns: new[] { "Id", "CDate", "ConstDesc", "ConstID", "ConstOrder", "ConstValue", "Deleted", "MDate" },
                values: new object[,]
                {
                    { new Guid("ab876e89-949d-4daa-8ffe-ebb64bd8ae14"), new DateTimeOffset(new DateTime(2022, 2, 5, 1, 34, 28, 219, DateTimeKind.Unspecified).AddTicks(798), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ReportInfoTypes", 0, "0", false, null },
                    { new Guid("fc9d8d88-22b6-40a4-be30-568fa4d0b01a"), new DateTimeOffset(new DateTime(2022, 2, 5, 1, 34, 28, 222, DateTimeKind.Unspecified).AddTicks(4070), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ReportInfoTypes", 1, "1", false, null },
                    { new Guid("31b037a9-157c-49f9-977f-ceb4ee28a9b8"), new DateTimeOffset(new DateTime(2022, 2, 5, 1, 34, 28, 222, DateTimeKind.Unspecified).AddTicks(4096), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ReportInfoTypes", 2, "2", false, null },
                    { new Guid("ae12fa75-5fc4-424a-b4b7-85a8c7bd44cd"), new DateTimeOffset(new DateTime(2022, 2, 5, 1, 34, 28, 222, DateTimeKind.Unspecified).AddTicks(4100), new TimeSpan(0, 3, 0, 0, 0)), "Preparing", "ReportStatus", 0, "0", false, null },
                    { new Guid("34db61c8-34f9-40bc-90c0-1854b9710870"), new DateTimeOffset(new DateTime(2022, 2, 5, 1, 34, 28, 222, DateTimeKind.Unspecified).AddTicks(4102), new TimeSpan(0, 3, 0, 0, 0)), "Completed", "ReportStatus", 1, "1", false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstLangs_ConstRID",
                table: "ConstLangs",
                column: "ConstRID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequests_ReportStatusRID",
                table: "ReportRequests",
                column: "ReportStatusRID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstLangs");

            migrationBuilder.DropTable(
                name: "ReportRequests");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Consts");
        }
    }
}
