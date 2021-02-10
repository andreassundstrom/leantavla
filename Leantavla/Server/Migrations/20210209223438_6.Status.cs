using Microsoft.EntityFrameworkCore.Migrations;

namespace Leantavla.Server.Migrations
{
    public partial class _6Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attribut_Attributtyper_AttributtypId",
                table: "Attribut");

            migrationBuilder.AlterColumn<int>(
                name: "AttributtypId",
                table: "Attribut",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusNamn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "StatusNamn" },
                values: new object[] { 1, "Ny" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "StatusNamn" },
                values: new object[] { 2, "Pågående" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "StatusNamn" },
                values: new object[] { 3, "Avslutad" });

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Lappar",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Lappar_StatusId",
                table: "Lappar",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attribut_Attributtyper_AttributtypId",
                table: "Attribut",
                column: "AttributtypId",
                principalTable: "Attributtyper",
                principalColumn: "AttributtypId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lappar_Status_StatusId",
                table: "Lappar",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attribut_Attributtyper_AttributtypId",
                table: "Attribut");

            migrationBuilder.DropForeignKey(
                name: "FK_Lappar_Status_StatusId",
                table: "Lappar");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Lappar_StatusId",
                table: "Lappar");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Lappar");

            migrationBuilder.AlterColumn<int>(
                name: "AttributtypId",
                table: "Attribut",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Attribut_Attributtyper_AttributtypId",
                table: "Attribut",
                column: "AttributtypId",
                principalTable: "Attributtyper",
                principalColumn: "AttributtypId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
