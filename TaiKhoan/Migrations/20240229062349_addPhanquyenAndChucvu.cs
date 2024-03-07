using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaiKhoan.Migrations
{
    /// <inheritdoc />
    public partial class addPhanquyenAndChucvu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nhanviens",
                keyColumn: "NvId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nhanviens",
                keyColumn: "NvId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PhanCapNVs",
                keyColumn: "id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nhanviens",
                columns: new[] { "NvId", "ChucvuId", "GmailNv", "HinhanhNv", "HoTen", "MatkhauNv", "NgayLam", "NgayTao", "Sdt", "TkId", "TrangthaiNv" },
                values: new object[,]
                {
                    { 1, 1, "gmail@gmail.com", "avatar.jpg", "John Doe", "password123", new DateTime(2024, 1, 30, 13, 11, 21, 308, DateTimeKind.Local).AddTicks(6647), new DateTime(2024, 2, 29, 13, 11, 21, 308, DateTimeKind.Local).AddTicks(6630), "123456789", 1, true },
                    { 2, 1, "gmail@gmail.com", "avatar.jpg", "John Doe", "password123", new DateTime(2024, 1, 30, 13, 11, 21, 308, DateTimeKind.Local).AddTicks(6680), new DateTime(2024, 2, 29, 13, 11, 21, 308, DateTimeKind.Local).AddTicks(6679), "123456789", 1, true }
                });

            migrationBuilder.InsertData(
                table: "PhanCapNVs",
                columns: new[] { "id", "NvID", "NvqlID", "Trangthai" },
                values: new object[] { 1, 2, 3, true });
        }
    }
}
