using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact.DataAccess.Migrations
{
    public partial class mig001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Surname = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Company = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<ushort>(type: "integer", nullable: false),
                    Path = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    PersonUUID = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    InfoType = table.Column<ushort>(type: "integer", nullable: false),
                    Info = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.PersonUUID);
                    table.ForeignKey(
                        name: "FK_ContactInfo_Person_PersonUUID",
                        column: x => x.PersonUUID,
                        principalTable: "Person",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfo");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
