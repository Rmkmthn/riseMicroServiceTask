using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise.ReportCore.Migrations
{
    public partial class Report_20220206 : Migration
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
                    ReportID = table.Column<string>(type: "text", nullable: true),
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
                    ReportRID = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ReportStatusRID = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportFilePath = table.Column<string>(type: "text", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_ReportRequests_Reports_ReportRID",
                        column: x => x.ReportRID,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Consts",
                columns: new[] { "Id", "CDate", "ConstDesc", "ConstID", "ConstOrder", "ConstValue", "Deleted", "MDate" },
                values: new object[,]
                {
                    { new Guid("069049d0-0093-43be-b284-ee1e28a8af7a"), new DateTimeOffset(new DateTime(2022, 2, 6, 11, 26, 20, 359, DateTimeKind.Unspecified).AddTicks(4500), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ReportInfoTypes", 0, "0", false, null },
                    { new Guid("291166bb-6a69-47e5-ac68-da1c96cc78b6"), new DateTimeOffset(new DateTime(2022, 2, 6, 11, 26, 20, 359, DateTimeKind.Unspecified).AddTicks(5711), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ReportInfoTypes", 1, "1", false, null },
                    { new Guid("f02fb45c-a0fe-485c-8b3e-b91734afc1c8"), new DateTimeOffset(new DateTime(2022, 2, 6, 11, 26, 20, 359, DateTimeKind.Unspecified).AddTicks(5726), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ReportInfoTypes", 2, "2", false, null },
                    { new Guid("8865d315-2662-4f7f-bb13-123826efb599"), new DateTimeOffset(new DateTime(2022, 2, 6, 11, 26, 20, 359, DateTimeKind.Unspecified).AddTicks(5729), new TimeSpan(0, 3, 0, 0, 0)), "Preparing", "ReportStatus", 0, "0", false, null },
                    { new Guid("a9481bcf-79f1-4cad-9ae3-26e7b53a931a"), new DateTimeOffset(new DateTime(2022, 2, 6, 11, 26, 20, 359, DateTimeKind.Unspecified).AddTicks(5732), new TimeSpan(0, 3, 0, 0, 0)), "Completed", "ReportStatus", 1, "1", false, null }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CDate", "Deleted", "MDate", "ReportID", "ReportName" },
                values: new object[] { new Guid("4ee62dab-c72b-4a97-9e5c-12a519b2ffd3"), new DateTimeOffset(new DateTime(2022, 2, 6, 11, 26, 20, 343, DateTimeKind.Unspecified).AddTicks(6924), new TimeSpan(0, 3, 0, 0, 0)), false, null, "00001", "Statistics of Contact by Location" });

            migrationBuilder.CreateIndex(
                name: "IX_ConstLangs_ConstRID",
                table: "ConstLangs",
                column: "ConstRID");

            migrationBuilder.CreateIndex(
                name: "IX_Consts_ConstID_ConstValue",
                table: "Consts",
                columns: new[] { "ConstID", "ConstValue" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequests_ReportRID",
                table: "ReportRequests",
                column: "ReportRID");

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
                name: "Consts");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
