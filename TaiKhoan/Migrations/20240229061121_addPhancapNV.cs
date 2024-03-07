using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaiKhoan.Migrations
{
    /// <inheritdoc />
    public partial class addPhancapNV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhanCapNVs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NvqlID = table.Column<int>(type: "int", nullable: false),
                    NvID = table.Column<int>(type: "int", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCapNVs", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "Nhanviens",
                keyColumn: "NvId",
                keyValue: 1,
                columns: new[] { "NgayLam", "NgayTao" },
                values: new object[] { new DateTime(2024, 1, 30, 13, 11, 21, 308, DateTimeKind.Local).AddTicks(6647), new DateTime(2024, 2, 29, 13, 11, 21, 308, DateTimeKind.Local).AddTicks(6630) });

            migrationBuilder.UpdateData(
                table: "Nhanviens",
                keyColumn: "NvId",
                keyValue: 2,
                columns: new[] { "NgayLam", "NgayTao" },
                values: new object[] { new DateTime(2024, 1, 30, 13, 11, 21, 308, DateTimeKind.Local).AddTicks(6680), new DateTime(2024, 2, 29, 13, 11, 21, 308, DateTimeKind.Local).AddTicks(6679) });

            migrationBuilder.InsertData(
                table: "PhanCapNVs",
                columns: new[] { "id", "NvID", "NvqlID", "Trangthai" },
                values: new object[] { 1, 2, 3, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhanCapNVs");

            migrationBuilder.UpdateData(
                table: "Nhanviens",
                keyColumn: "NvId",
                keyValue: 1,
                columns: new[] { "NgayLam", "NgayTao" },
                values: new object[] { new DateTime(2024, 1, 27, 14, 33, 0, 849, DateTimeKind.Local).AddTicks(6115), new DateTime(2024, 2, 26, 14, 33, 0, 849, DateTimeKind.Local).AddTicks(6103) });

            migrationBuilder.UpdateData(
                table: "Nhanviens",
                keyColumn: "NvId",
                keyValue: 2,
                columns: new[] { "NgayLam", "NgayTao" },
                values: new object[] { new DateTime(2024, 1, 27, 14, 33, 0, 849, DateTimeKind.Local).AddTicks(6142), new DateTime(2024, 2, 26, 14, 33, 0, 849, DateTimeKind.Local).AddTicks(6142) });
        }
    }
}
