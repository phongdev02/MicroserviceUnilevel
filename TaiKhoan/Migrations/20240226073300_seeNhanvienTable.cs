using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaiKhoan.Migrations
{
    /// <inheritdoc />
    public partial class seeNhanvienTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nhanviens",
                columns: new[] { "NvId", "ChucvuId", "GmailNv", "HinhanhNv", "HoTen", "MatkhauNv", "NgayLam", "NgayTao", "Sdt", "TkId", "TrangthaiNv" },
                values: new object[,]
                {
                    { 1, 1, "gmail@gmail.com", "avatar.jpg", "John Doe", "password123", new DateTime(2024, 1, 27, 14, 33, 0, 849, DateTimeKind.Local).AddTicks(6115), new DateTime(2024, 2, 26, 14, 33, 0, 849, DateTimeKind.Local).AddTicks(6103), "123456789", 1, true },
                    { 2, 1, "gmail@gmail.com", "avatar.jpg", "John Doe", "password123", new DateTime(2024, 1, 27, 14, 33, 0, 849, DateTimeKind.Local).AddTicks(6142), new DateTime(2024, 2, 26, 14, 33, 0, 849, DateTimeKind.Local).AddTicks(6142), "123456789", 1, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nhanviens",
                keyColumn: "NvId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nhanviens",
                keyColumn: "NvId",
                keyValue: 2);
        }
    }
}
