using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rise.ContactCore.Migrations
{
    public partial class Contact_20220206 : Migration
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
                    { new Guid("4d3df43e-62dc-47ae-b0d6-e164c26bad0b"), new DateTimeOffset(new DateTime(2022, 2, 6, 11, 24, 18, 979, DateTimeKind.Unspecified).AddTicks(1022), new TimeSpan(0, 3, 0, 0, 0)), "Cell Phone", "ContactInfoTypes", 0, "0", false, null },
                    { new Guid("883c5484-af9d-4899-819e-333387e7ffd4"), new DateTimeOffset(new DateTime(2022, 2, 6, 11, 24, 18, 982, DateTimeKind.Unspecified).AddTicks(4252), new TimeSpan(0, 3, 0, 0, 0)), "E-Mail", "ContactInfoTypes", 1, "1", false, null },
                    { new Guid("3ff34731-a750-40e6-ac57-db9c468cab27"), new DateTimeOffset(new DateTime(2022, 2, 6, 11, 24, 18, 982, DateTimeKind.Unspecified).AddTicks(4279), new TimeSpan(0, 3, 0, 0, 0)), "Location", "ContactInfoTypes", 2, "2", false, null },
                    { new Guid("cf322c38-59d4-45cc-84cd-b589f294c2ba"), new DateTimeOffset(new DateTime(2022, 2, 6, 11, 24, 18, 982, DateTimeKind.Unspecified).AddTicks(4282), new TimeSpan(0, 3, 0, 0, 0)), "Preparing", "ReportStatus", 0, "0", false, null },
                    { new Guid("4a208f32-a985-4859-8b05-90e6dff3d4ae"), new DateTimeOffset(new DateTime(2022, 2, 6, 11, 24, 18, 982, DateTimeKind.Unspecified).AddTicks(4284), new TimeSpan(0, 3, 0, 0, 0)), "Completed", "ReportStatus", 1, "1", false, null }
                });

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
