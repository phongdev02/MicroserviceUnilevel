using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace File.Migrations
{
    /// <inheritdoc />
    public partial class addTableToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teps",
                columns: table => new
                {
                    TepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KieuTep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuLieu = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NgayUpload = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teps", x => x.TepId);
                });

            migrationBuilder.CreateTable(
                name: "TepCus",
                columns: table => new
                {
                    TepcuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTep = table.Column<int>(type: "int", nullable: false),
                    Dulieu = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    NgayChinhXua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TacDong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    TepID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TepCus", x => x.TepcuId);
                    table.ForeignKey(
                        name: "FK_TepCus_Teps_TepID",
                        column: x => x.TepID,
                        principalTable: "Teps",
                        principalColumn: "TepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TepCus_TepID",
                table: "TepCus",
                column: "TepID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TepCus");

            migrationBuilder.DropTable(
                name: "Teps");
        }
    }
}
