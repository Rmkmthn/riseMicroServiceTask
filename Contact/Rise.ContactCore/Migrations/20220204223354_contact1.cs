using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise.ContactCore.Migrations
{
    public partial class contact1 : Migration
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
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ContactSurname = table.Column<string>(type: "text", nullable: true),
                    ContactCompany = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    MDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
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
                name: "ContactInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactRID = table.Column<Guid>(type: "uuid", nullable: false),
                    InfoTypeRID = table.Column<Guid>(type: "uuid", nullable: false),
                    InfoValue = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: true),
                    CDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    MDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInfos_Consts_InfoTypeRID",
                        column: x => x.InfoTypeRID,
                        principalTable: "Consts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactInfos_Contacts_ContactRID",
                        column: x => x.ContactRID,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Consts",
                columns: new[] { "Id", "CDate", "ConstDesc", "ConstID", "ConstOrder", "ConstValue", "Deleted", "MDate" },
                values: new object[,]
                {
                    { new Guid("8a4f8571-c184-4602-935a-5bf7fd78aa2b"), new DateTimeOffset(new DateTime(2022, 2, 5, 1, 33, 54, 411, DateTimeKind.Unspecified).AddTicks(335), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ContactInfoTypes", 0, "0", false, null },
                    { new Guid("4ad9a6a0-11eb-4a18-8e71-80710063feea"), new DateTimeOffset(new DateTime(2022, 2, 5, 1, 33, 54, 414, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ContactInfoTypes", 1, "1", false, null },
                    { new Guid("65246cd0-73db-45c7-8efb-36dde39293a1"), new DateTimeOffset(new DateTime(2022, 2, 5, 1, 33, 54, 414, DateTimeKind.Unspecified).AddTicks(2337), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ContactInfoTypes", 2, "2", false, null },
                    { new Guid("62f07822-e806-4530-a23c-6fe7af9c928d"), new DateTimeOffset(new DateTime(2022, 2, 5, 1, 33, 54, 414, DateTimeKind.Unspecified).AddTicks(2341), new TimeSpan(0, 3, 0, 0, 0)), "Preparing", "ReportStatus", 0, "0", false, null },
                    { new Guid("7c3822b8-85a1-405f-b9c1-0a8a24547b9f"), new DateTimeOffset(new DateTime(2022, 2, 5, 1, 33, 54, 414, DateTimeKind.Unspecified).AddTicks(2344), new TimeSpan(0, 3, 0, 0, 0)), "Completed", "ReportStatus", 1, "1", false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstLangs_ConstRID",
                table: "ConstLangs",
                column: "ConstRID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_ContactRID",
                table: "ContactInfos",
                column: "ContactRID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_ContactRID_InfoTypeRID",
                table: "ContactInfos",
                columns: new[] { "ContactRID", "InfoTypeRID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_InfoTypeRID",
                table: "ContactInfos",
                column: "InfoTypeRID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactCompany",
                table: "Contacts",
                column: "ContactCompany");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstLangs");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "Consts");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
