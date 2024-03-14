using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace File.Migrations
{
    /// <inheritdoc />
    public partial class addContentTypeinTableTep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "contentType",
                table: "Teps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contentType",
                table: "Teps");
        }
    }
}
