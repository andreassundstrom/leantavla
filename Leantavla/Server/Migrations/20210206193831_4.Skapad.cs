using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leantavla.Server.Migrations
{
    public partial class _4Skapad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateValue",
                table: "Attribut",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringValue",
                table: "Attribut",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Attributtyper",
                columns: new[] { "AttributtypId", "Attributbeskrivning", "Attributnamn", "Datatyp" },
                values: new object[] { 2, "Tidpunkt för när lappen skapades", "Skapad", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributtyper",
                keyColumn: "AttributtypId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "DateValue",
                table: "Attribut");

            migrationBuilder.DropColumn(
                name: "StringValue",
                table: "Attribut");
        }
    }
}
