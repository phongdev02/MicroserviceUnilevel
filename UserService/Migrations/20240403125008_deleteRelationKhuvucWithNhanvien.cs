using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Migrations
{
    /// <inheritdoc />
    public partial class deleteRelationKhuvucWithNhanvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nhanviens_khuVucs_KhuvucCode",
                table: "Nhanviens");

            migrationBuilder.DropIndex(
                name: "IX_Nhanviens_KhuvucCode",
                table: "Nhanviens");

            migrationBuilder.DropColumn(
                name: "KhuvucCode",
                table: "Nhanviens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KhuvucCode",
                table: "Nhanviens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Nhanviens_KhuvucCode",
                table: "Nhanviens",
                column: "KhuvucCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Nhanviens_khuVucs_KhuvucCode",
                table: "Nhanviens",
                column: "KhuvucCode",
                principalTable: "khuVucs",
                principalColumn: "KhuvucCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
