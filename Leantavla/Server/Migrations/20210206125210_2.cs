using Microsoft.EntityFrameworkCore.Migrations;

namespace Leantavla.Server.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributtyp",
                columns: table => new
                {
                    AttributtypId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attributnamn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attributbeskrivning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datatyp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributtyp", x => x.AttributtypId);
                });

            migrationBuilder.CreateTable(
                name: "Attribut",
                columns: table => new
                {
                    AttributId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributtypId = table.Column<int>(type: "int", nullable: true),
                    LappId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribut", x => x.AttributId);
                    table.ForeignKey(
                        name: "FK_Attribut_Attributtyp_AttributtypId",
                        column: x => x.AttributtypId,
                        principalTable: "Attributtyp",
                        principalColumn: "AttributtypId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attribut_Lappar_LappId",
                        column: x => x.LappId,
                        principalTable: "Lappar",
                        principalColumn: "LappId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attribut_AttributtypId",
                table: "Attribut",
                column: "AttributtypId");

            migrationBuilder.CreateIndex(
                name: "IX_Attribut_LappId",
                table: "Attribut",
                column: "LappId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attribut");

            migrationBuilder.DropTable(
                name: "Attributtyp");
        }
    }
}
