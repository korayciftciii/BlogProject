using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialAuthorProfileForEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorEmail",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorEmail",
                table: "Authors");
        }
    }
}
