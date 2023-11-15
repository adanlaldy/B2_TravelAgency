using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Migrations
{
    /// <inheritdoc />
    public partial class destination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    IsCapital = table.Column<bool>(type: "INTEGER", nullable: false),
                    PointsOfInterest = table.Column<string>(type: "TEXT", nullable: false),
                    IsVisited = table.Column<bool>(type: "INTEGER", nullable: false),
                    Rate = table.Column<int>(type: "INTEGER", nullable: true),
                    Comment = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
