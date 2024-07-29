using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentFlats.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedByIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Flats",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flats_CreatedById",
                table: "Flats",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Flats_AspNetUsers_CreatedById",
                table: "Flats",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flats_AspNetUsers_CreatedById",
                table: "Flats");

            migrationBuilder.DropIndex(
                name: "IX_Flats_CreatedById",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Flats");

        }
    }
}
