using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class RelacionesUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "Votos_Actas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "Votos_Acta_RP",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "Actas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "Acta_RP",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Actas_UsuarioRegistro",
                table: "Votos_Actas",
                column: "UsuarioRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Acta_RP_UsuarioRegistro",
                table: "Votos_Acta_RP",
                column: "UsuarioRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Actas_UsuarioRegistro",
                table: "Actas",
                column: "UsuarioRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Acta_RP_UsuarioRegistro",
                table: "Acta_RP",
                column: "UsuarioRegistro");

            migrationBuilder.AddForeignKey(
                name: "FK_Acta_RP_AspNetUsers_UsuarioRegistro",
                table: "Acta_RP",
                column: "UsuarioRegistro",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actas_AspNetUsers_UsuarioRegistro",
                table: "Actas",
                column: "UsuarioRegistro",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Acta_RP_AspNetUsers_UsuarioRegistro",
                table: "Votos_Acta_RP",
                column: "UsuarioRegistro",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Actas_AspNetUsers_UsuarioRegistro",
                table: "Votos_Actas",
                column: "UsuarioRegistro",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acta_RP_AspNetUsers_UsuarioRegistro",
                table: "Acta_RP");

            migrationBuilder.DropForeignKey(
                name: "FK_Actas_AspNetUsers_UsuarioRegistro",
                table: "Actas");

            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Acta_RP_AspNetUsers_UsuarioRegistro",
                table: "Votos_Acta_RP");

            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Actas_AspNetUsers_UsuarioRegistro",
                table: "Votos_Actas");

            migrationBuilder.DropIndex(
                name: "IX_Votos_Actas_UsuarioRegistro",
                table: "Votos_Actas");

            migrationBuilder.DropIndex(
                name: "IX_Votos_Acta_RP_UsuarioRegistro",
                table: "Votos_Acta_RP");

            migrationBuilder.DropIndex(
                name: "IX_Actas_UsuarioRegistro",
                table: "Actas");

            migrationBuilder.DropIndex(
                name: "IX_Acta_RP_UsuarioRegistro",
                table: "Acta_RP");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "Votos_Actas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "Votos_Acta_RP",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "Actas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioRegistro",
                table: "Acta_RP",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
