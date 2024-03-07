using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaiKhoan.Migrations
{
    /// <inheritdoc />
    public partial class addCVAndRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nhanviens_chucVus_ChucvuId",
                table: "Nhanviens");

            migrationBuilder.DropIndex(
                name: "IX_Nhanviens_ChucvuId",
                table: "Nhanviens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Nhanviens_ChucvuId",
                table: "Nhanviens",
                column: "ChucvuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nhanviens_chucVus_ChucvuId",
                table: "Nhanviens",
                column: "ChucvuId",
                principalTable: "chucVus",
                principalColumn: "ChucvuId");
        }
    }
}
