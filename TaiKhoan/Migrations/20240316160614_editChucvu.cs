using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaiKhoan.Migrations
{
    /// <inheritdoc />
    public partial class editChucvu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chucVus_nhomChucVus_NhomcvId",
                table: "chucVus");

            migrationBuilder.DropForeignKey(
                name: "FK_quyenTruyCaps_nhomQuyenTruyCaps_NhomQuyenId",
                table: "quyenTruyCaps");

            migrationBuilder.DropTable(
                name: "nhomQuyenTruyCaps");

            migrationBuilder.DropIndex(
                name: "IX_chucVus_NhomcvId",
                table: "chucVus");

            migrationBuilder.DropColumn(
                name: "Quyen",
                table: "nhomChucVus");

            migrationBuilder.DropColumn(
                name: "NhomcvId",
                table: "chucVus");

            migrationBuilder.RenameColumn(
                name: "TenNcv",
                table: "nhomChucVus",
                newName: "TenNq");

            migrationBuilder.RenameColumn(
                name: "NhomcvId",
                table: "nhomChucVus",
                newName: "NhomQuyenId");

            migrationBuilder.AddForeignKey(
                name: "FK_quyenTruyCaps_nhomChucVus_NhomQuyenId",
                table: "quyenTruyCaps",
                column: "NhomQuyenId",
                principalTable: "nhomChucVus",
                principalColumn: "NhomQuyenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quyenTruyCaps_nhomChucVus_NhomQuyenId",
                table: "quyenTruyCaps");

            migrationBuilder.RenameColumn(
                name: "TenNq",
                table: "nhomChucVus",
                newName: "TenNcv");

            migrationBuilder.RenameColumn(
                name: "NhomQuyenId",
                table: "nhomChucVus",
                newName: "NhomcvId");

            migrationBuilder.AddColumn<int>(
                name: "Quyen",
                table: "nhomChucVus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhomcvId",
                table: "chucVus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "nhomQuyenTruyCaps",
                columns: table => new
                {
                    NhomQuyenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNq = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhomQuyenTruyCaps", x => x.NhomQuyenId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chucVus_NhomcvId",
                table: "chucVus",
                column: "NhomcvId");

            migrationBuilder.AddForeignKey(
                name: "FK_chucVus_nhomChucVus_NhomcvId",
                table: "chucVus",
                column: "NhomcvId",
                principalTable: "nhomChucVus",
                principalColumn: "NhomcvId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_quyenTruyCaps_nhomQuyenTruyCaps_NhomQuyenId",
                table: "quyenTruyCaps",
                column: "NhomQuyenId",
                principalTable: "nhomQuyenTruyCaps",
                principalColumn: "NhomQuyenId");
        }
    }
}
