using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CineBucket.Migrations
{
    /// <inheritdoc />
    public partial class v5userid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FavoriteMovies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FavoriteMovies");
        }
    }
}
