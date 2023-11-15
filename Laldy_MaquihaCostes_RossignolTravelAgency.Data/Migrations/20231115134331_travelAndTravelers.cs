using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Migrations
{
    /// <inheritdoc />
    public partial class travelAndTravelers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllEvents_Destinations_DestinationId",
                table: "AllEvents");

            migrationBuilder.RenameColumn(
                name: "DestinationId",
                table: "AllEvents",
                newName: "DestinationID");

            migrationBuilder.RenameIndex(
                name: "IX_AllEvents_DestinationId",
                table: "AllEvents",
                newName: "IX_AllEvents_DestinationID");

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
                    DestinationId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    TravelerID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Travels_Travelers_TravelerID",
                        column: x => x.TravelerID,
                        principalTable: "Travelers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Travels_DestinationId",
                table: "Travels",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_TravelerID",
                table: "Travels",
                column: "TravelerID");

            migrationBuilder.AddForeignKey(
                name: "FK_AllEvents_Destinations_DestinationID",
                table: "AllEvents",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllEvents_Destinations_DestinationID",
                table: "AllEvents");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "Travelers");

            migrationBuilder.RenameColumn(
                name: "DestinationID",
                table: "AllEvents",
                newName: "DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_AllEvents_DestinationID",
                table: "AllEvents",
                newName: "IX_AllEvents_DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllEvents_Destinations_DestinationId",
                table: "AllEvents",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
