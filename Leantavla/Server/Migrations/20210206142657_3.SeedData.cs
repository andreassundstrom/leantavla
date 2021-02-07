using Microsoft.EntityFrameworkCore.Migrations;

namespace Leantavla.Server.Migrations
{
    public partial class _3SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attribut_Attributtyp_AttributtypId",
                table: "Attribut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attributtyp",
                table: "Attributtyp");

            migrationBuilder.RenameTable(
                name: "Attributtyp",
                newName: "Attributtyper");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attributtyper",
                table: "Attributtyper",
                column: "AttributtypId");

            migrationBuilder.InsertData(
                table: "Attributtyper",
                columns: new[] { "AttributtypId", "Attributbeskrivning", "Attributnamn", "Datatyp" },
                values: new object[] { 1, "Personen som skapade lappen", "Skapare", 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Attribut_Attributtyper_AttributtypId",
                table: "Attribut",
                column: "AttributtypId",
                principalTable: "Attributtyper",
                principalColumn: "AttributtypId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attribut_Attributtyper_AttributtypId",
                table: "Attribut");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attributtyper",
                table: "Attributtyper");

            migrationBuilder.DeleteData(
                table: "Attributtyper",
                keyColumn: "AttributtypId",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Attributtyper",
                newName: "Attributtyp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attributtyp",
                table: "Attributtyp",
                column: "AttributtypId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attribut_Attributtyp_AttributtypId",
                table: "Attribut",
                column: "AttributtypId",
                principalTable: "Attributtyp",
                principalColumn: "AttributtypId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
