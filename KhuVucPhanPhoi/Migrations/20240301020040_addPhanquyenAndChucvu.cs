using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KhuVucPhanPhoi.Migrations
{
    /// <inheritdoc />
    public partial class addPhanquyenAndChucvu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "khuVucs",
                columns: table => new
                {
                    KhuvucId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khuVucs", x => x.KhuvucId);
                });

            migrationBuilder.CreateTable(
                name: "nhaPhanPhois",
                columns: table => new
                {
                    NhaphanphoiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNpp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trangthai = table.Column<int>(type: "int", nullable: true),
                    KhuvucId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhaPhanPhois", x => x.NhaphanphoiId);
                    table.ForeignKey(
                        name: "FK_nhaPhanPhois_khuVucs_KhuvucId",
                        column: x => x.KhuvucId,
                        principalTable: "khuVucs",
                        principalColumn: "KhuvucId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nhaPhanPhois_KhuvucId",
                table: "nhaPhanPhois",
                column: "KhuvucId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nhaPhanPhois");

            migrationBuilder.DropTable(
                name: "khuVucs");
        }
    }
}
