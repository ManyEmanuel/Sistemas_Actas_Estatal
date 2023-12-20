using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class NuevosCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Complementaria",
                table: "HistorialModificaciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Paquetes",
                table: "HistorialModificaciones",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Votos",
                table: "HistorialModificaciones",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complementaria",
                table: "HistorialModificaciones");

            migrationBuilder.DropColumn(
                name: "Paquetes",
                table: "HistorialModificaciones");

            migrationBuilder.DropColumn(
                name: "Votos",
                table: "HistorialModificaciones");
        }
    }
}
