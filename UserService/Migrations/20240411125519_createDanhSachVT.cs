using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Migrations
{
    /// <inheritdoc />
    public partial class createDanhSachVT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViengThams_Nhanviens_NguoiTaoID",
                table: "ViengThams");

            migrationBuilder.DropIndex(
                name: "IX_ViengThams_NguoiTaoID",
                table: "ViengThams");

            migrationBuilder.DropColumn(
                name: "NguoiTaoID",
                table: "ViengThams");

            migrationBuilder.RenameColumn(
                name: "NgayTham",
                table: "ViengThams",
                newName: "NgayThucHien");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NhacNho",
                table: "ViengThams",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Mota",
                table: "ViengThams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayTao",
                table: "ViengThams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "DanhSachLichViengTham",
                columns: table => new
                {
                    viengthamID = table.Column<int>(type: "int", nullable: false),
                    taikhoanID = table.Column<int>(type: "int", nullable: false),
                    NhanvienNvId = table.Column<int>(type: "int", nullable: false),
                    NguoiTao = table.Column<bool>(type: "bit", nullable: false),
                    TrangThaiThamDu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhSachLichViengTham", x => new { x.viengthamID, x.taikhoanID });
                    table.ForeignKey(
                        name: "FK_DanhSachLichViengTham_Nhanviens_NhanvienNvId",
                        column: x => x.NhanvienNvId,
                        principalTable: "Nhanviens",
                        principalColumn: "NvId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DanhSachLichViengTham_ViengThams_viengthamID",
                        column: x => x.viengthamID,
                        principalTable: "ViengThams",
                        principalColumn: "viengThamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanhSachLichViengTham_NhanvienNvId",
                table: "DanhSachLichViengTham",
                column: "NhanvienNvId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhSachLichViengTham");

            migrationBuilder.DropColumn(
                name: "NgayTao",
                table: "ViengThams");

            migrationBuilder.RenameColumn(
                name: "NgayThucHien",
                table: "ViengThams",
                newName: "NgayTham");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NhacNho",
                table: "ViengThams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mota",
                table: "ViengThams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NguoiTaoID",
                table: "ViengThams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ViengThams_NguoiTaoID",
                table: "ViengThams",
                column: "NguoiTaoID");

            migrationBuilder.AddForeignKey(
                name: "FK_ViengThams_Nhanviens_NguoiTaoID",
                table: "ViengThams",
                column: "NguoiTaoID",
                principalTable: "Nhanviens",
                principalColumn: "NvId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
