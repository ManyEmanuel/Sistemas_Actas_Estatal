using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class HistorialSubsanarenlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "Recepcion_Paquete",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recepcion_Paquete_UsuarioRegistro",
                table: "Recepcion_Paquete",
                column: "UsuarioRegistro");

            migrationBuilder.AddForeignKey(
                name: "FK_Recepcion_Paquete_AspNetUsers_UsuarioRegistro",
                table: "Recepcion_Paquete",
                column: "UsuarioRegistro",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recepcion_Paquete_AspNetUsers_UsuarioRegistro",
                table: "Recepcion_Paquete");

            migrationBuilder.DropIndex(
                name: "IX_Recepcion_Paquete_UsuarioRegistro",
                table: "Recepcion_Paquete");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "Recepcion_Paquete",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
