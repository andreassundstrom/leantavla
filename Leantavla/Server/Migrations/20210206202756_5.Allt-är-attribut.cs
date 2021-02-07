using Microsoft.EntityFrameworkCore.Migrations;

namespace Leantavla.Server.Migrations
{
    public partial class _5Alltärattribut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beskrivning",
                table: "Lappar");

            migrationBuilder.DropColumn(
                name: "Sammanfattning",
                table: "Lappar");

            migrationBuilder.UpdateData(
                table: "Attributtyper",
                keyColumn: "AttributtypId",
                keyValue: 1,
                columns: new[] { "Attributbeskrivning", "Attributnamn" },
                values: new object[] { "Kort beskrivning av problemet", "Sammanfattning" });

            migrationBuilder.UpdateData(
                table: "Attributtyper",
                keyColumn: "AttributtypId",
                keyValue: 2,
                columns: new[] { "Attributbeskrivning", "Attributnamn", "Datatyp" },
                values: new object[] { "Beskrivning av problemet", "Beskrivning", 2 });

            migrationBuilder.InsertData(
                table: "Attributtyper",
                columns: new[] { "AttributtypId", "Attributbeskrivning", "Attributnamn", "Datatyp" },
                values: new object[,]
                {
                    { 4, "Personen som skapade lappen", "Skapare", 0 },
                    { 3, "Tidpunkt för när lappen skapades", "Skapad", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributtyper",
                keyColumn: "AttributtypId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attributtyper",
                keyColumn: "AttributtypId",
                keyValue: 4);

            migrationBuilder.AddColumn<string>(
                name: "Beskrivning",
                table: "Lappar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sammanfattning",
                table: "Lappar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Attributtyper",
                keyColumn: "AttributtypId",
                keyValue: 1,
                columns: new[] { "Attributbeskrivning", "Attributnamn" },
                values: new object[] { "Personen som skapade lappen", "Skapare" });

            migrationBuilder.UpdateData(
                table: "Attributtyper",
                keyColumn: "AttributtypId",
                keyValue: 2,
                columns: new[] { "Attributbeskrivning", "Attributnamn", "Datatyp" },
                values: new object[] { "Tidpunkt för när lappen skapades", "Skapad", 1 });
        }
    }
}
