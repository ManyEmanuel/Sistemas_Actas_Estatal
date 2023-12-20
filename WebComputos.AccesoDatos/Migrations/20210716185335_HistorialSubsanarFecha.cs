using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class HistorialSubsanarFecha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaHora",
                table: "HistorialSubsanar",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioRegistro",
                table: "HistorialSubsanar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaHora",
                table: "HistorialSubsanar");

            migrationBuilder.DropColumn(
                name: "UsuarioRegistro",
                table: "HistorialSubsanar");
        }
    }
}
