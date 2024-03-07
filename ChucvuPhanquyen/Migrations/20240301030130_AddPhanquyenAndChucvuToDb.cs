using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChucvuPhanquyen.Migrations
{
    /// <inheritdoc />
    public partial class AddPhanquyenAndChucvuToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nhomChucVus",
                columns: table => new
                {
                    NhomcvId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNcv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quyen = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhomChucVus", x => x.NhomcvId);
                });

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

            migrationBuilder.CreateTable(
                name: "quyens",
                columns: table => new
                {
                    QuyenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quyens", x => x.QuyenId);
                });

            migrationBuilder.CreateTable(
                name: "chucVus",
                columns: table => new
                {
                    ChucvuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NhomcvId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chucVus", x => x.ChucvuId);
                    table.ForeignKey(
                        name: "FK_chucVus_nhomChucVus_NhomcvId",
                        column: x => x.NhomcvId,
                        principalTable: "nhomChucVus",
                        principalColumn: "NhomcvId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quyenTruyCaps",
                columns: table => new
                {
                    QuyenTruycapId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyenTc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuyenId = table.Column<int>(type: "int", nullable: true),
                    NhomQuyenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quyenTruyCaps", x => x.QuyenTruycapId);
                    table.ForeignKey(
                        name: "FK_quyenTruyCaps_nhomQuyenTruyCaps_NhomQuyenId",
                        column: x => x.NhomQuyenId,
                        principalTable: "nhomQuyenTruyCaps",
                        principalColumn: "NhomQuyenId");
                    table.ForeignKey(
                        name: "FK_quyenTruyCaps_quyens_QuyenId",
                        column: x => x.QuyenId,
                        principalTable: "quyens",
                        principalColumn: "QuyenId");
                });

            migrationBuilder.CreateTable(
                name: "CapQuyen",
                columns: table => new
                {
                    QuyenTruycapId = table.Column<int>(type: "int", nullable: false),
                    ChucvuId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapQuyen", x => new { x.QuyenTruycapId, x.ChucvuId });
                    table.ForeignKey(
                        name: "FK_CapQuyen_chucVus_ChucvuId",
                        column: x => x.ChucvuId,
                        principalTable: "chucVus",
                        principalColumn: "ChucvuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapQuyen_quyenTruyCaps_QuyenTruycapId",
                        column: x => x.QuyenTruycapId,
                        principalTable: "quyenTruyCaps",
                        principalColumn: "QuyenTruycapId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CapQuyen_ChucvuId",
                table: "CapQuyen",
                column: "ChucvuId");

            migrationBuilder.CreateIndex(
                name: "IX_chucVus_NhomcvId",
                table: "chucVus",
                column: "NhomcvId");

            migrationBuilder.CreateIndex(
                name: "IX_quyenTruyCaps_NhomQuyenId",
                table: "quyenTruyCaps",
                column: "NhomQuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_quyenTruyCaps_QuyenId",
                table: "quyenTruyCaps",
                column: "QuyenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CapQuyen");

            migrationBuilder.DropTable(
                name: "PhanCapNVs");

            migrationBuilder.DropTable(
                name: "chucVus");

            migrationBuilder.DropTable(
                name: "quyenTruyCaps");

            migrationBuilder.DropTable(
                name: "nhomChucVus");

            migrationBuilder.DropTable(
                name: "nhomQuyenTruyCaps");

            migrationBuilder.DropTable(
                name: "quyens");
        }
    }
}
