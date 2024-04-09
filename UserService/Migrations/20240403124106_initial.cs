﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chucVus",
                columns: table => new
                {
                    ChucvuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chucVus", x => x.ChucvuId);
                });

            migrationBuilder.CreateTable(
                name: "khuVucs",
                columns: table => new
                {
                    KhuvucCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhuvuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khuVucs", x => x.KhuvucCode);
                });

            migrationBuilder.CreateTable(
                name: "nhomQuyenTruyCap",
                columns: table => new
                {
                    NhomQuyenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNq = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhomQuyenTruyCap", x => x.NhomQuyenId);
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
                name: "nhaPhanPhois",
                columns: table => new
                {
                    nppID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenNPP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trangthai = table.Column<bool>(type: "bit", nullable: true),
                    KhuvucID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhaPhanPhois", x => x.nppID);
                    table.ForeignKey(
                        name: "FK_nhaPhanPhois_khuVucs_KhuvucID",
                        column: x => x.KhuvucID,
                        principalTable: "khuVucs",
                        principalColumn: "KhuvucCode");
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
                        name: "FK_quyenTruyCaps_nhomQuyenTruyCap_NhomQuyenId",
                        column: x => x.NhomQuyenId,
                        principalTable: "nhomQuyenTruyCap",
                        principalColumn: "NhomQuyenId");
                    table.ForeignKey(
                        name: "FK_quyenTruyCaps_quyens_QuyenId",
                        column: x => x.QuyenId,
                        principalTable: "quyens",
                        principalColumn: "QuyenId");
                });

            migrationBuilder.CreateTable(
                name: "Nhanviens",
                columns: table => new
                {
                    NvId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GmailDangnhap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GmailNv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GmailQuanly = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatkhauNv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayLam = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangthaiNv = table.Column<bool>(type: "bit", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nguoidung = table.Column<bool>(type: "bit", nullable: true),
                    ChucvuId = table.Column<int>(type: "int", nullable: true),
                    nppID = table.Column<int>(type: "int", nullable: false),
                    quanlyNPP = table.Column<bool>(type: "bit", nullable: true),
                    HinhanhID = table.Column<int>(type: "int", nullable: true),
                    KhuvucCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhanviens", x => x.NvId);
                    table.ForeignKey(
                        name: "FK_Nhanviens_chucVus_ChucvuId",
                        column: x => x.ChucvuId,
                        principalTable: "chucVus",
                        principalColumn: "ChucvuId");
                    table.ForeignKey(
                        name: "FK_Nhanviens_khuVucs_KhuvucCode",
                        column: x => x.KhuvucCode,
                        principalTable: "khuVucs",
                        principalColumn: "KhuvucCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nhanviens_nhaPhanPhois_nppID",
                        column: x => x.nppID,
                        principalTable: "nhaPhanPhois",
                        principalColumn: "nppID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Nhanviens_ChucvuId",
                table: "Nhanviens",
                column: "ChucvuId");

            migrationBuilder.CreateIndex(
                name: "IX_Nhanviens_KhuvucCode",
                table: "Nhanviens",
                column: "KhuvucCode");

            migrationBuilder.CreateIndex(
                name: "IX_Nhanviens_nppID",
                table: "Nhanviens",
                column: "nppID");

            migrationBuilder.CreateIndex(
                name: "IX_nhaPhanPhois_KhuvucID",
                table: "nhaPhanPhois",
                column: "KhuvucID");

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
                name: "Nhanviens");

            migrationBuilder.DropTable(
                name: "PhanCapNVs");

            migrationBuilder.DropTable(
                name: "quyenTruyCaps");

            migrationBuilder.DropTable(
                name: "chucVus");

            migrationBuilder.DropTable(
                name: "nhaPhanPhois");

            migrationBuilder.DropTable(
                name: "nhomQuyenTruyCap");

            migrationBuilder.DropTable(
                name: "quyens");

            migrationBuilder.DropTable(
                name: "khuVucs");
        }
    }
}
