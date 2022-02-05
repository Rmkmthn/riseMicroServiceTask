using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise.ReportCore.Migrations
{
    public partial class Report2 : Migration
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
                    { new Guid("82cbc07a-4f0c-4ab5-ab5e-30dfa9e21a91"), new DateTimeOffset(new DateTime(2022, 2, 5, 10, 29, 59, 658, DateTimeKind.Unspecified).AddTicks(1195), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ReportInfoTypes", 0, "0", false, null },
                    { new Guid("93495646-be1d-43c7-86fc-f3714e6e9e44"), new DateTimeOffset(new DateTime(2022, 2, 5, 10, 29, 59, 661, DateTimeKind.Unspecified).AddTicks(963), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ReportInfoTypes", 1, "1", false, null },
                    { new Guid("71011eb1-7341-44e5-899b-14ceba3bfa06"), new DateTimeOffset(new DateTime(2022, 2, 5, 10, 29, 59, 661, DateTimeKind.Unspecified).AddTicks(988), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ReportInfoTypes", 2, "2", false, null },
                    { new Guid("6b294bdc-bf6c-422d-8904-a1ee96bd9e2b"), new DateTimeOffset(new DateTime(2022, 2, 5, 10, 29, 59, 661, DateTimeKind.Unspecified).AddTicks(992), new TimeSpan(0, 3, 0, 0, 0)), "Preparing", "ReportStatus", 0, "0", false, null },
                    { new Guid("2687f90f-d768-488f-a949-7f32d8b13dcb"), new DateTimeOffset(new DateTime(2022, 2, 5, 10, 29, 59, 661, DateTimeKind.Unspecified).AddTicks(994), new TimeSpan(0, 3, 0, 0, 0)), "Completed", "ReportStatus", 1, "1", false, null }
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
