using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChucvuPhanquyen.Migrations
{
    /// <inheritdoc />
    public partial class AdddataoRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhanCapNVs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NvID = table.Column<int>(type: "int", nullable: false),
                    NvqlID = table.Column<int>(type: "int", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCapNVs", x => x.id);
                });
        }
    }
}
