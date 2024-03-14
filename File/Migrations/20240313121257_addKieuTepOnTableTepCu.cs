using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace File.Migrations
{
    /// <inheritdoc />
    public partial class addKieuTepOnTableTepCu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kieutep",
                table: "TepCus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kieutep",
                table: "TepCus");
        }
    }
}
