using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Migrations
{
    /// <inheritdoc />
    public partial class createDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    areaCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    areaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.areaCode);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    titleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.titleID);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    accId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    titleID = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    managerID = table.Column<int>(type: "int", nullable: true),
                    areaCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.accId);
                    table.ForeignKey(
                        name: "FK_Accounts_Accounts_managerID",
                        column: x => x.managerID,
                        principalTable: "Accounts",
                        principalColumn: "accId");
                    table.ForeignKey(
                        name: "FK_Accounts_Areas_areaCode",
                        column: x => x.areaCode,
                        principalTable: "Areas",
                        principalColumn: "areaCode");
                    table.ForeignKey(
                        name: "FK_Accounts_Titles_titleID",
                        column: x => x.titleID,
                        principalTable: "Titles",
                        principalColumn: "titleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_areaCode",
                table: "Accounts",
                column: "areaCode");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_managerID",
                table: "Accounts",
                column: "managerID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_titleID",
                table: "Accounts",
                column: "titleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
