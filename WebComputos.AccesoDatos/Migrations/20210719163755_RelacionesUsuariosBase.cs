using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class RelacionesUsuariosBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "HistorialSubsanar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistorialSubsanar_UsuarioRegistro",
                table: "HistorialSubsanar",
                column: "UsuarioRegistro");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialSubsanar_AspNetUsers_UsuarioRegistro",
                table: "HistorialSubsanar",
                column: "UsuarioRegistro",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialSubsanar_AspNetUsers_UsuarioRegistro",
                table: "HistorialSubsanar");

            migrationBuilder.DropIndex(
                name: "IX_HistorialSubsanar_UsuarioRegistro",
                table: "HistorialSubsanar");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "HistorialSubsanar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
