using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialAuthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AuthorInsertionDate",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsatagramLink",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "XLink",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorInsertionDate",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "InsatagramLink",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "XLink",
                table: "Authors");
        }
    }
}
