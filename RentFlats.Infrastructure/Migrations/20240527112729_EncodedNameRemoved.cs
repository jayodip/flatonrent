using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentFlats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EncodedNameRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EncodedTitle",
                table: "Flats");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EncodedTitle",
                table: "Flats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
