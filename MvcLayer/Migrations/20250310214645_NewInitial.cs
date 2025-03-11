using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcLayer.Migrations
{
    /// <inheritdoc />
    public partial class NewInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutCarouselImage",
                table: "Abouts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentTitle1",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentTitle2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutCarouselImage",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "ContentTitle1",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "ContentTitle2",
                table: "Abouts");
        }
    }
}
