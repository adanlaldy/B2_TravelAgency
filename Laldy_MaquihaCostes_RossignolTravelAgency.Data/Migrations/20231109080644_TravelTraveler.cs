using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Migrations
{
    /// <inheritdoc />
    public partial class TravelTraveler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TravelerId",
                table: "Destinations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Travelers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travelers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Destination = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelTraveler",
                columns: table => new
                {
                    TravelListId = table.Column<int>(type: "INTEGER", nullable: false),
                    TravelerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelTraveler", x => new { x.TravelListId, x.TravelerId });
                    table.ForeignKey(
                        name: "FK_TravelTraveler_Travelers_TravelerId",
                        column: x => x.TravelerId,
                        principalTable: "Travelers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelTraveler_Travels_TravelListId",
                        column: x => x.TravelListId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_TravelerId",
                table: "Destinations",
                column: "TravelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelTraveler_TravelerId",
                table: "TravelTraveler",
                column: "TravelerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Travelers_TravelerId",
                table: "Destinations",
                column: "TravelerId",
                principalTable: "Travelers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Travelers_TravelerId",
                table: "Destinations");

            migrationBuilder.DropTable(
                name: "TravelTraveler");

            migrationBuilder.DropTable(
                name: "Travelers");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_TravelerId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "TravelerId",
                table: "Destinations");
        }
    }
}
