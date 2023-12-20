using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class usuarioregistro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioRegistro",
                table: "Votos_Actas_Ext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioRegistro",
                table: "Votos_Actas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioRegistro",
                table: "Votos_Acta_RP",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioRegistro",
                table: "Recepcion_Paquete",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioRegistro",
                table: "Actas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioRegistro",
                table: "Acta_RP",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioRegistro",
                table: "Votos_Actas_Ext");

            migrationBuilder.DropColumn(
                name: "UsuarioRegistro",
                table: "Votos_Actas");

            migrationBuilder.DropColumn(
                name: "UsuarioRegistro",
                table: "Votos_Acta_RP");

            migrationBuilder.DropColumn(
                name: "UsuarioRegistro",
                table: "Recepcion_Paquete");

            migrationBuilder.DropColumn(
                name: "UsuarioRegistro",
                table: "Actas");

            migrationBuilder.DropColumn(
                name: "UsuarioRegistro",
                table: "Acta_RP");
        }
    }
}
