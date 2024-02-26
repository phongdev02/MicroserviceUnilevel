using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaiKhoan.Migrations
{
    /// <inheritdoc />
    public partial class addNhanvienToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nhanviens",
                columns: table => new
                {
                    NvId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GmailNv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatkhauNv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayLam = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangthaiNv = table.Column<bool>(type: "bit", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucvuId = table.Column<int>(type: "int", nullable: true),
                    HinhanhNv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TkId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhanviens", x => x.NvId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nhanviens");
        }
    }
}
