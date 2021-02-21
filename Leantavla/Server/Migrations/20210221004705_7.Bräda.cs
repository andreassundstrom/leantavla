using Microsoft.EntityFrameworkCore.Migrations;

namespace Leantavla.Server.Migrations
{
    public partial class _7Bräda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributtyper",
                keyColumn: "AttributtypId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attributtyper",
                keyColumn: "AttributtypId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attributtyper",
                keyColumn: "AttributtypId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attributtyper",
                keyColumn: "AttributtypId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "BrädaId",
                table: "Status",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sortering",
                table: "Status",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrädaId",
                table: "Lappar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrädaId",
                table: "Attributtyper",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bräda",
                columns: table => new
                {
                    BrädaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrädaNamn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bräda", x => x.BrädaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Status_BrädaId",
                table: "Status",
                column: "BrädaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lappar_BrädaId",
                table: "Lappar",
                column: "BrädaId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributtyper_BrädaId",
                table: "Attributtyper",
                column: "BrädaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributtyper_Bräda_BrädaId",
                table: "Attributtyper",
                column: "BrädaId",
                principalTable: "Bräda",
                principalColumn: "BrädaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lappar_Bräda_BrädaId",
                table: "Lappar",
                column: "BrädaId",
                principalTable: "Bräda",
                principalColumn: "BrädaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Bräda_BrädaId",
                table: "Status",
                column: "BrädaId",
                principalTable: "Bräda",
                principalColumn: "BrädaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributtyper_Bräda_BrädaId",
                table: "Attributtyper");

            migrationBuilder.DropForeignKey(
                name: "FK_Lappar_Bräda_BrädaId",
                table: "Lappar");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Bräda_BrädaId",
                table: "Status");

            migrationBuilder.DropTable(
                name: "Bräda");

            migrationBuilder.DropIndex(
                name: "IX_Status_BrädaId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Lappar_BrädaId",
                table: "Lappar");

            migrationBuilder.DropIndex(
                name: "IX_Attributtyper_BrädaId",
                table: "Attributtyper");

            migrationBuilder.DropColumn(
                name: "BrädaId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "Sortering",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "BrädaId",
                table: "Lappar");

            migrationBuilder.DropColumn(
                name: "BrädaId",
                table: "Attributtyper");

            migrationBuilder.InsertData(
                table: "Attributtyper",
                columns: new[] { "AttributtypId", "Attributbeskrivning", "Attributnamn", "Datatyp" },
                values: new object[,]
                {
                    { 4, "Personen som skapade lappen", "Skapare", 0 },
                    { 3, "Tidpunkt för när lappen skapades", "Skapad", 1 },
                    { 1, "Kort beskrivning av problemet", "Sammanfattning", 0 },
                    { 2, "Beskrivning av problemet", "Beskrivning", 2 }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "StatusNamn" },
                values: new object[,]
                {
                    { 1, "Ny" },
                    { 2, "Pågående" },
                    { 3, "Avslutad" }
                });
        }
    }
}
