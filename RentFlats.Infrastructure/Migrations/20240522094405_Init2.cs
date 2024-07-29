using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentFlats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prize",
                table: "Flats",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Flats",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "EncodedName",
                table: "Flats",
                newName: "EncodedTitle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Flats",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Flats",
                newName: "Prize");

            migrationBuilder.RenameColumn(
                name: "EncodedTitle",
                table: "Flats",
                newName: "EncodedName");
        }
    }
}
